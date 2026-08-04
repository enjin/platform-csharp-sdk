# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [v3.0.4] - 2026-08-04

### Added

- Pusher channel authorization: the `AuthenticatePusherSocket(id)` mutation, plus the
  `PusherSocketAuth` model and `PusherSocketAuthQueryBuilder`. Authorizes the current user to
  subscribe to a private Pusher channel; this SDK still ships no event-subscription transport of its
  own.
- `Transaction.FailedItemIndexes` — zero-based positions of batch items that failed to dispatch while
  the extrinsic itself finalized (`CONTINUE_ON_ERROR` batches only).
- `freezeState` on `CreateTokenInput` and `CreateTokenEntryInput`, to create a token already frozen.
- `idempotencyPrefix` on the `SweepManagedWallet` mutation; each chunk is keyed as `{prefix}-{n}`.
- `CompatibleFuelTank.Address` (the tank account address) and `CompatibleFuelTank.AvailableBudget`
  (the amount available to fund this transaction, expressed as ENJ).

### Changed

- **Breaking:** `GetCompatibleFuelTanks` no longer takes `pallet` and `method`. It now takes
  `transactions: [TransactionInput]` and `batchMode: BatchTransactionModeEnum`, so compatibility is
  evaluated against the encoded calls.
- **Breaking:** `infusion` on `CreateTokenInput` / `CreateTokenEntryInput` retyped from
  `System.Numerics.BigInteger` to `string`, and `unitPrice` on `MintTokenInput` /
  `MintTokenEntryInput` from `BigInteger?` to `string?`. Both now take decimal or integer ENJ
  (e.g. `"1.5"`), converted to base units on-chain.
- **Breaking:** `FuelTankRuleSet.WhitelistedPallets` retyped from `ICollection<string>?` to
  `ICollection<FuelTankWhitelistedPallet>?`.
- `CreateFuelTankInput.RuleSets` documentation corrected: at least one rule set is required, because
  the chain rejects a tank with none.
- `Transaction.Error` documentation expanded: a non-null value means the requested work did not fully
  happen, including when `state` is `FINALIZED` but wrapped batch items failed to dispatch.

### Removed

- **Breaking:** `CompatibleFuelTank.RemainingBudget`, `CompatibleFuelTank.MaxBudget`, and
  `CompatibleFuelTank.ConsumedBudget`, superseded by `CompatibleFuelTank.AvailableBudget`.

## [v3.0.3] - 2026-07-13

### Added

- Fuel tanks are covered again after the v3.0.0 rewrite dropped them:
  - Queries: `GetFuelTank`, `GetFuelTanks`, `GetFuelTankAccounts`, `GetCompatibleFuelTanks`.
  - Inputs for creating, mutating, and removing tanks, rule sets, and accounts —
    `CreateFuelTankInput`, `MutateFuelTankInput`, `RemoveFuelTankInput`, `CreateRuleSetInput`,
    `RemoveRuleSetInput`, `AddAccountInput`, `AddAccountsInput`, `RemoveAccountInput`,
    `RemoveAccountsInput`, `DispatchRuleInput`, `AccountRuleInput`, `FuelBudgetRuleInput`,
    `RequireTokenInput`, `RuleSetEntryInput`, `UserAccountManagementInput`,
    `ShouldMutateAccountExpirationInput`, and `ShouldMutateUserAccountManagementInput`.
  - Models (and their query builders): `FuelTank`, `FuelTankRuleSet`, `FuelTankAccount`,
    `FuelTankAccountRule`, `FuelTankPermittedExtrinsic`, `FuelTankUserAccountManagement`,
    `FuelBudget`, `RequireToken`, `CompatibleFuelTank`, and `CompatibleFuelTankRuleSet`.
  - Enums: `CoveragePolicy`, `FuelTankPermittedMethod`, and `FuelTankWhitelistedPallet`.
- Managed wallet sweeps: the `SweepManagedWallet` mutation and `ManagedWalletSweepStatus` query, with
  the `SweepManagedWalletResult` and `ManagedWalletSweepStatus` models and
  `ManagedWalletSweepStatusEnum`.
- Wallet linking: the `CreateLinkingCode` mutation and `GetLinkedWallet` query, with the
  `LinkingCode` and `LinkedWallet` models.
- Collection approvals: `ApproveCollectionInput` and `UnapproveCollectionInput`.
- `MutateFreezeStateInput`, plus the `BatchTransactionModeEnum` and `ShouldMutateAction` enums.
- `Transaction.Error` — the on-chain failure reason, including partial batch failures.
- `Event.Data` (the raw event payload), `Extrinsic.Events`, and `TokenGroupToken.CollectionId`.

### Changed

- **Breaking:** ENJ and `BigDecimal` scalars now map to `string` instead of
  `System.Numerics.BigInteger` throughout the generated client — including `Account.Balance`,
  `Listing.Price`, `Listing.MinTakeValue`, `Listing.HighestPrice`, `Token.Infusion`,
  `PoolBalance.Stash` / `Reward` / `Active`, `AccountPool.Bonded`, `NominationPool.Capacity`,
  `CreateListingInput.Price`, `PlaceBidInput.Price`, `NominationPoolsBondInput.Amount`, and
  `AnswerCounterOfferInput.CounterPrice`. Values are decimal ENJ (e.g. `"1.5"`) and round-trip
  without precision loss.
- **Breaking:** `Transaction.ExtrinsicHash` (`string?`) replaced by `Transaction.Extrinsic`
  (`Extrinsic?`), resolved from the indexer.
