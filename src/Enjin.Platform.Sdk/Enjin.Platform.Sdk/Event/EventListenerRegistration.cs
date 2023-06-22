using System;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Implementation class for event listener registrations.
/// </summary>
[PublicAPI]
public sealed class EventListenerRegistration : IEventListenerRegistration
{
    /// <summary>
    /// Event matcher that matches for any event provided to it.
    /// </summary>
    public static readonly Func<string, bool> ALLOW_ALL_MATCHER = _ => true;

    /// <summary>
    /// Initializes a new instance of the <see cref="EventListenerRegistration"/> class.
    /// </summary>
    /// <param name="listener">The event listener.</param>
    /// <param name="matcher">The event matcher.</param>
    internal EventListenerRegistration(IEventListener listener, Func<string, bool> matcher)
    {
        Listener = listener;
        Matcher = matcher;
    }

    #region IEventListenerRegistration

    /// <inheritdoc/>
    public bool IsRegistered { get; internal set; }

    /// <inheritdoc/>
    public IEventListener Listener { get; }

    /// <inheritdoc/>
    public Func<string, bool> Matcher { get; }

    #endregion IEventListenerRegistration
}