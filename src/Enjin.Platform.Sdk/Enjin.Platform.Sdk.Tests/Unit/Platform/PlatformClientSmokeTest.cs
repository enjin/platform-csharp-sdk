using System;
using System.Threading.Tasks;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class PlatformClientSmokeTest
{
    private WireMockServer _server = null!;
    private PlatformClient _client = null!;

    [SetUp]
    public void SetUp()
    {
        _server = WireMockServer.Start();
        _client = new PlatformClient(new Uri(_server.Urls[0] + "/graphql"));
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _server.Stop();
        _server.Dispose();
    }

    [Test]
    public async Task SendQueryDeserializesData()
    {
        // Arrange
        const string responseBody = """
        {
          "data": {
            "GetAccount": {
              "id": "0xabc",
              "address": "5xyz"
            }
          }
        }
        """;

        _server
            .Given(Request.Create().WithPath("/graphql").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody(responseBody));

        var builder = new QueryQueryBuilder()
            .WithGetAccount(
                new AccountQueryBuilder().WithId().WithAddress(),
                Network.Enjin, Chain.Matrix, "0xabc");

        // Act
        var response = await _client.SendQuery(builder);
        Assert.Multiple(() =>
        {

            // Assert
            Assert.That(response.IsSuccessStatusCode, Is.True);
            Assert.That(response.Result, Is.Not.Null);
        });
        Assert.That(response.Result.Data, Is.Not.Null);
        Assert.That(response.Result.Data.GetAccount, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(response.Result.Data.GetAccount!.Id, Is.EqualTo("0xabc"));
            Assert.That(response.Result.Data.GetAccount.Address, Is.EqualTo("5xyz"));
            Assert.That(response.Result.Errors, Is.Null);
        });
    }

    [Test]
    public async Task SendQueryDeserializesErrors()
    {
        // Arrange
        const string responseBody = """
        {
          "data": null,
          "errors": [
            { "message": "Unauthorized", "locations": [ { "line": 1, "column": 1 } ] }
          ]
        }
        """;

        _server
            .Given(Request.Create().WithPath("/graphql").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody(responseBody));

        var builder = new QueryQueryBuilder()
            .WithGetAccount(
                new AccountQueryBuilder().WithId(),
                Network.Enjin, Chain.Matrix, "0xabc");

        // Act
        var response = await _client.SendQuery(builder);

        // Assert
        Assert.That(response.Result.Errors, Is.Not.Null);
        Assert.That(response.Result.Errors, Has.Count.EqualTo(1));
        Assert.That(response.Result.Errors!.GetEnumerator().MoveNext(), Is.True);
    }

    [Test]
    public async Task AuthTokenSetsBearerHeader()
    {
        // Arrange
        const string responseBody = """{"data":{}}""";

        _server
            .Given(Request.Create().WithPath("/graphql").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody(responseBody));

        _client.Auth("test-token-123");

        var builder = new QueryQueryBuilder()
            .WithGetAccount(new AccountQueryBuilder().WithId(),
                Network.Enjin, Chain.Matrix, "0x");

        // Act
        await _client.SendQuery(builder);

        // Assert
        var logEntry = _server.LogEntries.GetEnumerator();
        Assert.That(logEntry.MoveNext(), Is.True);
        var headers = logEntry.Current.RequestMessage.Headers!;
        Assert.Multiple(() =>
        {
            Assert.That(headers.ContainsKey("Authorization"), Is.True);
            Assert.That(headers["Authorization"][0], Is.EqualTo("Bearer test-token-123"));
        });
    }

    [Test]
    public void SendQueryPostsBuiltGraphqlDocumentAsJson()
    {
        // Arrange
        _server
            .Given(Request.Create().WithPath("/graphql").UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody("""{"data":{}}"""));

        var builder = new QueryQueryBuilder()
            .WithGetAccount(new AccountQueryBuilder().WithId(),
                Network.Enjin, Chain.Matrix, "0xabc");

        // Act
        _ = _client.SendQuery(builder).GetAwaiter().GetResult();

        // Assert
        var logEntry = _server.LogEntries.GetEnumerator();
        Assert.That(logEntry.MoveNext(), Is.True);
        var body = logEntry.Current.RequestMessage.Body!;
        Assert.That(body, Does.StartWith("{\"query\":"));
        Assert.That(body, Does.Contain("GetAccount"));
        Assert.That(body, Does.Contain("id"));
    }
}
