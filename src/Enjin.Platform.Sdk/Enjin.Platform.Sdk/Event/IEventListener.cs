using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface to be implemented by event listeners for receiving a <see cref="PlatformEvent"/> from an event service.
/// </summary>
/// <seealso cref="IEventService"/>
[PublicAPI]
public interface IEventListener
{
    /// <summary>
    /// Method to be called by an event service when an event has been received from the platform.
    /// </summary>
    /// <param name="evt">The <see cref="PlatformEvent"/>.</param>
    public void OnEvent(PlatformEvent evt);
}