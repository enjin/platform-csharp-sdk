using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PusherClient;
using PusherConnState = PusherClient.ConnectionState;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Implementation for an event service utilizing Pusher.
/// </summary>
[PublicAPI]
public sealed class PusherEventService : IEventService
{
    private readonly PusherEventServiceImpl _impl;

    /// <summary>
    /// Initializes a new instance of the <see cref="PusherEventService"/> class with the given Pusher client.
    /// </summary>
    /// <param name="client">The wrapper for the Pusher client to be used by this service.</param>
    /// <param name="logger">The logger for the event service.</param>
    internal PusherEventService(IPusherWrapper client, ILogger? logger = null)
    {
        _impl = new PusherEventServiceImpl(client, logger);

        _impl.OnConnected += (_, args) => OnConnected?.Invoke(this, args);
        _impl.OnConnectionStateChanged += (_, state) => OnConnectionStateChanged?.Invoke(this, state);
        _impl.OnDisconnected += (_, args) => OnDisconnected?.Invoke(this, args);
        _impl.OnSubscribed += (_, s) => OnSubscribed?.Invoke(this, s);
    }

    /// <summary>
    /// Creates a builder instance to be used for creating an instance of <see cref="PusherEventService"/>.
    /// </summary>
    /// <returns>The builder instance.</returns>
    public static PusherEventServiceBuilder Builder() => new();

    #region IDisposable

    /// <inheritdoc/>
    public void Dispose()
    {
        _impl.Dispose();
    }

    #endregion IDisposable

    #region IEventService

    /// <inheritdoc/>
    public bool IsConnected => _impl.IsConnected;

    /// <inheritdoc/>
    public event EventHandler? OnConnected;

    /// <inheritdoc/>
    public event EventHandler<ConnectionState>? OnConnectionStateChanged;

    /// <inheritdoc/>
    public event EventHandler? OnDisconnected;

    /// <inheritdoc/>
    public event EventHandler<string>? OnSubscribed;

    /// <inheritdoc/>
    public Task ConnectAsync()
    {
        return _impl.ConnectAsync();
    }

    /// <inheritdoc/>
    public Task DisconnectAsync()
    {
        return _impl.DisconnectAsync();
    }

    /// <inheritdoc/>
    public IEventListenerRegistration RegisterListener(IEventListener listener)
    {
        return _impl.RegisterListener(listener);
    }

    /// <inheritdoc/>
    public IEventListenerRegistration RegisterListenerExcludingEvents(IEventListener listener, params string[] events)
    {
        return _impl.RegisterListenerExcludingEvents(listener, events);
    }

    /// <inheritdoc/>
    public IEventListenerRegistration RegisterListenerIncludingEvents(IEventListener listener, params string[] events)
    {
        return _impl.RegisterListenerIncludingEvents(listener, events);
    }

    /// <inheritdoc/>
    public IEventListenerRegistration RegisterListenerWithMatcher(IEventListener listener, Func<string, bool> matcher)
    {
        return _impl.RegisterListenerWithMatcher(listener, matcher);
    }

    /// <inheritdoc/>
    public Task SubscribeAsync(string channelName)
    {
        return _impl.SubscribeAsync(channelName);
    }

    /// <inheritdoc/>
    public void UnregisterAllListeners()
    {
        _impl.UnregisterAllListeners();
    }

    /// <inheritdoc/>
    public void UnregisterListener(IEventListener listener)
    {
        _impl.UnregisterListener(listener);
    }

    /// <inheritdoc/>
    public Task UnsubscribeAllAsync()
    {
        return _impl.UnsubscribeAllAsync();
    }

    /// <inheritdoc/>
    public Task UnsubscribeAsync(string channelName)
    {
        return _impl.UnsubscribeAsync(channelName);
    }

    #endregion IEventService

    /// <summary>
    /// The builder class for defining and creating a new instance of the <see cref="PusherEventService"/> class.
    /// </summary>
    [PublicAPI]
    public sealed class PusherEventServiceBuilder
    {
        private string? _cluster;
        private string? _host;
        private bool? _isEncrypted;
        private string? _key;
        private ILogger? _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PusherEventServiceBuilder"/> class.
        /// </summary>
        internal PusherEventServiceBuilder()
        {
        }

        /// <summary>
        /// Builds an instance of <see cref="PusherEventService"/> using the set parameters.
        /// </summary>
        /// <returns>The service instance.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the key is <c>null</c> or if both the host and cluster are set at the time this method is called.
        /// </exception>
        /// <remarks>
        /// If host is not set, then the service will default to <c>ws-{cluster}.pusher.com</c> and if the cluster is
        /// not set, then the cluster will default to <c>mt1</c>. If encryption is not set, then encryption will default
        /// to <c>true</c>.
        /// </remarks>
        public PusherEventService Build()
        {
            if (_key == null)
            {
                throw new InvalidOperationException($"Cannot build {nameof(PusherEventService)} without an app key");
            }

            if (_host != null && _cluster != null)
            {
                throw new InvalidOperationException("Cannot specify both cluster and host for Pusher options");
            }

            PusherOptions options = new PusherOptions
            {
                Encrypted = _isEncrypted ?? true,
            };

            if (_host != null)
            {
                options.Host = _host;
            }
            else if (_cluster != null)
            {
                options.Cluster = _cluster;
            }

            return new PusherEventService(new PusherWrapper(_key, options), _logger);
        }

