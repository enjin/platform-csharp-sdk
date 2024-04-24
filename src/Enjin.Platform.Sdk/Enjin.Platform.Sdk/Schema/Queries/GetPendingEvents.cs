using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying a list of events that were broadcasted but not yet acknowledged.
/// </summary>
/// <seealso cref="PendingEvent"/>
[PublicAPI]
public class GetPendingEvents : GraphQlRequest<GetPendingEvents, PendingEventsConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetPendingEvents"/> class.
    /// </summary>
    public GetPendingEvents() : base("GetPendingEvents", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets whether to automatically acknowledge all returned events.
    /// </summary>
    /// <param name="acknowledgeEvents">Whether to acknowledge all returned events.</param>
    /// <returns>This request for chaining.</returns>
    public GetPendingEvents SetAcknowledgeEvents(bool? acknowledgeEvents)
    {
        return SetVariable("acknowledgeEvents", CoreTypes.Boolean, acknowledgeEvents);
    }

    /// <summary>
    /// Sets any channel filters.
    /// </summary>
    /// <param name="filters">Sets any channel filters.</param>
    /// <returns>This request for chaining.</returns>
    public GetPendingEvents SetChannelFilters(StringFilterInput[]? filters)
    {
        return SetVariable("channelFilters", CoreTypes.StringFilterArray, filters);
    }
}