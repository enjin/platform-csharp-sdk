using Moq;
using NUnit.Framework;
using PusherClient;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class PusherListenerTest
{
    private PusherListener ClassUnderTest { get; set; }

    // Mocks
    private Mock<IPusherEventServiceImpl> MockEventService { get; set; }
    private Mock<ILogger> MockLogger { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        MockEventService = new Mock<IPusherEventServiceImpl>();
        MockLogger = new Mock<ILogger>();
    }

    [SetUp]
    public void BeforeEach()
    {
        MockEventService.Reset();
        MockLogger.Reset();

        ClassUnderTest = new PusherListener(MockEventService.Object, MockLogger.Object);
    }

    [Test]
    public void OnEventWhenEventServiceHasRegisteredListenersPassesEventToListeners()
    {
        // Arrange - Data
        bool Matcher(string _) => true;
        PusherEvent dummyEvent = CreateEvent("Event Name", "Channel Name", new object());
        Mock<IEventListener> mockListener = new();
        Mock<IEventListenerRegistration> mockRegistration = new();
        List<IEventListenerRegistration> registrations = new()
        {
            mockRegistration.Object,
        };

        // Arrange - Stubbing
        mockRegistration.Setup(mock => mock.Listener)
                        .Returns(mockListener.Object);
        mockRegistration.Setup(mock => mock.Matcher)
                        .Returns(Matcher);
        MockEventService.Setup(mock => mock.Registrations)
                        .Returns(registrations);

        // Act
        ClassUnderTest.OnEvent(dummyEvent);

        // Verify
        MockEventService.Verify(mock => mock.Registrations, Times.AtLeastOnce);
        mockRegistration.Verify(mock => mock.Listener, Times.Once);
        mockRegistration.Verify(mock => mock.Matcher, Times.Once);
        mockListener.Verify(mock => mock.OnEvent(It.IsAny<PlatformEvent>()), Times.Once,
                            $"Verify that {nameof(IEventListener.OnEvent)} was called {nameof(Times.Once)}");
    }

    [Test]
    public void OnEventWhenNoListenersAreRegisteredLogsWarning()
    {
        // Arrange - Data
        List<IEventListenerRegistration> registrations = new();
        PusherEvent dummyEvent = CreateEvent("Event Name", "Channel Name", new object());

        // Arrange - Stubbing
        MockEventService.Setup(mock => mock.Registrations)
                        .Returns(registrations);

        // Act
        ClassUnderTest.OnEvent(dummyEvent);

        // Verify
        MockEventService.Verify(mock => mock.Registrations, Times.AtLeastOnce);
        MockLogger.Verify(mock => mock.Log(LogLevel.Warning, It.IsAny<string?>()), Times.AtLeastOnce);
        MockLogger.VerifyNoOtherCalls();
    }

    private static PusherEvent CreateEvent(string eventName, string channelName, object data)
    {
        Dictionary<string, object> eventData = new()
        {
            { "event", eventName },
            { "channel", channelName },
            { "data", data },
        };

        return new PusherEvent(eventData, "");
    }
}