using System;
using System.Linq;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Represents a filter to be used by types implementing <see cref="IEventListener"/> as a means of filtering events
/// broadcasted by the platform.
/// </summary>
/// <seealso cref="IEventListener"/>
[PublicAPI]
[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
public sealed class EventFilterAttribute : System.Attribute
{
    private readonly string[] _events;
    private readonly bool _isAllowed;
    private Func<string, bool>? _matcher;

    /// <summary>
    /// Represents the matcher for this attribute.
    /// </summary>
    public Func<string, bool> Matcher => _matcher ??= CreateEventMatcher();

    /// <summary>
    /// Initializes a new instance of the <see cref="EventFilterAttribute"/> class.
    /// </summary>
    /// <param name="isAllowed">Whether the events are allowed.</param>
    /// <param name="events">The events.</param>
    public EventFilterAttribute(bool isAllowed, params string[] events)
    {
        _isAllowed = isAllowed;
        _events = events;
    }

    /// <summary>
    /// Creates an event matcher that allows or disallows the events specified for this attribute.
    /// </summary>
    /// <returns>The event matcher.</returns>
    private Func<string, bool> CreateEventMatcher()
    {
        return _isAllowed
            ? evt => _events.Any(evt.Equals)
            : evt => _events.All(evt.NotEquals);
    }
}