        /// <summary>
        /// Sets the cluster to be used within the Pusher network.
        /// </summary>
        /// <param name="cluster">The cluster.</param>
        /// <returns>This builder for chaining.</returns>
        public PusherEventServiceBuilder SetCluster(string? cluster)
        {
            _cluster = cluster;
            return this;
        }

        /// <summary>
        /// Sets whether to use encryption for sending and receiving messages..
        /// </summary>
        /// <param name="isEncrypted">Whether to use encryption.</param>
        /// <returns>This builder for chaining.</returns>
        public PusherEventServiceBuilder SetEncrypted(bool isEncrypted)
        {
            _isEncrypted = isEncrypted;
            return this;
        }

        /// <summary>
        /// Sets the Pusher host.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <returns>This builder for chaining.</returns>
        public PusherEventServiceBuilder SetHost(string? host)
        {
            _host = host;
            return this;
        }

        /// <summary>
        /// Sets the key of the application on the Pusher network.
        /// </summary>
        /// <param name="key">The application key.</param>
        /// <returns>This builder for chaining.</returns>
        public PusherEventServiceBuilder SetKey(string key)
        {
            _key = key;
            return this;
        }

        /// <summary>
        /// Sets the logger for the event service to use.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <returns>This builder for chaining.</returns>
        public PusherEventServiceBuilder SetLogger(ILogger? logger)
        {
            _logger = logger;
            return this;
        }
    }

    /// <summary>
    /// Implementation class for <see cref="PusherEventService"/>.
    /// </summary>
    private class PusherEventServiceImpl : IPusherEventServiceImpl
    {
        private readonly IPusherWrapper _client;
        private readonly List<EventListenerRegistration> _registrations = new();

        // Mutexes
        private readonly object _disposeMutex = new();
        private readonly object _registrationsMutex = new();

        /// <summary>
        /// Internal property representing whether this event service has been disposed.
        /// </summary>
        private bool IsDisposed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PusherEventServiceImpl"/> class with the given Pusher client.
        /// </summary>
        /// <param name="client">The wrapper for the Pusher client.</param>
        /// <param name="logger">The logger for the event service.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if client is <c>null</c>.
        /// </exception>
        internal PusherEventServiceImpl(IPusherWrapper client, ILogger? logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));

            PusherListener listener = new PusherListener(this, logger);
            _client.BindAll((_, evt) => listener.OnEvent(evt));

            _client.Connected += _ => OnConnected?.Invoke(this, EventArgs.Empty);
            _client.ConnectionStateChanged += (_, state) => OnConnectionStateChanged?.Invoke(this, state switch
            {
                PusherConnState.Uninitialized => ConnectionState.Uninitialized,
                PusherConnState.Connecting => ConnectionState.Connecting,
                PusherConnState.Connected => ConnectionState.Open,
                PusherConnState.Disconnecting => ConnectionState.Closing,
                PusherConnState.Disconnected => ConnectionState.Closed,
                PusherConnState.WaitingToReconnect => ConnectionState.Connecting,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            });
            _client.Disconnected += _ => OnDisconnected?.Invoke(this, EventArgs.Empty);
            _client.Subscribed += (_, channel) => OnSubscribed?.Invoke(this, channel.Name);

