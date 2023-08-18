using System.Text.Json;
using Microsoft.Net.Http.Headers;
using Moq;
using NUnit.Framework;
using WireMock.FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class PlatformClientTest
{
    private PlatformClient ClassUnderTest { get; set; }

    // Mocks
    private Mock<IPlatformRequest> MockRequest { get; set; }
    private WireMockServer MockServer { get; set; }

    private const string BaseUrl = "http://localhost";
    private const string ContentType = "Content-Type";
    private const string MediaType = "application/json";
    private const string Path = "/graphql";

    private static readonly TimeSpan TIMEOUT = TimeSpan.FromMilliseconds(5000);

    [OneTimeSetUp]
    public void BeforeAll()
    {
        MockRequest = new Mock<IPlatformRequest>();
        MockServer = WireMockServer.Start(new WireMockServerSettings
        {
            Urls = new[] { BaseUrl },
        });
    }

    [SetUp]
    public void BeforeEach()
    {
        MockRequest.Reset();
        MockServer.Reset();

        // Default stubs for mock request
        MockRequest.Setup(mock => mock.Content)
                   .Returns(new StringContent(string.Empty));
        MockRequest.Setup(mock => mock.Path)
                   .Returns(Path);

        ClassUnderTest = PlatformClient.Builder()
                                       .SetBaseAddress(MockServer.Url!)
                                       .Build();
    }

    [OneTimeTearDown]
    public void AfterAll()
    {
        MockServer.Stop();
        MockServer.Dispose();
    }

    [TearDown]
    public void AfterEach()
    {
        ClassUnderTest.Dispose();
    }

    [Test]
    public void SendRequestClientSetsExpectedUserAgentHeader()
    {
        // Arrange - Data
        string expectedKey = HeaderNames.UserAgent;
        string expectedValue = ClassUnderTest.UserAgent;
        const string responseBody = @"{""data"": {""result"": true}}";

        // Arrange - Stubbing
        MockServer.Given(Request.Create()
                                .WithPath(Path)
                                .UsingPost())
                  .RespondWith(Response.Create()
                                       .WithSuccess()
                                       .WithHeader(ContentType, MediaType)
                                       .WithBody(responseBody));

        // Act
        ClassUnderTest.SendRequest<GraphQlResponse<bool?>>(MockRequest.Object)
                      .Wait(TIMEOUT);

        // Assert
        MockServer.Should()
                  .HaveReceivedACall()
                  .WithHeader(expectedKey, expectedValue, $"Assert request has expected {expectedKey} header");
    }

    [Test]
    public void SendRequestWhenClientIsAuthenticatedSendsRequestWithAuthorizationHeader()
    {
        // Arrange - Data
        string expectedKey = HeaderNames.Authorization;
        const string expectedValue = "xyz";
        const string responseBody = @"{""data"": {""result"": true}}";
        ClassUnderTest.Auth(expectedValue);

        // Arrange - Stubbing
        MockServer.Given(Request.Create()
                                .WithPath(Path)
                                .UsingPost())
                  .RespondWith(Response.Create()
                                       .WithSuccess()
                                       .WithHeader(ContentType, MediaType)
                                       .WithBody(responseBody));

        // Assumptions
        Assume.That(ClassUnderTest.IsAuthenticated, Is.True,
                    $"Assume {ClassUnderTest.IsAuthenticated} is true");

        // Act
        ClassUnderTest.SendRequest<GraphQlResponse<bool?>>(MockRequest.Object)
                      .Wait(TIMEOUT);

        // Assert
        MockServer.Should()
                  .HaveReceivedACall()
                  .WithHeader(expectedKey, expectedValue, $"Assert request has expected {expectedKey} header");
    }

    [Test]
    public void SendRequestWhenProcessingValidResponseReturnsExpectedResult()
    {
        // Arrange - Data
        bool? expectedResult = true;
        const string responseBody = @"{""data"": {""result"": true}}";

        // Arrange - Stubbing
        MockServer.Given(Request.Create()
                                .WithPath(Path)
                                .UsingPost())
                  .RespondWith(Response.Create()
                                       .WithSuccess()
                                       .WithHeader(ContentType, MediaType)
                                       .WithBody(responseBody));

        // Act
        IPlatformResponse<GraphQlResponse<bool?>> actual = ClassUnderTest
                                                           .SendRequest<GraphQlResponse<bool?>>(MockRequest.Object)
                                                           .Result;

        // Assert
        Assert.That(actual.Result, Is.Not.Null,
                    $"Assert {nameof(actual.Result)} of {nameof(IPlatformResponse<GraphQlResponse<bool?>>)} is not null");
        Assert.That(actual.Result.Data, Is.Not.Null,
                    $"Assert {nameof(actual.Result.Data)} of {nameof(GraphQlResponse<bool?>)} is not null");
        Assert.That(actual.Result.Data!.Result, Is.EqualTo(expectedResult),
                    $"Assert {nameof(actual.Result.Data.Result)} of {nameof(GraphQlResponse<bool?>)} equals expected");
    }

    [Test]
    public void SendRequestWhenProcessingValidBatchResponseReturnsExpectedResult()
    {
        // Arrange - Data
        const bool expectedValue = true;
        const string responseBody = @"[{""data"": {""result"": true}}, {""data"": {""result"": true}}]";

        // Arrange - Stubbing
        MockServer.Given(Request.Create()
                                .WithPath(Path)
                                .UsingPost())
                  .RespondWith(Response.Create()
                                       .WithSuccess()
                                       .WithHeader(ContentType, MediaType)
                                       .WithBody(responseBody));

        // Act
        IPlatformResponse<IEnumerable<GraphQlResponse<JsonElement?>>> actual =
            ClassUnderTest.SendRequest<IEnumerable<GraphQlResponse<JsonElement?>>>(MockRequest.Object)
                          .Result;

        // Assert
        Assert.That(actual.Result, Is.Not.Null,
                    $"Assert {nameof(actual.Result)} of {nameof(IPlatformResponse<IEnumerable<GraphQlResponse<JsonElement?>>>)} is not null");
        Assert.That(actual.Result, Is.Not.Empty,
                    $"Assert {nameof(actual.Result)} of {nameof(IPlatformResponse<IEnumerable<GraphQlResponse<JsonElement?>>>)} is not empty");

        foreach (GraphQlResponse<JsonElement?> response in actual.Result)
        {
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccess, Is.True,
                            $"Assert {nameof(response.IsSuccess)} is not empty");
                Assert.That(response.Data!.Result!.Value.GetBoolean, Is.EqualTo(expectedValue),
                            $"Assert {nameof(response.Data.Result.Value)} has expected value");
            });
        }
    }
}