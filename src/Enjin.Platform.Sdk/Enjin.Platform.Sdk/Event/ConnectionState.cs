using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Values representing the different states of connection for an event service.
/// </summary>
[PublicAPI]
public enum ConnectionState : ushort
{
    /// <summary>
    /// Represents that the connection is uninitialized.
    /// </summary>
    Uninitialized,

    /// <summary>
    /// Represents that the service is attempting to establish a connection.
    /// </summary>
    Connecting,

    /// <summary>
    /// Represents that the service has an established connection.
    /// </summary>
    Open,

    /// <summary>
    /// Represents that the service is closing its connection.
    /// </summary>
    Closing,

    /// <summary>
    /// Represents that the service has closed its connection.
    /// </summary>
    Closed,
}