            if (logger != null)
            {
                _client.Error += (_, e) => logger.Log(LogLevel.Error, e, $"Error in {nameof(PusherEventService)}");
            }
        }

        /// <summary>
        /// Helper method for registering a listener for this service that is configured to filter for events against
        /// the given matcher.
        /// </summary>
        /// <param name="listener">The listener.</param>
        /// <param name="matcher">The event matcher.</param>
        /// <returns>The registration for the listener.</returns>
        private IEventListenerRegistration RegisterListener(IEventListener listener, Func<string, bool> matcher)
        {
            lock (_registrationsMutex)
            {
                UnregisterListenerImpl(listener);

                EventListenerRegistration registration = new EventListenerRegistration(listener, matcher);
                _registrations.Add(registration);
                registration.IsRegistered = true;

                return registration;
            }
        }

        /// <summary>
        /// Implementation of the method for unregistering listeners. Only call this after acquiring the lock for
        /// <see cref="_registrationsMutex"/>.
        /// </summary>
        /// <param name="listener">The listener.</param>
        private void UnregisterListenerImpl(IEventListener listener)
        {
            for (int i = _registrations.Count - 1; i >= 0; i--)
            {
                EventListenerRegistration registration = _registrations[i];

                if (!ReferenceEquals(registration.Listener, listener))
                {
                    continue;
                }

                _registrations.RemoveAt(i);
                registration.IsRegistered = false;
            }
        }

        /// <summary>
        /// Gets the <see cref="EventFilterAttribute"/> attached to the class of the given listener.
        /// </summary>
        /// <param name="listener">The listener.</param>
        /// <param name="attribute">Out reference of the <see cref="EventFilterAttribute"/>.</param>
        /// <returns>Whether a <see cref="EventFilterAttribute"/> was retrieved.</returns>
        private static bool GetFilterAttribute(IEventListener listener, out EventFilterAttribute attribute)
        {
            Type listenerType = listener.GetType();
            Type attributeType = typeof(EventFilterAttribute);
            attribute = (EventFilterAttribute)System.Attribute.GetCustomAttribute(listenerType, attributeType);

            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            return attribute != null;
        }

        #region IDisposable

        /// <inheritdoc/>
        public void Dispose()
        {
            lock (_disposeMutex)
            {
                if (IsDisposed)
                {
                    return;
                }

                _client.DisconnectAsync().Wait();
                IsDisposed = true;
            }
        }

        #endregion IDisposable

        #region IEventService

        /// <inheritdoc/>
        public bool IsConnected => _client.State == PusherConnState.Connected;

        /// <inheritdoc/>
        public event EventHandler? OnConnected;

        /// <inheritdoc/>
        public event EventHandler<ConnectionState>? OnConnectionStateChanged;

        /// <inheritdoc/>
        public event EventHandler? OnDisconnected;

        /// <inheritdoc/>
        public event EventHandler<string>? OnSubscribed;

        /// <inheritdoc/>
        public Task ConnectAsync()
        {
            lock (_disposeMutex)
            {
                if (IsDisposed)
                {
                    throw new ObjectDisposedException(nameof(PusherEventService));
                }
            }

            return _client.ConnectAsync();
        }

        /// <inheritdoc/>
        public Task DisconnectAsync()
        {
            lock (_disposeMutex)
            {
                if (IsDisposed)
                {
                    throw new ObjectDisposedException(nameof(PusherEventService));
                }
            }

            return _client.DisconnectAsync();
        }

        /// <inheritdoc/>
        public IEventListenerRegistration RegisterListener(IEventListener listener)
        {
            if (GetFilterAttribute(listener, out EventFilterAttribute attribute))
            {
                return RegisterListener(listener, attribute.Matcher);
            }

            return RegisterListener(listener, EventListenerRegistration.ALLOW_ALL_MATCHER);
        }

        /// <inheritdoc/>
        public IEventListenerRegistration RegisterListenerExcludingEvents(IEventListener listener,
                                                                          params string[] events)
        {
            if (GetFilterAttribute(listener, out EventFilterAttribute _))
            {
                throw new ArgumentException("Event listener cannot have filter attribute when excluding events");
            }

            return RegisterListener(listener, s => events.All(s.NotEquals));
        }

        /// <inheritdoc/>
        public IEventListenerRegistration RegisterListenerIncludingEvents(IEventListener listener,
                                                                          params string[] events)
        {
            if (GetFilterAttribute(listener, out EventFilterAttribute _))
            {
                throw new ArgumentException("Event listener cannot have filter attribute when including events");
            }

            return RegisterListener(listener, s => events.Any(s.Equals));
        }

        /// <inheritdoc/>
        public IEventListenerRegistration RegisterListenerWithMatcher(IEventListener listener,
                                                                      Func<string, bool> matcher)
        {
            if (GetFilterAttribute(listener, out EventFilterAttribute _))
            {
                throw new ArgumentException("Event listener cannot have filter attribute when using an event matcher");
            }

            return RegisterListener(listener, matcher);
        }

        /// <inheritdoc/>
        public Task SubscribeAsync(string channelName)
        {
            return _client.SubscribeAsync(channelName);
        }

        /// <inheritdoc/>
        public void UnregisterAllListeners()
        {
            lock (_registrationsMutex)
            {
                _registrations.Do(r => r.IsRegistered = false);
                _registrations.Clear();
            }
        }

        /// <inheritdoc/>
        public void UnregisterListener(IEventListener listener)
        {
            lock (_registrationsMutex)
            {
                UnregisterListenerImpl(listener);
            }
        }

        /// <inheritdoc/>
        public Task UnsubscribeAllAsync()
        {
            return _client.UnsubscribeAllAsync();
        }

        /// <inheritdoc/>
        public Task UnsubscribeAsync(string channelName)
        {
            return _client.UnsubscribeAsync(channelName);
        }

        #endregion IEventService

        #region IPusherEventServiceImpl

        /// <inheritdoc/>
        public IReadOnlyCollection<IEventListenerRegistration> Registrations
        {
            get
            {
                lock (_registrationsMutex)
                {
                    return _registrations.ToList();
                }
            }
        }

        #endregion IPusherEventServiceImpl
    }
}