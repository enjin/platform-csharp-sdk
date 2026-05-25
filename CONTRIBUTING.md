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

The contents of `src/Enjin.Platform.Sdk/Enjin.Platform.Sdk/Schema/Generated.cs` are produced from the Platform's
GraphQL schema by the
[`platform-sdk-generators`](https://github.com/enjin/platform-sdk-generators) tool (which wraps
[GraphQlClientGenerator](https://github.com/Husqvik/GraphQlClientGenerator)).

To regenerate the schema after a Platform API change:

1. Clone the generators repository alongside this one:

   ```sh
   git clone git@github.com:enjin/platform-sdk-generators.git
   ```

2. Drop the latest `v3.json` schema (downloadable via introspection from the target Platform deployment) into
   `platform-sdk-generators/CSharpSchemaGenerator/CSharpSchemaGenerator/schema/v3.json`.

3. Run the generator:

   ```sh
   cd platform-sdk-generators/CSharpSchemaGenerator/CSharpSchemaGenerator
   dotnet run
   ```

   This produces `generated/v3.cs` in the same folder.

4. Copy the output into this repo, overwriting the existing file:

   ```sh
   cp generated/v3.cs \
       ../../../platform-csharp-sdk/src/Enjin.Platform.Sdk/Enjin.Platform.Sdk/Schema/Generated.cs
   ```

5. Build and run the tests:

   ```sh
   dotnet test src/Enjin.Platform.Sdk/Enjin.Platform.Sdk.sln
   ```

The generated file is committed as source — consumers do not need to run the generator themselves. Any custom
scalar mappings (e.g. `BigInt` → `System.Numerics.BigInteger`, `DateTime` → `System.DateTimeOffset`) live in the
generators repo and apply automatically.

If you need to add a hand-written wrapper, helper, or transport feature, place it next to the existing
`Platform/` types — **never** edit `Schema/Generated.cs` directly, as your changes will be lost on the next
regeneration.
