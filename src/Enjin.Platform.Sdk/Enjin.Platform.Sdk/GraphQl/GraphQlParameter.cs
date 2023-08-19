using System;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Abstract class implementation for complex GraphQL parameters.
/// </summary>
/// <typeparam name="TParameter">The parameter type. Must extend this class.</typeparam>
[PublicAPI]
public abstract class GraphQlParameter<TParameter> : GraphQlParameterHolder<TParameter>, IGraphQlParameter<TParameter>
    where TParameter : GraphQlParameter<TParameter>
{
    #region IGraphQlCompilable

    /// <inheritdoc/>
    public string Compile()
    {
        if (!HasParameters)
        {
            return "{ }";
        }

        StringBuilder builder = new StringBuilder().Append("{ ").Append(CompileParameters()).Append(" }");
        return builder.ToString();
    }

    #endregion IGraphQlCompilable

    #region IGraphQlParameterHolder

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">
    /// Thrown if parameter is this instance.
    /// </exception>
    public new TParameter SetParameter(string key, IGraphQlParameter? value)
    {
        if (ReferenceEquals(this, value))
        {
            throw new ArgumentException($"{nameof(value)} cannot be this instance");
        }

        return base.SetParameter(key, value);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">
    /// Thrown if parameters contains this instance.
    /// </exception>
    public new TParameter SetParameter(string key, params IGraphQlParameter[]? values)
    {
        if (values != null && values.Any(p => ReferenceEquals(this, p)))
        {
            throw new ArgumentException($"{nameof(values)} cannot contain this instance");
        }

        return base.SetParameter(key, values);
    }

    #endregion IGraphQlParameterHolder
}