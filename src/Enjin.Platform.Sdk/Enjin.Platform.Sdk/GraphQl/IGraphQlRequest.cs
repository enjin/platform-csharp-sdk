using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for GraphQL requests.
/// </summary>
/// <seealso cref="IGraphQlRequest{TRequest}"/>
/// <seealso cref="IGraphQlRequest{TRequest, TFragment}"/>
[PublicAPI]
public interface IGraphQlRequest : IGraphQlCompilable
{
    /// <summary>
    /// Whether this request has variables.
    /// </summary>
    public bool HasVariables { get; }

    /// <summary>
    /// The name of this request.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The variables mapping for this request.
    /// </summary>
    public IReadOnlyDictionary<string, Tuple<string, object?>> Variables { get; }

    /// <summary>
    /// The variables mapping for this request without their types.
    /// </summary>
    public IReadOnlyDictionary<string, object?> VariablesWithoutTypes { get; }

    /// <summary>
    /// The type of this request.
    /// </summary>
    public GraphQlRequestType Type { get; }
}

/// <summary>
/// Interface for GraphQL requests with a settable variables for the operation.
/// </summary>
/// <typeparam name="TRequest">The type of the request. Must implement this interface.</typeparam>
/// <seealso cref="IGraphQlRequest{TRequest, TFragment}"/>
[PublicAPI]
public interface IGraphQlRequest<out TRequest> : IGraphQlRequest
    where TRequest : IGraphQlRequest<TRequest>
{
    /// <summary>
    /// Sets a variable for this request.
    /// </summary>
    /// <param name="name">The variable name.</param>
    /// <param name="type">The variable type.</param>
    /// <param name="value">The variable value.</param>
    /// <returns>This request for chaining.</returns>
    public TRequest SetVariable(string name, string type, object? value);
}

/// <summary>
/// Interface for GraphQL requests with a settable fragment for response data.
/// </summary>
/// <typeparam name="TRequest">The type of the request. Must implement this interface.</typeparam>
/// <typeparam name="TFragment">
/// The type of the fragment. Must implement <seealso cref="IGraphQlFragment"/>
/// </typeparam>
/// <seealso cref="IGraphQlRequest{TRequest}"/>
[PublicAPI]
public interface IGraphQlRequest<out TRequest, in TFragment> : IGraphQlRequest<TRequest>
    where TRequest : IGraphQlRequest<TRequest, TFragment>
    where TFragment : IGraphQlFragment
{
    /// <summary>
    /// Whether a fragment is attached to this request.
    /// </summary>
    /// <seealso cref="Fragment"/>
    public bool HasFragment { get; }

    /// <summary>
    /// Sets the fragment defining the response data for this request.
    /// </summary>
    /// <param name="fragment">The fragment.</param>
    /// <returns>This request for chaining.</returns>
    public TRequest Fragment(TFragment? fragment);
}