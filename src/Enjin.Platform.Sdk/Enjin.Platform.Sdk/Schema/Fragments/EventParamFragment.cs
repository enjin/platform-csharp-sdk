using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of an <see cref="EventParam"/> returned by the platform.
/// </summary>
[PublicAPI]
public class EventParamFragment : GraphQlFragment<EventParamFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EventParamFragment"/> class.
    /// </summary>
    public EventParamFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="EventParam"/> is to be returned with its <see cref="EventParam.Type"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public EventParamFragment WithType(bool isIncluded = true)
    {
        return WithField("type", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="EventParam"/> is to be returned with its <see cref="EventParam.Value"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public EventParamFragment WithValue(bool isIncluded = true)
    {
        return WithField("value", isIncluded);
    }
}