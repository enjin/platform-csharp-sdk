using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for acknowledging cached events and removing them from the cache.
/// </summary>
[PublicAPI]
public class AcknowledgeEvents : GraphQlRequest<AcknowledgeEvents>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcknowledgeEvents"/> class.
    /// </summary>
    public AcknowledgeEvents() : base("AcknowledgeEvents", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the event UUIDs to acknowledge.
    /// </summary>
    /// <param name="uuids">The event UUIDs.</param>
    /// <returns>This request for chaining.</returns>
    public AcknowledgeEvents SetUuids(params string[]? uuids)
    {
        return SetVariable("uuids", CoreTypes.StringArray, uuids);
    }
}