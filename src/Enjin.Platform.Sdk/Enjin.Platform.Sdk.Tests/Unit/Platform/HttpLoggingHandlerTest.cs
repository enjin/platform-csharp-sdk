using Moq;
using NUnit.Framework;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class HttpLoggingHandlerTest
{
    // Mocks
    private Mock<ILogger> MockLogger { get; set; }
    private Mock<IPlatformRequest> MockRequest { get; set; }
    private WireMockServer MockServer { get; set; }

    private const string BaseUrl = "http://localhost";
    private const string Path = "/graphql";

    private static readonly TimeSpan TIMEOUT = TimeSpan.FromSeconds(5000);

    [OneTimeSetUp]
    public void BeforeAll()
    {
        MockLogger = new Mock<ILogger>();
        MockRequest = new Mock<IPlatformRequest>();
        MockServer = WireMockServer.Start(new WireMockServerSettings
        {
            Urls = new[] { BaseUrl },
        });
    }

    [SetUp]
    public void BeforeEach()
    {
        MockLogger.Reset();
        MockRequest.Reset();
        MockServer.Reset();

        // Default stubs for mock request
        MockRequest.Setup(mock => mock.Content)
                   .Returns(new StringContent(string.Empty));
        MockRequest.Setup(mock => mock.Path)
                   .Returns(string.Empty);
    }

    [OneTimeTearDown]
    public void AfterAll()
    {
        MockServer.Stop();
        MockServer.Dispose();
    }

    [Test]
    public void WhenClientHasHttpLogLevelOfNonePerformsNoLogging()
    {
        // Arrange - Data
        const string responseBody = @"{""data"": {""result"": true}}";
        IPlatformClient client = CreateClient(HttpLogLevel.None);

        // Arrange - Stubbing
        MockServer.Given(Request.Create()
                                .WithPath(Path))
                  .RespondWith(Response.Create()
                                       .WithSuccess()
                                       .WithBody(responseBody));

        // Act
        client.SendRequest<GraphQlResponse<bool?>>(MockRequest.Object)
              .Wait(TIMEOUT);

        // Verify
        MockLogger.VerifyNoOtherCalls();
    }

    [Test]
    public void WhenClientHasHttpLogLevelNotOfNonePerformsLogging([Values(HttpLogLevel.Basic,
                                                                          HttpLogLevel.Headers,
                                                                          HttpLogLevel.Body)]
                                                                  HttpLogLevel httpLogLevel)
    {
        // Arrange - Data
        const string responseBody = @"{""data"": {""result"": true}}";
        IPlatformClient client = CreateClient(httpLogLevel);

        // Arrange - Stubbing
        MockServer.Given(Request.Create()
                                .WithPath(Path))
                  .RespondWith(Response.Create()
                                       .WithSuccess()
                                       .WithBody(responseBody));

        // Act
        client.SendRequest<GraphQlResponse<bool?>>(MockRequest.Object)
              .Wait(TIMEOUT);

        // Verify
        MockLogger.Verify(mock => mock.Log(LogLevel.Trace, It.IsAny<string?>()), Times.Exactly(2));
        MockLogger.VerifyNoOtherCalls();
    }

    private IPlatformClient CreateClient(HttpLogLevel httpLogLevel)
    {
        return PlatformClient.Builder()
                             .SetBaseAddress(MockServer.Url!)
                             .SetLogger(MockLogger.Object)
                             .SetHttpLogLevel(httpLogLevel)
                             .Build();
    }
}