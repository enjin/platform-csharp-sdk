using Moq;
using NUnit.Framework;

namespace Enjin.Platform.Sdk.Tests;

[TestFixture]
public class PusherEventServiceTest
{
    private PusherEventService ClassUnderTest { get; set; }

    // Mocks
    private Mock<IPusherWrapper> MockPusher { get; set; }

    [OneTimeSetUp]
    public void BeforeAll()
    {
        MockPusher = new Mock<IPusherWrapper>();
    }

    [SetUp]
    public void BeforeEach()
    {
        MockPusher.Reset();

        // Stubbing for connect/disconnect
        MockPusher.Setup(mock => mock.ConnectAsync())
                  .Returns(Task.CompletedTask);
        MockPusher.Setup(mock => mock.DisconnectAsync())
                  .Returns(Task.CompletedTask);

        ClassUnderTest = new PusherEventService(MockPusher.Object);
    }

    [TearDown]
    public void AfterEach()
    {
        ClassUnderTest.Dispose();
    }

    [Test]
    public void ConnectAsyncWhenDisposedThrowsObjectDisposedException()
    {
        // Arrange
        ClassUnderTest.Dispose();

        // Assert
        Assert.Throws<ObjectDisposedException>(() => ClassUnderTest.ConnectAsync());
    }

    [Test]
    public void DisconnectAsyncWhenDisposedThrowsObjectDisposedException()
    {
        // Arrange
        ClassUnderTest.Dispose();

        // Assert
        Assert.Throws<ObjectDisposedException>(() => ClassUnderTest.DisconnectAsync());
    }

    [Test]
    [TestCase((object)new[] { "Event1", "Event2", "Event3", "Event4" })]
    public void RegisterListenerWhenListenerDoesNotHaveAttributeCreatesAllowAllMatcher(string[] events)
    {
        // Arrange
        IEventListener dummyListener = Mock.Of<IEventListener>();

        // Act
        Func<string, bool> matcher = ClassUnderTest.RegisterListener(dummyListener).Matcher;

        // Assert
        Assert.Multiple(() =>
        {
            foreach (string e in events)
            {
                Assert.That(matcher(e), Is.True, $"Assert event '{e}' matches as true");
            }
        });
    }

    [Test]
    [TestCase((object)new[] { "Event1", "Event2", "Event3", "Event4" })]
    public void RegisterListenerWhenListenerHasAttributeCreatesMatcherFromAttribute(string[] events)
    {
        // Arrange
        Type listenerType = typeof(EventListener);
        Type attrType = typeof(EventFilterAttribute);
        EventFilterAttribute attr = (EventFilterAttribute)System.Attribute.GetCustomAttribute(listenerType, attrType)!;
        Func<string, bool> expected = attr.Matcher;
        EventListener fakeListener = new EventListener();

        // Act
        Func<string, bool> actual = ClassUnderTest.RegisterListener(fakeListener).Matcher;

        // Assert
        Assert.Multiple(() =>
        {
            foreach (string e in events)
            {
                Assert.That(actual(e), Is.EqualTo(expected(e)), $"Assert actual equals expected for event '{e}'");
            }
        });
    }

    [Test]
    [TestCase(new[] { "Event1", "Event2" }, new[] { "Event3", "Event4" })]
    public void RegisterListenerExcludingEventsGivenEventsCreatesCorrectMatcher(string[] excluded, string[] other)
    {
        // Arrange
        IEventListener dummyListener = Mock.Of<IEventListener>();

        // Act
        Func<string, bool> matcher = ClassUnderTest.RegisterListenerExcludingEvents(dummyListener, excluded).Matcher;

        // Assert
        Assert.Multiple(() =>
        {
            foreach (string e in excluded)
            {
                Assert.That(matcher(e), Is.False, $"Assert excluded event '{e}' matches as false");
            }

            foreach (string e in other)
            {
                Assert.That(matcher(e), Is.True, $"Assert non-excluded event '{e}' matches as true");
            }
        });
    }

