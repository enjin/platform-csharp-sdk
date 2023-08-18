# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- `SetAttributes` method to `CreateTokenParams`.
- `SetSigningAccount` method to `UpdateTransaction`.
- `SetSignedAtBlock` method to `UpdateTransaction`.
- `GetBeams` query in beam schema.
- `RemoveTokens` mutation in beam schema.
- `ListingDataJsonConverter` class to Marketplace library
- `ListingStateJsonConverter` class to Marketplace library

### Changed

- `ListingData` now has converter attribute for `ListingDataJsonConverter`
- `ListingState` now has converter attribute for `ListingStateJsonConverter`
- `NotSupportedException` thrown within `GraphQlParameterJsonConverter.Read()` now has a message.

### Deprecated

- `SetSingleUse` method in `HasBeamCommonFieldsExtension`.

### Fixed

- `FixedPriceState.AmountFilled` now has the correct JSON property name
- Listener registrations within `PusherEventService` are now atomic.

## [v1.0.0-beta.1] - 2023-06-21

- Public beta release.

[Unreleased]: https://github.com/enjin/platform-csharp-sdk/compare/v1.0.0-beta.1...HEAD

[v1.0.0-beta.1]: https://github.com/enjin/platform-csharp-sdk/releases/tag/v1.0.0-beta.1