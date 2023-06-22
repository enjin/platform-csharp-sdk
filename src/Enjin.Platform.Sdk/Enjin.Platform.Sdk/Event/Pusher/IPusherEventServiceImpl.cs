using System.Collections.Generic;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface to be implemented by internal Pusher event services.
/// </summary>
internal interface IPusherEventServiceImpl : IEventService
{
    /// <summary>
    /// The event listener registrations of this service.
    /// </summary>
    public IEnumerable<IEventListenerRegistration> Registrations { get; }
}