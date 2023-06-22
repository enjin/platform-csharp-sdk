using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface to be implemented by platform event services for registering listeners and subscribing for events.
/// </summary>
/// <seealso cref="IEventListener"/>
[PublicAPI]
public interface IEventService : IDisposable
{
    /// <summary>
    /// Whether this service is connected and may receive events.
    /// </summary>
    public bool IsConnected { get; }

    /// <summary>
    /// Event for when this service is connected.
    /// </summary>
    public event EventHandler OnConnected;

    /// <summary>
    /// Event for when the connection state of this service changes.
    /// </summary>
    public event EventHandler<ConnectionState> OnConnectionStateChanged;

    /// <summary>
    /// Event for when this service is disconnected.
    /// </summary>
    public event EventHandler OnDisconnected;

    /// <summary>
    /// Event for when this service is subscribed to an event channel.
    /// </summary>
    public event EventHandler<string> OnSubscribed;

    /// <summary>
    /// Connects this service asynchronously to receive events.
    /// </summary>
    /// <returns>The task for this operation.</returns>
    public Task ConnectAsync();

    /// <summary>
    /// Disconnects this service asynchronously to stop receiving events.
    /// </summary>
    /// <returns>The task for this operation.</returns>
    public Task DisconnectAsync();

    /// <summary>
    /// Registers a listener for this service.
    /// </summary>
    /// <param name="listener">The listener.</param>
    /// <returns>The registration for the listener.</returns>
    /// <remarks>
    /// If listener does not have <see cref="EventFilterAttribute"/> attached to it then no filtering will occur and it
    /// will receive every event from the platform detected by this service.
    /// </remarks>
    public IEventListenerRegistration RegisterListener(IEventListener listener);

    /// <summary>
    /// Registers a listener for this service that is configured to filter for the specified events.
    /// </summary>
    /// <param name="listener">The listener.</param>
    /// <param name="events">The events to filter for.</param>
    /// <returns>The registration for the listener.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <see cref="EventFilterAttribute"/> is attached to listener.
    /// </exception>
    public IEventListenerRegistration RegisterListenerExcludingEvents(IEventListener listener, params string[] events);

    /// <summary>
    /// Registers a listener for this service that is configured to filter out the specified events.
    /// </summary>
    /// <param name="listener">The listener.</param>
    /// <param name="events">The events to filter out.</param>
    /// <returns>The registration for the listener.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <see cref="EventFilterAttribute"/> is attached to listener.
    /// </exception>
    public IEventListenerRegistration RegisterListenerIncludingEvents(IEventListener listener, params string[] events);

    /// <summary>
    /// Registers a listener for this service that is configured to filter for events against the given matcher.
    /// </summary>
    /// <param name="listener">The listener.</param>
    /// <param name="matcher">The event matcher.</param>
    /// <returns>The registration for the listener.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <see cref="EventFilterAttribute"/> is attached to listener.
    /// </exception>
    public IEventListenerRegistration RegisterListenerWithMatcher(IEventListener listener, Func<string, bool> matcher);

    /// <summary>
    /// Subscribes this service to the given event channel asynchronously.
    /// </summary>
    /// <param name="channelName">The name of the event channel.</param>
    /// <returns>The task for this operation.</returns>
    public Task SubscribeAsync(string channelName);

    /// <summary>
    /// Unregisters all listeners from this service.
    /// </summary>
    public void UnregisterAllListeners();

    /// <summary>
    /// Unregisters the given listener from this service.
    /// </summary>
    /// <param name="listener">The listener.</param>
    public void UnregisterListener(IEventListener listener);

    /// <summary>
    /// Unsubscribes this service from all subscribed channels asynchronously.
    /// </summary>
    /// <returns>The task for this operation.</returns>
    public Task UnsubscribeAllAsync();

    /// <summary>
    /// Unsubscribes this service from the given event channel asynchronously.
    /// </summary>
    /// <param name="channelName">The name of the event channel.</param>
    /// <returns>The task for this operation.</returns>
    public Task UnsubscribeAsync(string channelName);
}