using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Abstract base class for GraphQL requests to extend from.
/// </summary>
/// <typeparam name="TRequest">The type of the request. Must extend this class.</typeparam>
[PublicAPI]
public abstract class GraphQlRequestBase<TRequest> : GraphQlParameterHolder<TRequest>, IGraphQlRequest<TRequest>
    where TRequest : GraphQlRequestBase<TRequest>
{
    private readonly string _resultHeader;
    private readonly string _typeName;
    private readonly Dictionary<string, Tuple<string, object?>> _variables = new();
    private readonly Dictionary<string, object?> _variablesWithoutTypes = new();

    private const string ColonSeparator = ": ";
    private const string CommaSeparator = ", ";

    /// <summary>
    /// Base constructor to be used by GraphQL requests.
    /// </summary>
    /// <param name="name">The name of the request.</param>
    /// <param name="type">The type of the request.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if type is not <see cref="GraphQlRequestType.Query"/> or <see cref="GraphQlRequestType.Mutation"/>.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown if name is <c>null</c>.
    /// </exception>
    protected GraphQlRequestBase(string name, GraphQlRequestType type)
    {
        _resultHeader = " { result: " + name;
        _typeName = type switch
        {
            GraphQlRequestType.Query => "query",
            GraphQlRequestType.Mutation => "mutation",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        Name = name ?? throw new ArgumentNullException(nameof(name));
        Type = type;
    }

    /// <summary>
    /// Appends the necessary beginning portion for the compiled request to the given builder, leaving only the closing
    /// brace and any fragment fields to be appended.
    /// </summary>
    /// <param name="builder">The string builder to append to.</param>
    protected void AppendHeader(StringBuilder builder)
    {
        builder.Append(_typeName);
        AppendVariables(builder);

        builder.Append(_resultHeader);
        AppendParameters(builder);
    }

    /// <summary>
    /// Appends any parameters to the <see cref="StringBuilder"/> being used to build the request header.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/>.</param>
    private void AppendParameters(StringBuilder builder)
    {
        bool hasVariables = HasVariables;
        bool hasParameters = HasParameters;

        if (!hasVariables && !hasParameters)
        {
            return;
        }

        builder.Append("(");

        if (hasVariables)
        {
            int i = 0;
            int count = Variables.Count;
            foreach (KeyValuePair<string, Tuple<string, object?>> v in Variables)
            {
                builder.Append(v.Key).Append(ColonSeparator).Append("$").Append(v.Key);

                if (i < count - 1)
                {
                    builder.Append(CommaSeparator);
                }

                i++;
            }

            if (hasParameters)
            {
                builder.Append(CommaSeparator);
            }
        }

        if (hasParameters)
        {
            builder.Append(CompileParameters());
        }

        builder.Append(")");
    }

    /// <summary>
    /// Appends any variables to the <see cref="StringBuilder"/> being used to build the request header.
    /// </summary>
    /// <param name="builder">The <see cref="StringBuilder"/>.</param>
    private void AppendVariables(StringBuilder builder)
    {
        if (!HasVariables)
        {
            return;
        }

        builder.Append(" (");

        int i = 0;
        int count = Variables.Count;
        foreach (KeyValuePair<string, Tuple<string, object?>> v in Variables)
        {
            builder.Append("$").Append(v.Key).Append(ColonSeparator).Append(v.Value.Item1);

            if (i < count - 1)
            {
                builder.Append(CommaSeparator);
            }

            i++;
        }

        builder.Append(")");
    }

    #region IGraphQlCompilable

    /// <inheritdoc/>
    public abstract string Compile();

    #endregion IGraphQlCompilable

    #region IGraphQlRequest

    /// <inheritdoc/>
    public virtual bool HasVariables => Variables.Count > 0;

    /// <inheritdoc/>
    public virtual string Name { get; }

    /// <inheritdoc/>
    public virtual IReadOnlyDictionary<string, Tuple<string, object?>> Variables => _variables;

    /// <inheritdoc/>
    public virtual IReadOnlyDictionary<string, object?> VariablesWithoutTypes => _variablesWithoutTypes;

    /// <inheritdoc/>
    public virtual GraphQlRequestType Type { get; }

    /// <inheritdoc/>
    public virtual bool HasVariable(string name)
    {
        return _variables.ContainsKey(name);
    }

    /// <inheritdoc/>
    public virtual TRequest SetVariable(string name, string type, object? value)
    {
        if (value == null)
        {
            _variables.Remove(name);
            _variablesWithoutTypes.Remove(name);
        }
        else
        {
            _variables[name] = new Tuple<string, object?>(type, value);
            _variablesWithoutTypes[name] = value;
        }

        return (TRequest)this;
    }

    #endregion IGraphQlRequest
}