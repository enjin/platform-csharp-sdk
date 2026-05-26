#!/usr/bin/env bash
#
# assemble-upm.sh
#
# Assembles the Unity Package Manager (UPM) distribution of the SDK from:
#   - the contents of unity-template/
#   - the compiled DLL + XML docs in src/.../bin/Release/netstandard2.1/
#   - the repo-root README.md, CHANGELOG.md, LICENSE
#
# Output: an `upm-staging/` directory containing a valid UPM package, plus an
# `EnjinPlatformSdk-v<VERSION>-upm.tar.gz` tarball.
#
# Usage:
#   ./scripts/assemble-upm.sh <version>
#
# Example:
#   ./scripts/assemble-upm.sh 3.0.0
#
# Requires the SDK to have already been built in Release configuration:
#   dotnet build src/Enjin.Platform.Sdk/Enjin.Platform.Sdk/Enjin.Platform.Sdk.csproj -c Release
#

set -euo pipefail

if [[ $# -ne 1 ]]; then
  echo "usage: $0 <version>" >&2
  echo "  e.g. $0 3.0.0" >&2
  exit 2
fi

VERSION="$1"
REPO_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
TEMPLATE_DIR="${REPO_ROOT}/unity-template"
BUILD_OUT="${REPO_ROOT}/src/Enjin.Platform.Sdk/Enjin.Platform.Sdk/bin/Release/netstandard2.1"
STAGING="${REPO_ROOT}/upm-staging"
TARBALL="${REPO_ROOT}/EnjinPlatformSdk-v${VERSION}-upm.tar.gz"

# --- sanity checks ---------------------------------------------------------

if [[ ! -d "${TEMPLATE_DIR}" ]]; then
  echo "error: unity-template/ not found at ${TEMPLATE_DIR}" >&2
  exit 1
fi

if [[ ! -f "${BUILD_OUT}/Enjin.Platform.Sdk.dll" ]]; then
  echo "error: Enjin.Platform.Sdk.dll not found at ${BUILD_OUT}" >&2
  echo "       run 'dotnet build -c Release' first" >&2
  exit 1
fi

if [[ ! -f "${BUILD_OUT}/Enjin.Platform.Sdk.xml" ]]; then
  echo "warning: Enjin.Platform.Sdk.xml not found; users will have no IntelliSense docs" >&2
fi

# --- clean + copy template -------------------------------------------------

rm -rf "${STAGING}" "${TARBALL}"
mkdir -p "${STAGING}/Runtime"

# Copy meta files + link.xml verbatim from the template.
cp "${TEMPLATE_DIR}/Runtime.meta"                       "${STAGING}/Runtime.meta"
cp "${TEMPLATE_DIR}/Runtime/link.xml"                   "${STAGING}/Runtime/link.xml"
cp "${TEMPLATE_DIR}/Runtime/link.xml.meta"              "${STAGING}/Runtime/link.xml.meta"
cp "${TEMPLATE_DIR}/Runtime/Enjin.Platform.Sdk.dll.meta" "${STAGING}/Runtime/Enjin.Platform.Sdk.dll.meta"
cp "${TEMPLATE_DIR}/Runtime/Enjin.Platform.Sdk.xml.meta" "${STAGING}/Runtime/Enjin.Platform.Sdk.xml.meta"
cp "${TEMPLATE_DIR}/Third Party Notices.md"             "${STAGING}/Third Party Notices.md"

# --- substitute version into package.json ----------------------------------

sed "s/\${VERSION}/${VERSION}/g" "${TEMPLATE_DIR}/package.json.tmpl" > "${STAGING}/package.json"

# --- copy build outputs ----------------------------------------------------

cp "${BUILD_OUT}/Enjin.Platform.Sdk.dll" "${STAGING}/Runtime/Enjin.Platform.Sdk.dll"

if [[ -f "${BUILD_OUT}/Enjin.Platform.Sdk.xml" ]]; then
  cp "${BUILD_OUT}/Enjin.Platform.Sdk.xml" "${STAGING}/Runtime/Enjin.Platform.Sdk.xml"
fi

# --- copy repo-root metadata ----------------------------------------------

cp "${REPO_ROOT}/README.md"    "${STAGING}/README.md"
cp "${REPO_ROOT}/CHANGELOG.md" "${STAGING}/CHANGELOG.md"

# UPM convention is LICENSE.md (with .md suffix). Tolerate either upstream name.
if [[ -f "${REPO_ROOT}/LICENSE.md" ]]; then
  cp "${REPO_ROOT}/LICENSE.md" "${STAGING}/LICENSE.md"
elif [[ -f "${REPO_ROOT}/LICENSE" ]]; then
  cp "${REPO_ROOT}/LICENSE"    "${STAGING}/LICENSE.md"
else
  echo "warning: no LICENSE file found at repo root" >&2
fi

# --- tarball (npm-style: top-level 'package/' directory) -------------------
#
# OpenUPM and `npm pack` both expect the tarball to contain a single top-level
# directory named 'package/'. We mimic that layout so the tarball is consumable
# by either toolchain.

TAR_TMP="$(mktemp -d)"
mkdir -p "${TAR_TMP}/package"
cp -R "${STAGING}/." "${TAR_TMP}/package/"
tar -czf "${TARBALL}" -C "${TAR_TMP}" package
rm -rf "${TAR_TMP}"

# --- report ----------------------------------------------------------------

echo ""
echo "Assembled UPM package for version ${VERSION}"
echo "  staging:  ${STAGING}"
echo "  tarball:  ${TARBALL}"
echo ""
echo "Tree:"
( cd "${STAGING}" && find . -type f | sort | sed 's|^\./|  |' )
