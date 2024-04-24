using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="PendingEvent"/> returned by the platform.
/// </summary>
[PublicAPI]
public class PendingEventFragment : GraphQlFragment<PendingEventFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PendingEventFragment"/> class.
    /// </summary>
    public PendingEventFragment()
    {
    }
    
    /// <summary>
    /// Sets whether the <see cref="PendingEvent"/> is to be returned with its <see cref="PendingEvent.Id"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PendingEventFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="PendingEvent"/> is to be returned with its <see cref="PendingEvent.Uuid"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PendingEventFragment WithUuid(bool isIncluded = true)
    {
        return WithField("uuid", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="PendingEvent"/> is to be returned with its <see cref="PendingEvent.Name"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PendingEventFragment WithName(bool isIncluded = true)
    {
        return WithField("name", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="PendingEvent"/> is to be returned with its <see cref="PendingEvent.Sent"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PendingEventFragment WithSent(bool isIncluded = true)
    {
        return WithField("sent", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="PendingEvent"/> is to be returned with its <see cref="PendingEvent.Channels"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PendingEventFragment WithChannels(bool isIncluded = true)
    {
        return WithField("channels", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="PendingEvent"/> is to be returned with its <see cref="PendingEvent.Data"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PendingEventFragment WithData(bool isIncluded = true)
    {
        return WithField("data", isIncluded);
    }
}