    [Test]
    [TestCase(new[] { "Event1", "Event2" }, new[] { "Event3", "Event4" })]
    public void RegisterListenerIncludingEventsGivenEventsCreatesCorrectMatcher(string[] included, string[] other)
    {
        // Arrange
        IEventListener dummyListener = Mock.Of<IEventListener>();

        // Act
        Func<string, bool> matcher = ClassUnderTest.RegisterListenerIncludingEvents(dummyListener, included).Matcher;

        // Assert
        Assert.Multiple(() =>
        {
            foreach (string e in included)
            {
                Assert.That(matcher(e), Is.True, $"Assert included event '{e}' matches as true");
            }

            foreach (string e in other)
            {
                Assert.That(matcher(e), Is.False, $"Assert non-included event '{e}' matches as false");
            }
        });
    }

    [Test]
    public void RegisterListenerExcludingEventsWhenListenerHasAttributeThrowsArgumentException()
    {
        // Arrange
        EventListener fakeListener = new();

        // Assert
        Assert.Throws<ArgumentException>(() => ClassUnderTest.RegisterListenerExcludingEvents(fakeListener));
    }

    [Test]
    public void RegisterListenerIncludingEventsWhenListenerHasAttributeThrowsArgumentException()
    {
        // Arrange
        EventListener fakeListener = new();

        // Assert
        Assert.Throws<ArgumentException>(() => ClassUnderTest.RegisterListenerIncludingEvents(fakeListener));
    }

    [Test]
    public void RegisterListenerWithMatcherWhenListenerHasAttributeThrowsArgumentException()
    {
        // Arrange
        EventListener fakeListener = new();
        Func<string, bool> dummyMatcher = Mock.Of<Func<string, bool>>();

        // Assert
        Assert.Throws<ArgumentException>(() => ClassUnderTest.RegisterListenerWithMatcher(fakeListener, dummyMatcher));
    }

    [Test]
    public void UnregisterAllListenersAllListenersAreUnregistered()
    {
        // Arrange
        IEventListenerRegistration registration1 = ClassUnderTest.RegisterListener(Mock.Of<IEventListener>());
        IEventListenerRegistration registration2 = ClassUnderTest.RegisterListener(Mock.Of<IEventListener>());
        IEventListenerRegistration registration3 = ClassUnderTest.RegisterListener(Mock.Of<IEventListener>());

        // Assumptions
        Assume.That(registration1.IsRegistered, Is.True,
                    $"Assume {nameof(registration1)} {nameof(IEventListenerRegistration.IsRegistered)} is true");
        Assume.That(registration2.IsRegistered, Is.True,
                    $"Assume {nameof(registration2)} {nameof(IEventListenerRegistration.IsRegistered)} is true");
        Assume.That(registration3.IsRegistered, Is.True,
                    $"Assume {nameof(registration3)} {nameof(IEventListenerRegistration.IsRegistered)} is true");

        // Act
        ClassUnderTest.UnregisterAllListeners();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(registration1.IsRegistered, Is.False,
                        $"Assert {nameof(registration1)} {nameof(IEventListenerRegistration.IsRegistered)} is false");
            Assert.That(registration2.IsRegistered, Is.False,
                        $"Assert {nameof(registration2)} {nameof(IEventListenerRegistration.IsRegistered)} is false");
            Assert.That(registration3.IsRegistered, Is.False,
                        $"Assert {nameof(registration3)} {nameof(IEventListenerRegistration.IsRegistered)} is false");
        });
    }

    [Test]
    public void UnregisterListenerWhenGivenRegisteredListenerUnregistersListener()
    {
        // Arrange
        IEventListener mockListener = Mock.Of<IEventListener>();
        IEventListenerRegistration registration = ClassUnderTest.RegisterListener(mockListener);

        // Assumptions
        Assume.That(registration.IsRegistered, Is.True, "Assume registration is active");

        // Act
        ClassUnderTest.UnregisterListener(mockListener);

        // Assert
        Assert.That(registration.IsRegistered, Is.False, "Assert registration is not active");
    }

    [EventFilter(false)]
    private class EventListener : IEventListener
    {
        public void OnEvent(PlatformEvent evt)
        {
        }
    }
}