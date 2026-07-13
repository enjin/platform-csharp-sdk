using Enjin.Platform.Sdk;

string url = GetEnv("ENJIN_PLATFORM_URL");
string token = GetEnv("ENJIN_PLATFORM_TOKEN");
string accountAddress = GetEnvOrDefault("ENJIN_PLATFORM_ACCOUNT", "cxNE5bEPcdpfbsMfdLka11Jj1QH7gihFcc9uKqXKtepcQhkPS");
int recentBlockId = int.Parse(GetEnvOrDefault("ENJIN_PLATFORM_RECENT_BLOCK", "11240208"));

Console.WriteLine($"=== Enjin Platform v3 SDK smoke test ===");
Console.WriteLine($"Endpoint: {url}");
Console.WriteLine($"Token:    {(token.Length > 8 ? token[..4] + "..." + token[^4..] : "<short>")}");
Console.WriteLine($"Account:  {accountAddress}");
Console.WriteLine($"Block:    {recentBlockId}");
Console.WriteLine();

using PlatformClient client = new(new Uri(url));
client.Auth(token);

await RunQuery(client, "1. GetBlock(id: recent) - transport sanity",
    new QueryQueryBuilder()
        .WithGetBlock(
            new BlockQueryBuilder().WithNumber().WithHash(),
            Network.Canary, Chain.Matrix, id: recentBlockId),
    r => $"block #{r.Data?.GetBlock?.Number} hash={r.Data?.GetBlock?.Hash}");

await RunQuery(client, "2. GetAccount(known address) - auth + BigInteger",
    new QueryQueryBuilder()
        .WithGetAccount(
            new AccountQueryBuilder().WithId().WithAddress().WithNonce().WithBalance(),
            Network.Canary, Chain.Matrix, accountAddress),
    r =>
    {
        var a = r.Data?.GetAccount;
        return a is null
            ? "account not found"
            : $"id={a.Id} addr={a.Address} nonce={a.Nonce} balance={a.Balance} (type={a.Balance.GetType().Name})";
    });

await RunQuery(client, "3. GetBlocks(ids: [recent, recent-1, recent-2]) - list of blocks",
    new QueryQueryBuilder()
        .WithGetBlocks(
            new BlockQueryBuilder().WithNumber().WithHash(),
            Network.Canary, Chain.Matrix, ids: new[] { recentBlockId, recentBlockId - 1, recentBlockId - 2 }),
    r =>
    {
        var blocks = r.Data?.GetBlocks;
        if (blocks is null) return "null";
        return $"{blocks.Count} blocks: " + string.Join(", ", blocks.Select(b => b?.Number?.ToString() ?? "?"));
    });

// NOTE: the former "GetBlock with Events" check was removed — the Platform v3
// schema no longer exposes `Block.events` (and there is no top-level events
// query), so that check no longer compiles. See the regeneration notes.

await RunQuery(client, "4. GetBlock with Validator + Extrinsics - scalar validator + nested extrinsics",
    new QueryQueryBuilder()
        .WithGetBlock(
            new BlockQueryBuilder()
                .WithNumber()
                .WithValidator()
                .WithExtrinsics(new ExtrinsicQueryBuilder().WithHash().WithSuccess().WithPallet().WithMethod()),
            Network.Canary, Chain.Matrix, id: recentBlockId),
    r =>
    {
        var b = r.Data?.GetBlock;
        if (b is null) return "null";
        return $"#{b.Number} validator={b.Validator} extrinsics={b.Extrinsics?.Count ?? 0}";
    });

string externalId = $"sdk-smoke-{DateTimeOffset.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid():N}".Substring(0, 40);
await RunMutation(client, $"5. CreateManagedWallet(externalId={externalId}) - non-destructive mutation",
    new MutationQueryBuilder()
        .WithCreateManagedWallet(externalId),
    r => $"created={r.Data?.CreateManagedWallet}");

Console.WriteLine();
Console.WriteLine("=== Done ===");

return;

static string GetEnv(string name)
{
    string? v = ReadEnv(name);
    if (v is not null) return v;
    throw new InvalidOperationException(
        $"Missing required env var {name}. Set it in your shell or in tools/SdkSmoke/.env (copy from .env.example).");
}

static string GetEnvOrDefault(string name, string fallback) => ReadEnv(name) ?? fallback;

static string? ReadEnv(string name)
{
    string? v = Environment.GetEnvironmentVariable(name);
    if (!string.IsNullOrWhiteSpace(v)) return v;

    // Walk up from the running binary to find tools/SdkSmoke/.env
    string envFile = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".env"));
    if (!File.Exists(envFile)) return null;

    foreach (var line in File.ReadAllLines(envFile))
    {
        var t = line.Trim();
        if (t.Length == 0 || t.StartsWith('#')) continue;
        int eq = t.IndexOf('=');
        if (eq <= 0) continue;
        var k = t[..eq].Trim();
        var val = t[(eq + 1)..].Trim();
        if (k == name && val.Length > 0) return val;
    }
    return null;
}

static async Task RunQuery(PlatformClient client, string label, QueryQueryBuilder builder, Func<QueryResponse, string> summarize)
{
    Console.WriteLine($"--- {label} ---");
    Console.WriteLine($"  REQ: {Truncate(builder.Build(), 240)}");
    try
    {
        var resp = await client.SendQuery(builder);
        Console.WriteLine($"  HTTP {(int)resp.StatusCode}");
        if (resp.Result.Errors is { Count: > 0 } errs)
        {
            Console.WriteLine($"  ERRORS:");
            foreach (var e in errs) Console.WriteLine($"    - {e.Message}");
        }
        else
        {
            Console.WriteLine($"  OK: {summarize(resp.Result)}");
        }
    }
    catch (Exception ex)
    {
        PrintEx(ex);
    }
    Console.WriteLine();
}

static async Task RunMutation(PlatformClient client, string label, MutationQueryBuilder builder, Func<MutationResponse, string> summarize)
{
    Console.WriteLine($"--- {label} ---");
    Console.WriteLine($"  REQ: {Truncate(builder.Build(), 240)}");
    try
    {
        var resp = await client.SendMutation(builder);
        Console.WriteLine($"  HTTP {(int)resp.StatusCode}");
        if (resp.Result.Errors is { Count: > 0 } errs)
        {
            Console.WriteLine($"  ERRORS:");
            foreach (var e in errs) Console.WriteLine($"    - {e.Message}");
        }
        else
        {
            Console.WriteLine($"  OK: {summarize(resp.Result)}");
        }
    }
    catch (Exception ex)
    {
        PrintEx(ex);
    }
    Console.WriteLine();
}

static void PrintEx(Exception ex)
{
    Console.WriteLine($"  EXCEPTION: {ex.GetType().Name}: {ex.Message}");
    if (ex.InnerException is not null)
        Console.WriteLine($"    inner: {ex.InnerException.GetType().Name}: {ex.InnerException.Message}");
}

static string Truncate(string s, int n) => s.Length <= n ? s : s[..n] + "...";
