# Enjin Platform SDK (Unity package template)

This directory is the **template** used by `.github/workflows/unity.yml` to
assemble the Unity Package Manager (UPM) distribution of the SDK on every
`v*` tag push. It is not itself a valid UPM package — `package.json` is
templated (`${VERSION}` placeholder) and the compiled DLL is added by CI.

The assembled package is published to a parallel `upm/<version>` git tag and
attached as a tarball to the GitHub release.

## Layout

```
unity-template/
├── package.json.tmpl         # UPM manifest; CI substitutes ${VERSION}
├── Third Party Notices.md    # Newtonsoft.Json acknowledgement
├── Runtime.meta              # stable .meta for the Runtime folder
└── Runtime/
    ├── link.xml              # IL2CPP preservation rules
    ├── link.xml.meta
    ├── Enjin.Platform.Sdk.dll.meta   # stable .meta for the DLL (assigned by CI build)
    └── Enjin.Platform.Sdk.xml.meta   # stable .meta for the XML docs
```

CI additionally copies in at assemble time:

- `Runtime/Enjin.Platform.Sdk.dll` (from `bin/Release/netstandard2.1/`)
- `Runtime/Enjin.Platform.Sdk.xml` (from `bin/Release/netstandard2.1/`)
- `README.md`, `CHANGELOG.md`, `LICENSE.md` (copied from repo root)
- `package.json` (templated from `package.json.tmpl`)

## Stable GUIDs

The `.meta` files commit fixed GUIDs so that user scripts referencing the DLL
by GUID remain valid across SDK versions. **Do not edit the `guid:` lines.**

## Install (end users)

```
# Unity ▸ Window ▸ Package Manager ▸ + ▸ Add package from git URL
https://github.com/enjin/platform-csharp-sdk.git#upm/v3.0.0
```

Requirements:

- Unity 2021.3 LTS or newer
- Project API Compatibility Level: **.NET Standard 2.1**
- `com.unity.nuget.newtonsoft-json` (resolved automatically as a dependency)
