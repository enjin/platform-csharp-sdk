using System.Collections.Generic;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for GraphQL inputs which hold parameters.
/// </summary>
[PublicAPI]
public interface IGraphQlParameterHolder
{
    /// <summary>
    /// The number of parameters within this holder.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Whether this holder has any parameters stored in it.
    /// </summary>
    public bool HasParameters { get; }

    /// <summary>
    /// The parameters held by this holder.
    /// </summary>
    public IReadOnlyDictionary<string, object?> Parameters { get; }

    /// <summary>
    /// Compiles the parameters within this holder and returns them as a string.
    /// </summary>
    /// <returns>The compiled string.</returns>
    /// <remarks>
    /// This method will return an empty string if <see cref="HasParameters"/> is <c>false</c>.
    /// </remarks>
    public string CompileParameters();
}

/// <summary>
/// Interface for setting parameters for GraphQL inputs which hold parameters.
/// </summary>
/// <typeparam name="THolder">The type of the parameter holder. Must implement this interface.</typeparam>
[PublicAPI]
public interface IGraphQlParameterHolder<out THolder> : IGraphQlParameterHolder
    where THolder : IGraphQlParameterHolder<THolder>
{
    /// <summary>
    /// Sets a scalar parameter to be stored by this holder.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    /// <param name="value">The parameter value.</param>
    /// <returns>This holder for chaining.</returns>
    /// <remarks>
    /// If value is <c>null</c>, then the parameter will be removed from this holder.
    /// </remarks>
    public THolder SetParameter(string key, object? value);

    /// <summary>
    /// Sets a non-scalar parameter to be stored by this holder.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    /// <param name="value">The parameter value.</param>
    /// <returns>This holder for chaining.</returns>
    /// <remarks>
    /// If value is <c>null</c>, then the parameter will be removed from this holder.
    /// </remarks>
    public THolder SetParameter(string key, IGraphQlParameter? value);

    /// <summary>
    /// Sets a listed non-scalar parameter to be stored by this holder.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    /// <param name="values">The parameter values.</param>
    /// <returns>This holder for chaining.</returns>
    /// <remarks>
    /// If values is <c>null</c>, then the parameter will be removed from this holder.
    /// </remarks>
    public THolder SetParameter(string key, params IGraphQlParameter[]? values);
}