- **Breaking:** `Block.Validator` retyped from `Account?` to `string?` — the validator public key.
- `Event.Name` documentation clarified: it is the human-readable pallet and method name.

### Removed

- **Breaking:** `Block.Events`. Events are now reached through `Extrinsic.Events`.
- **Breaking:** Unity support and the UPM distribution were dropped from this repository —
  `unity-template/`, `scripts/assemble-upm.sh`, the `upm` CI job, and the README's Unity install
  instructions. The SDK is distributed as a NuGet package only.

## [v3.0.2] - 2026-06-17

### Changed

- Release artifacts are no longer attached to GitHub Releases. The NuGet package is the distribution
  channel, and releases are created and published manually so they stay compatible with GitHub's
  immutable releases.

## [v3.0.1] - 2026-06-16

### Added

- `AccountToken` model and `AccountTokenQueryBuilder`, pairing a token with the holding account's
  balance for it.
- `PlatformClient.DefaultBaseAddress` (`https://platform.enjin.io/graphql`). The `baseAddress`
  constructor parameter is now optional and falls back to it instead of throwing
  `ArgumentNullException`.

### Changed

- **Breaking:** `Account.Tokens` retyped from `ICollection<Token>?` to `ICollection<AccountToken>?`,
  so each entry carries the account's balance alongside the token.
- Default `User-Agent` changed from `Enjin.Platform.Sdk/{version}` to
  `Enjin-Platform-CSharp-SDK/{version}`.
- The UPM package is now published to the dedicated
  [`enjin/platform-unity-sdk`](https://github.com/enjin/platform-unity-sdk) repository, installed by
  git URL, instead of parallel `upm/v<version>` tags on this repository.
- `Collection.Accounts` and `Token.Accounts` documentation now states the effective per-page limit:
  up to 100 when fetched via `GetCollection` / `GetToken`, up to 10 via the bulk queries.

## [v3.0.0] - 2026-05-25

### Added

- Auto-generated GraphQL client (under `Schema/`, bucketed into `Infrastructure/`, `Enums/`, `Model/`, `Inputs/`, `QueryBuilders/`) covering the entire v3 Platform API, including:
  - `QueryQueryBuilder` and `MutationQueryBuilder` fluent builders for every operation.
  - POCOs for every output type, input object, enum, and union exposed by the v3 schema.
  - `Query` / `Mutation` root types used to deserialize responses.
- `PlatformClient.SendQuery(QueryQueryBuilder)` and `PlatformClient.SendMutation(MutationQueryBuilder)`
  extension methods that build, dispatch, and deserialize a GraphQL operation in one call.
- `QueryResponse` / `MutationResponse` concrete envelopes that expose the GraphQL `data` and `errors`
  fields.
- Smoke tests for `PlatformClient` covering success, error, and bearer-token paths against a WireMock
  server.

### Changed

- **Breaking:** SDK now targets the Enjin Platform v3 GraphQL API. The v2 schema and all hand-written
  v2 operation/model classes have been removed.
- **Breaking:** Target framework lowered from `.NET Standard 2.0` to `.NET Standard 2.1` so the SDK
  can be consumed from Godot 4+.
- **Breaking:** JSON serialization moved from `System.Text.Json` to `Newtonsoft.Json` (13.0.3) to match
  the generator's runtime and engine ecosystem expectations.
- **Breaking:** `PlatformHandler` now attaches `Authorization: Bearer <token>` (previously the scheme
  was omitted).
- `PlatformClient` and `PlatformRequest` were rewritten to dispatch raw GraphQL documents built from
  the generated query builders.

### Removed

- **Breaking:** The `Enjin.Platform.Sdk.Beam`, `Enjin.Platform.Sdk.FuelTanks`, and
  `Enjin.Platform.Sdk.Marketplace` packages have been retired. All functionality is now part of the
  single `Enjin.Platform.Sdk` package (or, where the v3 API no longer exposes the feature, removed).
- **Breaking:** Pusher-based event subscriptions (`PusherEventService`, `Event/` namespace) have been
  removed. The v3 API does not yet expose a subscription/events transport that this SDK targets.
  The `CSharpEventsGenerator` project in
  [`platform-sdk-generators`](https://github.com/enjin/platform-sdk-generators) has also been deleted
  — the Platform team has confirmed events are not supported at this time.
- **Breaking:** All hand-written input/output models, enums, and GraphQL fragments under `Model/`,
  `Schema/`, and `GraphQl/` have been removed in favour of the generated client.
- **Breaking:** `Enjin.Platform.Sdk.Tests` no longer ships test data for multipart uploads; v3 has no
  `Upload` scalar.

## [v1.0.0-beta.1] - 2023-06-21

- Public beta release.

[Unreleased]: https://github.com/enjin/platform-csharp-sdk/compare/v3.0.4...HEAD

[v3.0.4]: https://github.com/enjin/platform-csharp-sdk/compare/v3.0.3...v3.0.4

[v3.0.3]: https://github.com/enjin/platform-csharp-sdk/compare/v3.0.2...v3.0.3

[v3.0.2]: https://github.com/enjin/platform-csharp-sdk/compare/v3.0.1...v3.0.2

[v3.0.1]: https://github.com/enjin/platform-csharp-sdk/compare/v3.0.0...v3.0.1

[v3.0.0]: https://github.com/enjin/platform-csharp-sdk/compare/v1.0.0-beta.1...v3.0.0

[v1.0.0-beta.1]: https://github.com/enjin/platform-csharp-sdk/releases/tag/v1.0.0-beta.1