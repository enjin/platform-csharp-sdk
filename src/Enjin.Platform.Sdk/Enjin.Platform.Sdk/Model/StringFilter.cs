using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for parameters that can be used to filter data.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<StringFilter>))]
[PublicAPI]
public class StringFilter : GraphQlParameter<StringFilter>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StringFilter"/> class.
    /// </summary>
    public StringFilter()
    {
    }

    /// <summary>
    /// Sets the filter type.
    /// </summary>
    /// <param name="type">The filter type.</param>
    /// <returns>This parameter for chaining.</returns>
    public StringFilter SetType(FilterType? type)
    {
        return SetParameter("type", type);
    }

    /// <summary>
    /// Sets the search term for the filter.
    /// </summary>
    /// <param name="filter">Set the search term for the filter.</param>
    /// <returns>This parameter for chaining.</returns>
    public StringFilter SetFilter(string filter)
    {
        return SetParameter("filter", filter);
    }
}