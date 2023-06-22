using System;
using System.Threading.Tasks;
using PusherClient;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Wrapper interface for a Pusher client.
/// </summary>
/// <seealso cref="PusherClient.Pusher"/>
internal interface IPusherWrapper
{
    /// <inheritdoc cref="PusherClient.Pusher.State"/>
    public PusherClient.ConnectionState State { get; }

    /// <inheritdoc cref="PusherClient.Pusher.Connected"/>
    public event ConnectedEventHandler Connected;

    /// <inheritdoc cref="PusherClient.Pusher.ConnectionStateChanged"/>
    public event ConnectionStateChangedEventHandler ConnectionStateChanged;

    /// <inheritdoc cref="PusherClient.Pusher.Disconnected"/>
    public event ConnectedEventHandler Disconnected;

    /// <inheritdoc cref="PusherClient.Pusher.Error"/>
    public event ErrorEventHandler? Error;

    /// <inheritdoc cref="PusherClient.Pusher.Subscribed"/>
    public event SubscribedEventHandler Subscribed;

    /// <inheritdoc cref="EventEmitter.BindAll(Action{String, PusherEvent})"/>
    public void BindAll(Action<string, PusherEvent> listener);

    /// <inheritdoc cref="PusherClient.Pusher.ConnectAsync"/>
    public Task ConnectAsync();

    /// <inheritdoc cref="PusherClient.Pusher.DisconnectAsync"/>
    public Task DisconnectAsync();

    /// <inheritdoc cref="PusherClient.Pusher.SubscribeAsync(string, SubscriptionEventHandler)"/>
    public Task<Channel> SubscribeAsync(string channelName);

    /// <inheritdoc cref="PusherClient.Pusher.UnsubscribeAsync(string)"/>
    public Task UnsubscribeAsync(string channelName);

    /// <inheritdoc cref="PusherClient.Pusher.UnsubscribeAllAsync"/>
    public Task UnsubscribeAllAsync();
}