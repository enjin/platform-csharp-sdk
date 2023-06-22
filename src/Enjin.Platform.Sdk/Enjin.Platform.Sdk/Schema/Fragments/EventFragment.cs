using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of an <see cref="Event"/> returned by the platform.
/// </summary>
[PublicAPI]
public class EventFragment : GraphQlFragment<EventFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EventFragment"/> class.
    /// </summary>
    public EventFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Event"/> is to be returned with its <see cref="Event.Phase"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public EventFragment WithPhase(bool isIncluded = true)
    {
        return WithField("phase", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Event"/> is to be returned with its <see cref="Event.Lookup"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public EventFragment WithLookup(bool isIncluded = true)
    {
        return WithField("lookUp", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Event"/> is to be returned with its <see cref="Event.ModuleId"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public EventFragment WithModuleId(bool isIncluded = true)
    {
        return WithField("moduleId", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Event"/> is to be returned with its <see cref="Event.EventId"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public EventFragment WithEventId(bool isIncluded = true)
    {
        return WithField("eventId", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="EventParam"/> fragment to be used for getting the <see cref="Event.Params"/> property
    /// of the <see cref="Event"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="EventParam"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public EventFragment WithParams(EventParamFragment? fragment)
    {
        return WithField("params", fragment);
    }
}