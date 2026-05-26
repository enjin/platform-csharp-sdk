# SdkSmoke

A small console runner that exercises the SDK against a live Enjin Platform
deployment. Use it after regenerating `Schema/Generated.cs` (see
[CONTRIBUTING.md](../../CONTRIBUTING.md)) or before cutting a release, to
confirm the SDK round-trips real data over the wire.

This is **not** a unit test and is **not** part of the SDK solution. It is
deliberately kept out of CI because it requires a Platform token and hits a
real endpoint.

## Setup

1. Copy the example env file and fill in your token:

   ```sh
   cp .env.example .env
   # then edit .env and set ENJIN_PLATFORM_TOKEN=...
   ```

   `.env` is gitignored. Do not commit it.

2. (Optional) Override the endpoint, account address, or recent block id in
   `.env`. Defaults target Canary beta.

## Run

```sh
dotnet run --project tools/SdkSmoke
```

You should see each check print its request, HTTP status, and a one-line
summary of the response (or any GraphQL errors).

## What it covers

| # | Operation                                | Why it matters                              |
|---|------------------------------------------|---------------------------------------------|
| 1 | `GetBlock(id)`                           | Transport + auth sanity                     |
| 2 | `GetAccount(address)`                    | `BigInteger` scalar round-trips for balance |
| 3 | `GetBlocks(ids)`                         | List-of-object deserialization              |
| 4 | `GetBlock` + nested `Events`             | `Event` type + nullable `BigInteger`        |
| 5 | `GetBlock` + `Validator` + `Extrinsics`  | Nested complex types                        |
| 6 | `CreateManagedWallet(externalId)`        | Non-destructive mutation path               |

Each run of check 6 creates a fresh managed wallet on the target platform
using a timestamped `externalId`. There is no cleanup; this is a smoke test,
not a fixture.

## Environment variables

| Name                          | Required | Default                                  |
|-------------------------------|----------|------------------------------------------|
| `ENJIN_PLATFORM_URL`          | yes      | (set in `.env.example`)                  |
| `ENJIN_PLATFORM_TOKEN`        | yes      | -                                        |
| `ENJIN_PLATFORM_ACCOUNT`      | no       | `cxNE5bEPcdpfbsMfdLka11Jj1QH7gihFcc9uKqXKtepcQhkPS` |
| `ENJIN_PLATFORM_RECENT_BLOCK` | no       | `11240208`                               |

Shell environment variables take precedence over `.env`.
