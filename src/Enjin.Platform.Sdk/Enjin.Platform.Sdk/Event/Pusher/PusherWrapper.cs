using System;
using System.Threading.Tasks;
using PusherClient;

namespace Enjin.Platform.Sdk;

///
/// <summary>
/// Wrapper class for a Pusher client to be used in a <see cref="PusherEventService"/>.
/// </summary>
/// <seealso cref="PusherClient.Pusher"/>
internal class PusherWrapper : IPusherWrapper
{
    private readonly Pusher _client;

    /// <inheritdoc cref="PusherClient.Pusher(string, PusherOptions)"/>
    public PusherWrapper(string key, PusherOptions options)
    {
        _client = new Pusher(key, options);

        _client.Connected += ClientOnConnected;
        _client.ConnectionStateChanged += ClientOnConnectionStateChanged;
        _client.Disconnected += ClientOnDisconnected;
        _client.Error += ClientOnError;
        _client.Subscribed += ClientOnSubscribed;
    }

    void ClientOnSubscribed(object sender, Channel channel)
    {
        Subscribed?.Invoke(sender, channel);
    }

    void ClientOnError(object sender, PusherException error)
    {
        Error?.Invoke(sender, error);
    }

    void ClientOnConnected(object sender)
    {
        Connected?.Invoke(sender);
    }

    void ClientOnDisconnected(object sender)
    {
        Disconnected?.Invoke(sender);
    }

    void ClientOnConnectionStateChanged(object sender, PusherClient.ConnectionState state)
    {
        ConnectionStateChanged?.Invoke(sender, state);
    }

    #region IPusherWrapper

    /// <inheritdoc/>
    public PusherClient.ConnectionState State => _client.State;

    /// <inheritdoc/>
    public event ConnectedEventHandler? Connected;

    /// <inheritdoc/>
    public event ConnectionStateChangedEventHandler? ConnectionStateChanged;

    /// <inheritdoc/>
    public event ConnectedEventHandler? Disconnected;

    /// <inheritdoc/>
    public event ErrorEventHandler? Error;

    /// <inheritdoc/>
    public event SubscribedEventHandler? Subscribed;

    /// <inheritdoc/>
    public void BindAll(Action<string, PusherEvent> listener) => _client.BindAll(listener);

    /// <inheritdoc/>
    public Task ConnectAsync() => _client.ConnectAsync();

    /// <inheritdoc/>
    public Task DisconnectAsync() => _client.DisconnectAsync();

    /// <inheritdoc/>
    public Task<Channel> SubscribeAsync(string channelName) => _client.SubscribeAsync(channelName);

    /// <inheritdoc/>
    public Task UnsubscribeAllAsync() => _client.UnsubscribeAllAsync();

    /// <inheritdoc/>
    public Task UnsubscribeAsync(string channelName) => _client.UnsubscribeAsync(channelName);

    #endregion IPusherWrapper
}
