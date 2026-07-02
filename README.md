# Enjin Platform SDK by Enjin for C#

[![License: LGPL 3.0](https://img.shields.io/badge/license-LGPL_3.0-purple)](https://opensource.org/license/lgpl-3-0/)
[![Build & Test](https://github.com/enjin/platform-csharp-sdk/actions/workflows/Build%20&%20Test.yml/badge.svg?branch=master)](https://github.com/enjin/platform-csharp-sdk/actions/workflows/Build%20&%20Test.yml)

Open source SDK for connecting to and interacting with the Enjin Platform (v3 GraphQL API).

More documentation may be found on the [Official Documentation Page](https://docs.enjin.io/).

## Packages

|                    | NuGet                                                                                                                 |
|--------------------|-----------------------------------------------------------------------------------------------------------------------|
| Enjin.Platform.Sdk | [![NuGet](https://img.shields.io/nuget/v/Enjin.Platform.Sdk.svg)](https://www.nuget.org/packages/Enjin.Platform.Sdk/) |

Starting with version 3.0.0 the SDK ships as a single package targeting the v3 Platform API. The previous
sub-packages (`Enjin.Platform.Sdk.Beam`, `Enjin.Platform.Sdk.FuelTanks`, `Enjin.Platform.Sdk.Marketplace`) have been
discontinued — all functionality now lives in `Enjin.Platform.Sdk`.

## Compatibility

This SDK targets **.NET Standard 2.1**, which is compatible with:

* .NET 5.0+
* Godot 4.0 or newer (using .NET 6+ / .NET Standard 2.1)

## Quick start

```csharp
using Enjin.Platform.Sdk;

using var client = new PlatformClient(new Uri("https://platform.canary.enjin.io/graphql"));
client.Auth("<your platform auth token>");

// Build a query with the generated fluent builder.
var query = new QueryQueryBuilder()
    .WithGetAccount(
        new AccountQueryBuilder().WithId().WithAddress().WithBalance(),
        network: Network.Enjin,
        chain: Chain.Matrix,
        address: "<ss58 address>");

IPlatformResponse<QueryResponse> response = await client.SendQuery(query);

if (response.Result.Errors is { Count: > 0 })
{
    foreach (var err in response.Result.Errors)
        Console.WriteLine(err.Message);
    return;
}

var account = response.Result.Data.GetAccount;
Console.WriteLine($"{account?.Address} -> {account?.Balance}");
```

Mutations work the same way via `SendMutation` and `MutationQueryBuilder`:

```csharp
var mutation = new MutationQueryBuilder()
    .WithCreateManagedWallet(externalId: "my-user-123");

IPlatformResponse<MutationResponse> response = await client.SendMutation(mutation);
```

## How it works

The SDK is generated from the Platform's GraphQL schema using
[GraphQlClientGenerator](https://github.com/Husqvik/GraphQlClientGenerator). The generated code lives under
`src/Enjin.Platform.Sdk/Enjin.Platform.Sdk/Schema/`, bucketed by GraphQL type kind:

* `Schema/Infrastructure/` — base classes and the GraphQL type-name registry.
* `Schema/Enums/` — every GraphQL enum (e.g. `Network`, `Chain`, `TransactionStateEnum`).
* `Schema/Model/` — POCOs for every object / union / interface type (e.g. `Account`, `Transaction`, `Block`).
* `Schema/Inputs/` — every GraphQL input object (e.g. `TransferBalanceParams`, `MintTokenParams`).
* `Schema/QueryBuilders/` — fluent builders for every type, including the root `QueryQueryBuilder` and
  `MutationQueryBuilder` used to compose operations.

A thin transport layer (`PlatformClient`, `PlatformRequest`, `PlatformHandler`) handles HTTP, bearer-token
authentication, and JSON serialization via Newtonsoft.Json.

To regenerate the schema after a Platform API change, see
[CONTRIBUTING.md](./CONTRIBUTING.md#regenerating-the-graphql-schema).

## Changelog

Please see [CHANGELOG](https://github.com/enjin/platform-csharp-sdk/blob/master/CHANGELOG.md) for more information on
recent changes.

## Contributing

Please see [CONTRIBUTING](https://github.com/enjin/platform-csharp-sdk/blob/master/CONTRIBUTING.md) for details.

## Credits

* [Enjin](https://enjin.io)
* [All Contributors](https://github.com/enjin/platform-csharp-sdk/contributors)

## License

This project is licensed under the LGPL 3.0 License. Please
see [LICENSE](https://github.com/enjin/platform-csharp-sdk/blob/master/LICENSE) for more information.
