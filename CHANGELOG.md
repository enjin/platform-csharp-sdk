# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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
  can be consumed from Unity 2021.2+ and Godot 4+.
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
  [`platform-sdk-generators`](https://github.com/enjin/platform-sdk-generators) is retained but
  marked unused — the Platform team has confirmed events are not supported at this time.
- **Breaking:** All hand-written input/output models, enums, and GraphQL fragments under `Model/`,
  `Schema/`, and `GraphQl/` have been removed in favour of the generated client.
- **Breaking:** `Enjin.Platform.Sdk.Tests` no longer ships test data for multipart uploads; v3 has no
  `Upload` scalar.

## [v1.0.0-beta.1] - 2023-06-21

- Public beta release.

[Unreleased]: https://github.com/enjin/platform-csharp-sdk/compare/v3.0.0...HEAD

[v3.0.0]: https://github.com/enjin/platform-csharp-sdk/compare/v1.0.0-beta.1...v3.0.0

[v1.0.0-beta.1]: https://github.com/enjin/platform-csharp-sdk/releases/tag/v1.0.0-beta.1