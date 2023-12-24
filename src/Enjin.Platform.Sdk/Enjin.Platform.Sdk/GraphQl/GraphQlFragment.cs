using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Abstract class implementation for GraphQL fragments to extend from.
/// </summary>
/// <typeparam name="TFragment">The fragment type. Must extend this class.</typeparam>
[PublicAPI]
public abstract class GraphQlFragment<TFragment> : GraphQlParameterHolder<TFragment>,
                                                   IGraphQlFragment<TFragment>
    where TFragment : GraphQlFragment<TFragment>
{
    private readonly Dictionary<string, IGraphQlFragment> _fragmentFields = new();
    private readonly HashSet<string> _scalarFields = new();

    #region IGraphQlCompilable

    /// <inheritdoc/>
    /// <summary>
    /// Compiles the parameters and fields of this fragment.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown if called while <see cref="HasFields"/> is <c>false</c>.
    /// </exception>
    public virtual string Compile()
    {
        StringBuilder builder = new StringBuilder();

        if (HasParameters)
        {
            builder.Append("(").Append(CompileParameters()).Append(") ");
        }

        if (HasFields)
        {
            return builder.Append("{ ").Append(CompileFields()).Append(" }").ToString();
        }
        else
        {
            return builder.ToString();
        }
    }

    #endregion IGraphQlCompilable

    #region IGraphQlFragment

    /// <inheritdoc/>
    public virtual bool HasFields => _scalarFields.Any() || _fragmentFields.Any();

    /// <inheritdoc/>
    public virtual string CompileFields()
    {
        int i = 0;
        int count = _scalarFields.Count + _fragmentFields.Count;
        StringBuilder builder = new StringBuilder();

        // Append scalar fields
        foreach (string field in _scalarFields)
        {
            builder.Append(field);

            if (i < count - 1)
            {
                builder.Append(" ");
            }

            i++;
        }

        // Append fragment fields
        foreach (KeyValuePair<string, IGraphQlFragment> kv in _fragmentFields)
        {
            builder.Append(kv.Key);

            // Adds a space between the field name and compiled body when it has no parameters (purely for formatting)
            if (!kv.Value.HasParameters)
            {
                builder.Append(" ");
            }

            builder.Append(kv.Value.Compile());

            if (i < count - 1)
            {
                builder.Append(" ");
            }

            i++;
        }

        return builder.ToString();
    }

    /// <inheritdoc/>
    public virtual bool HasField(string name)
    {
        return _scalarFields.Contains(name) || _fragmentFields.ContainsKey(name);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Calling this method will remove any fragment field of the same name and if isIncluded is <c>false</c>, then this
    /// method will exclude any field of the same name.
    /// </remarks>
    public virtual TFragment WithField(string name, bool isIncluded)
    {
        // Remove any fragment fields of the same name
        _fragmentFields.Remove(name);

        if (isIncluded)
        {
            _scalarFields.Add(name);
        }
        else
        {
            _scalarFields.Remove(name);
        }

        return (TFragment)this;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">
    /// Thrown if fragment is this instance.
    /// </exception>
    /// <remarks>
    /// Calling this method will remove any scalar field of the same name and if fragment is <c>null</c>, then this
    /// method will exclude any field of the same name.
    /// </remarks>
    public virtual TFragment WithField(string name, IGraphQlFragment? fragment)
    {
        if (ReferenceEquals(this, fragment))
        {
            throw new ArgumentException($"{nameof(fragment)} cannot be this instance");
        }

        // Remove any non-fragment fields of the same name
        _scalarFields.Remove(name);

        if (fragment == null)
        {
            _fragmentFields.Remove(name);
        }
        else
        {
            _fragmentFields.Add(name, fragment);
        }

        return (TFragment)this;
    }

    #endregion IGraphQlFragment
}