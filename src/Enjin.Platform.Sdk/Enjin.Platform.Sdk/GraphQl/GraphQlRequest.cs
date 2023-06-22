using System;
using System.Text;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Abstract class implementation for GraphQL requests which expect a scalar type in the response.
/// </summary>
/// <typeparam name="TRequest">The type of the request. Must extend this class.</typeparam>
[PublicAPI]
public abstract class GraphQlRequest<TRequest> : GraphQlRequestBase<TRequest>
    where TRequest : GraphQlRequest<TRequest>
{
    /// <inheritdoc/>
    protected GraphQlRequest(string name, GraphQlRequestType type) : base(name, type)
    {
    }

    #region IGraphQlCompilable

    /// <inheritdoc/>
    public override string Compile()
    {
        StringBuilder builder = new StringBuilder();

        AppendHeader(builder);

        return builder.Append(" }").ToString();
    }

    #endregion IGraphQlCompilable
}

/// <summary>
/// Abstract class implementation for GraphQL requests which expect an object type in the response.
/// </summary>
/// <typeparam name="TRequest">The type of the request. Must extend this class.</typeparam>
/// <typeparam name="TFragment">
/// The type of the fragment for selecting the fields of the response object. Must implement
/// <seealso cref="IGraphQlFragment"/>.
/// </typeparam>
[PublicAPI]
public abstract class GraphQlRequest<TRequest, TFragment> : GraphQlRequestBase<TRequest>,
                                                            IGraphQlRequest<TRequest, TFragment>
    where TRequest : GraphQlRequest<TRequest, TFragment>
    where TFragment : IGraphQlFragment
{
    private TFragment? _fragment;

    /// <summary>
    /// Whether there are any parameters from the fragment.
    /// </summary>
    private bool HasFragmentParameters => _fragment is { HasParameters: true };

    /// <summary>
    /// Whether there are any parameters exclusively from this request.
    /// </summary>
    private bool HasRequestParameters => base.HasParameters;

    /// <inheritdoc/>
    protected GraphQlRequest(string name, GraphQlRequestType type) : base(name, type)
    {
    }

    #region IGraphQlCompilable

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">
    /// Thrown if <see cref="HasFragment"/> is <c>false</c>.
    /// </exception>
    public override string Compile()
    {
        if (!HasFragment)
        {
            throw new InvalidOperationException($"Cannot compile {nameof(GraphQlRequest<TRequest, TFragment>)} with no {nameof(IGraphQlFragment)}");
        }

        StringBuilder builder = new StringBuilder();

        AppendHeader(builder);

        return builder.Append(" { ").Append(_fragment!.CompileFields()).Append(" } }").ToString();
    }

    #endregion IGraphQlCompilable

    #region IGraphQlParameterHolder

    /// <summary>
    /// Whether this request has any parameters stored in it.
    /// </summary>
    public override bool HasParameters => HasRequestParameters || HasFragmentParameters;

    /// <inheritdoc/>
    /// <summary>
    /// Compiles the parameters within this request and returns them as a string.
    /// </summary>
    /// <remarks>
    /// This method will return an empty string if neither this request nor its fragment currently hold any parameters.
    /// </remarks>
    public override string CompileParameters()
    {
        bool requestHasParams = HasRequestParameters;
        bool fragmentHasParams = HasFragmentParameters;

        if (!requestHasParams && !fragmentHasParams)
        {
            return string.Empty;
        }

        StringBuilder builder = new StringBuilder();

        if (requestHasParams && fragmentHasParams)
        {
            builder.Append(base.CompileParameters()).Append(", ").Append(_fragment!.CompileParameters());
        }
        else if (requestHasParams)
        {
            builder.Append(base.CompileParameters());
        }
        else if (fragmentHasParams)
        {
            builder.Append(_fragment!.CompileParameters());
        }

        return builder.ToString();
    }

    #endregion IGraphQlParameterHolder

    #region IGraphQlRequest

    /// <inheritdoc/>
    public virtual bool HasFragment => _fragment != null;

    /// <inheritdoc/>
    public virtual TRequest Fragment(TFragment? fragment)
    {
        _fragment = fragment;
        return (TRequest)this;
    }

    #endregion IGraphQlRequest
}