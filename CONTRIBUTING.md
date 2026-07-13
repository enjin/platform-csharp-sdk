# Contributing to the Enjin Platform C# SDK

Contributions are appreciated. You may contribute to this SDK by filing issues or opening pull requests (PRs).

## Reporting Issues

Bug reports, API proposals, and feedback in general are always welcomed.

### Check for Existing Issues

Before opening a new issue, please search [open issues](https://github.com/enjin/platform-csharp-sdk/issues) to check if
it already exists.

If the issue already exists, then please consider adding contributing feedback in the discussion.

### API Proposals

API proposals are welcomed, however do consider if the API proposal is isolated at the SDK level or involves some other
component of the ecosystem.

### Reporting Bugs

Before reporting a bug, please consider if it is a bug within the SDK or a bug somewhere else in the ecosystem that the
SDK interacts with. For example, before creating a bug report that focuses on a particular GraphQL request, consider
testing the same request in your platform's GraphiQL development environment (with the same exact parameters if
possible) and compare the behavior there against the SDK.

A bug report should contain the following information:

* A high-level description of the problem.
* A *minimal reproduction*, as in the smallest unit of code or configuration required to reproduce the behavior.
* A description of the *expected behavior* and the *actual behavior*.
* Environment information: SDK version, OS, C#/.NET version, etc.
* Additional information, such as whether it worked in a previous version or if there are any workarounds.

⚠️ **Do not** include any sensitive information in your bug report(s), e.g. your Enjin Platform's authorization tokens.

## Contributing Changes

Project maintainers will merge changes that significantly improve the SDK.

### DOs and DON'Ts

Please do:

* **DO** include documentation when adding new type or methods.
* **DO** include tests when adding new features that are not fully dependent on a third-party library used by the SDK.
    * For example, it is acceptable to forgo testing when it comes to de/serializing type models.
* **DO** keep discussions focused. When new topics come up, consider creating a new issue.
* **DO** clearly state on an issue whether you are going to take on its implementation.
* **DO** blog about or share your contributions on social media.

Please do not:

* **DON'T** make PRs for style changes.
* **DON'T** make large surprise PRs. Please file an issue to start a discussion so a direction can be agreed upon
  before commiting a large amount of time.
* **DON'T** commit code that you did not write.
* **DON'T** submit PRs that alter licensing.

### Breaking Changes

Contributions which happen to introduce breaking changes may be considered if they are offset by significant
improvements to the API, project structure, or respond to changes in the Platform or .NET ecosystems. However, in
contributions which contain breaking changes will generally be discouraged.

## Regenerating the GraphQL schema

The contents of `src/Enjin.Platform.Sdk/Enjin.Platform.Sdk/Schema/` are produced from the Platform's
GraphQL schema by the
[`platform-sdk-generators`](https://github.com/enjin/platform-sdk-generators) tool (which wraps
[GraphQlClientGenerator](https://github.com/Husqvik/GraphQlClientGenerator)).

The generated tree is bucketed by GraphQL type kind into:

- `Schema/Infrastructure/` — `BaseClasses.cs` (the query-builder runtime) and `GraphQlTypes.cs` (the type-name registry).
- `Schema/Enums/` — one file per GraphQL enum.
- `Schema/Model/` — one file per GraphQL object / union / interface (data classes).
- `Schema/Inputs/` — one file per GraphQL input object.
- `Schema/QueryBuilders/` — one file per fluent query/mutation builder (including the root `QueryQueryBuilder` and `MutationQueryBuilder`).

To regenerate the schema after a Platform API change:

1. Clone the generators repository alongside this one:

   ```sh
   git clone git@github.com:enjin/platform-sdk-generators.git
   ```

2. Run the generator. It fetches the live GraphQL schema via introspection directly from the Platform,
   so there is no schema file to download or drop in:

   ```sh
   cd platform-sdk-generators/CSharpSchemaGenerator/CSharpSchemaGenerator
   dotnet run
   ```

   This produces `generated/v3/Schema/{Infrastructure,Enums,Model,Inputs,QueryBuilders}/*.cs` in the same folder.
   The generator wipes `generated/v3/` before writing, so renamed or removed types do not leave orphan files.

3. Replace the SDK's `Schema/` tree with the generator output:

   ```sh
   rm -rf ../../../platform-csharp-sdk/src/Enjin.Platform.Sdk/Enjin.Platform.Sdk/Schema
   cp -R generated/v3/Schema \
       ../../../platform-csharp-sdk/src/Enjin.Platform.Sdk/Enjin.Platform.Sdk/Schema
   ```

4. Build and run the tests:

   ```sh
   dotnet test src/Enjin.Platform.Sdk/Enjin.Platform.Sdk.sln
   ```

5. (Recommended) Run the live smoke runner against a real Platform deployment to confirm the regenerated
   client still round-trips real data over the wire:

   ```sh
   cp tools/SdkSmoke/.env.example tools/SdkSmoke/.env
   # edit tools/SdkSmoke/.env and set ENJIN_PLATFORM_TOKEN
   dotnet run --project tools/SdkSmoke
   ```

   See [`tools/SdkSmoke/README.md`](tools/SdkSmoke/README.md) for details. The `.env` file is gitignored;
   never commit a token.

The generated files are committed as source — consumers do not need to run the generator themselves. Any custom
scalar mappings (e.g. `BigInt` → `System.Numerics.BigInteger`, `DateTime` → `System.DateTimeOffset`) live in the
generators repo and apply automatically.

If you need to add a hand-written wrapper, helper, or transport feature, place it next to the existing
`Platform/` types — **never** edit anything under `Schema/` directly, as your changes will be lost on the next
regeneration.
