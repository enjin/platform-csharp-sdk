using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for parameters that can be used to filter data.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<StringFilterInput>))]
[PublicAPI]
public class StringFilterInput : GraphQlParameter<StringFilterInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StringFilterInput"/> class.
    /// </summary>
    public StringFilterInput()
    {
    }

    /// <summary>
    /// Sets the filter type.
    /// </summary>
    /// <param name="type">The filter type.</param>
    /// <returns>This parameter for chaining.</returns>
    public StringFilterInput SetType(FilterType? type)
    {
        return SetParameter("type", type);
    }

    /// <summary>
    /// Sets the search term for the filter.
    /// </summary>
    /// <param name="filter">Set the search term for the filter.</param>
    /// <returns>This parameter for chaining.</returns>
    public StringFilterInput SetFilter(string filter)
    {
        return SetParameter("filter", filter);
    }
}