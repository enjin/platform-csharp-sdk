#!/usr/bin/env bash
# Run formatters, build, and tests before committing.
# Usage: ./scripts/precommit.sh
#
# Works under bash and zsh, regardless of the caller's working directory.

set -euo pipefail

# Resolve this script's directory in a shell-agnostic way.
# $BASH_SOURCE exists in bash; ${(%):-%x} is the zsh equivalent; $0 is the
# universal fallback when the script is invoked as `sh script.sh`.
if [ -n "${BASH_SOURCE:-}" ]; then
    SCRIPT_PATH="${BASH_SOURCE[0]}"
elif [ -n "${ZSH_VERSION:-}" ]; then
    # shellcheck disable=SC2296
    SCRIPT_PATH="${(%):-%x}"
else
    SCRIPT_PATH="$0"
fi

SCRIPT_DIR="$(cd "$(dirname "$SCRIPT_PATH")" && pwd)"
REPO_ROOT="$(cd "$SCRIPT_DIR/.." && pwd)"
SOLUTION="$REPO_ROOT/src/Enjin.Platform.Sdk/Enjin.Platform.Sdk.sln"
SRC_DIR="$REPO_ROOT/src"

cd "$REPO_ROOT"

echo "==> Restoring .NET tools"
dotnet tool restore

echo "==> Running CSharpier"
dotnet csharpier format "$SRC_DIR"

echo "==> Running dotnet format"
dotnet format "$SOLUTION"

echo "==> Building solution"
dotnet build "$SOLUTION" --configuration Release

echo "==> Running tests"
dotnet test "$SOLUTION" --configuration Release --no-build

echo "==> All checks passed"
