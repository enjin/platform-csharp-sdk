using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Models a parameter for a dispatch call.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<DispatchInputType>))]
[PublicAPI]
public class DispatchInputType : GraphQlParameter<DispatchInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DispatchInputType"/> class.
    /// </summary>
    public DispatchInputType()
    {
    }

    /// <summary>
    /// Sets the dispatch call options.
    /// </summary>
    /// <param name="call">The call option.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchInputType SetCall(DispatchCall? call)
    {
        return SetParameter("call", call);
    }

    /// <summary>
    /// Sets the GraphQL query required to query the 'id' and 'encodedData' from the result.
    /// </summary>
    /// <param name="query">The GraphQL query.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchInputType SetQuery(string? query)
    {
        return SetParameter("query", query);
    }

    /// <summary>
    /// Sets the GraphQL query variables.
    /// </summary>
    /// <param name="variables">The GraphQL variables.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchInputType SetVariables(JsonElement? variables)
    {
        return SetParameter("variables", variables);
    }
}