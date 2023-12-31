﻿using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying a list of events that were broadcasted but not yet acknowledged.
/// </summary>
/// <seealso cref="PendingEvents"/>
[PublicAPI]
public class GetPendingEvents : GraphQlRequest<GetPendingEvents, PendingEventsFragment>
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
}