using System;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface to be implemented by event listener registrations.
/// </summary>
[PublicAPI]
public interface IEventListenerRegistration
{
    /// <summary>
    /// Whether this registration is still an active registration in its event service.
    /// </summary>
    public bool IsRegistered { get; }

    /// <summary>
    /// The event listener for this registration.
    /// </summary>
    public IEventListener Listener { get; }

    /// <summary>
    /// The event matcher for this registration.
    /// </summary>
    public Func<string, bool> Matcher { get; }
}