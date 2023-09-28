using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Abstract class implementation for GraphQL inputs which hold parameters.
/// </summary>
/// <typeparam name="THolder">The type of the parameter holder. Must extend this class.</typeparam>
[PublicAPI]
public abstract class GraphQlParameterHolder<THolder> : IGraphQlParameterHolder<THolder>
    where THolder : GraphQlParameterHolder<THolder>
{
    private readonly Dictionary<string, List<IGraphQlParameter>> _listedNonScalarParameters = new();
    private readonly Dictionary<string, IGraphQlParameter> _nonScalarParameters = new();
    private readonly Dictionary<string, object?> _parameters = new();
    private readonly Dictionary<string, object?> _scalarParameters = new();

    private const string ColonSeparator = ": ";
    private const string CommaSeparator = ", ";

    private static readonly JsonSerializerOptions SERIALIZER_OPTIONS = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters =
        {
            // Must use non-nullable converters
            new BigIntegerJsonConverter(),
            new DateTimeJsonConverter(),
        }
    };

    #region IGraphQlParameterHolder

    /// <inheritdoc/>
    public virtual int Count => Parameters.Count;

    /// <inheritdoc/>
    public virtual bool HasParameters => Count > 0;

    /// <inheritdoc/>
    public virtual IReadOnlyDictionary<string, object?> Parameters => _parameters;

    /// <inheritdoc/>
    public virtual string CompileParameters()
    {
        if (!HasParameters)
        {
            return string.Empty;
        }

        StringBuilder builder = new StringBuilder();

        int parameterIdx = 0;
        int parametersCount = Count;

        // Compile scalar parameters
        foreach (KeyValuePair<string, object?> p in _scalarParameters)
        {
            builder.Append(p.Key).Append(ColonSeparator).Append(JsonSerializer.Serialize(p.Value, SERIALIZER_OPTIONS));

            if (parameterIdx < parametersCount - 1)
            {
                builder.Append(CommaSeparator);
            }

            parameterIdx++;
        }

        // Compile non-scalar parameters
        foreach (KeyValuePair<string, IGraphQlParameter> p in _nonScalarParameters)
        {
            builder.Append(p.Key).Append(ColonSeparator).Append(p.Value.Compile());

            if (parameterIdx < parametersCount - 1)
            {
                builder.Append(CommaSeparator);
            }

            parameterIdx++;
        }

        // Compile lists containing non-scalar parameters
        foreach (KeyValuePair<string, List<IGraphQlParameter>> p in _listedNonScalarParameters)
        {
            builder.Append(p.Key).Append(": [ ");

            int subParameterIdx = 0;
            int subParametersCount = p.Value.Count;

            foreach (IGraphQlParameter subParameter in p.Value)
            {
                builder.Append(subParameter.Compile());

                if (subParameterIdx < subParametersCount - 1)
                {
                    builder.Append(CommaSeparator);
                }

                subParameterIdx++;
            }

            builder.Append(" ]");

            if (parameterIdx < parametersCount - 1)
            {
                builder.Append(CommaSeparator);
            }

            parameterIdx++;
        }

        return builder.ToString();
    }

    /// <inheritdoc/>
    public virtual bool HasParameter(string key)
    {
        return _parameters.ContainsKey(key);
    }

    /// <inheritdoc/>
    public virtual THolder SetParameter(string key, object? value)
    {
        _nonScalarParameters.Remove(key);
        _listedNonScalarParameters.Remove(key);

        if (value == null)
        {
            _scalarParameters.Remove(key);
            _parameters.Remove(key);
        }
        else
        {
            _scalarParameters[key] = value;
            _parameters[key] = value;
        }

        return (THolder)this;
    }

    /// <inheritdoc/>
    public virtual THolder SetParameter(string key, IGraphQlParameter? value)
    {
        _listedNonScalarParameters.Remove(key);
        _scalarParameters.Remove(key);

        if (value == null)
        {
            _nonScalarParameters.Remove(key);
            _parameters.Remove(key);
        }
        else
        {
            _nonScalarParameters[key] = value;
            _parameters[key] = value;
        }

        return (THolder)this;
    }

    /// <inheritdoc/>
    public virtual THolder SetParameter(string key, params IGraphQlParameter[]? values)
    {
        _nonScalarParameters.Remove(key);
        _scalarParameters.Remove(key);

        if (values == null)
        {
            _listedNonScalarParameters.Remove(key);
            _parameters.Remove(key);
        }
        else
        {
            List<IGraphQlParameter> value = values.ToList();
            _listedNonScalarParameters[key] = value;
            _parameters[key] = value;
        }

        return (THolder)this;
    }

    #endregion IGraphQlParameterHolder
}