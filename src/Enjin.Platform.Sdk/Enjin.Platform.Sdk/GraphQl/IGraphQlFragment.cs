using System;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Interface for GraphQL fragments.
/// </summary>
/// <seealso cref="IGraphQlFragment{TFragment}"/>
[PublicAPI]
public interface IGraphQlFragment : IGraphQlCompilable, IGraphQlParameterHolder
{
    /// <summary>
    /// Whether this fragment has any fields to be requested in the response data.
    /// </summary>
    public bool HasFields { get; }

    /// <summary>
    /// Compiles the fields within this fragment and returns them as a string.
    /// </summary>
    /// <returns>The compiled string.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if called while <see cref="HasFields"/> is <c>false</c>.
    /// </exception>
    public string CompileFields();

    /// <summary>
    /// Determines whether this fragment has requested a field of the given name is to be returned in the response
    /// data.
    /// </summary>
    /// <param name="name">The name of the field.</param>
    /// <returns>Whether the field has been requested.</returns>
    public bool HasField(string name);
}

/// <summary>
/// Interface for GraphQL fragments with settable fields.
/// </summary>
/// <typeparam name="TFragment">The fragment type. Must implement this interface.</typeparam>
[PublicAPI]
public interface IGraphQlFragment<out TFragment> : IGraphQlFragment
    where TFragment : IGraphQlFragment<TFragment>
{
    /// <summary>
    /// Sets whether this fragment is to request the scalar field with the given name be returned in the response type.
    /// </summary>
    /// <param name="name">The name of the field.</param>
    /// <param name="isIncluded">Whether the field ought to be included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TFragment WithField(string name, bool isIncluded);

    /// <summary>
    /// Sets whether this fragment is to request the fragment field with the given name be returned in the response
    /// type.
    /// </summary>
    /// <param name="name">The name of the field.</param>
    /// <param name="fragment">The fragment field.</param>
    /// <returns>This fragment for chaining.</returns>
    public TFragment WithField(string name, IGraphQlFragment? fragment);
}