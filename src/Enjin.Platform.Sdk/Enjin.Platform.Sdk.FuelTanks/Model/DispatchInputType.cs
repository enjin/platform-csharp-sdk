using System.Numerics;
using System;
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

    /// <summary>
    /// Assigns the Request and extracts the relevant data
    /// </summary>
    /// <param name="request">The Request object.</param>
    /// <param name="call">The call option.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchInputType SetupFromRequestObject<TRequest, TFragment>(GraphQlRequest<TRequest, TFragment> request, DispatchCall? call)
        where TRequest : GraphQlRequest<TRequest, TFragment>
        where TFragment : IGraphQlFragment

    {
        var options = new JsonSerializerOptions
        {
            Converters = { new BigIntegerConverter() }
        };

        var jsonString = JsonSerializer.Serialize(request.VariablesWithoutTypes, options);
        using var doc = JsonDocument.Parse(jsonString);
        var jsonElement = doc.RootElement;
        return SetCall(call)
            .SetQuery(request.Compile())
            .SetVariables(jsonElement);
    }
    
    class BigIntegerConverter : JsonConverter<BigInteger>
    {
        /// <inheritdoc />
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueAsString = reader.GetString() ?? string.Empty;
            return BigInteger.Parse(valueAsString);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}