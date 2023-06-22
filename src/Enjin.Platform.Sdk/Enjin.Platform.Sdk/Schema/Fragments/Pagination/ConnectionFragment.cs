using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a scalar <see cref="Connection{T}"/> returned by the platform.
/// </summary>
/// <seealso cref="ConnectionFragment{TFragment}"/>
[PublicAPI]
public class ConnectionFragment : ConnectionFragmentBase<ConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionFragment"/> class.
    /// </summary>
    public ConnectionFragment()
    {
    }

    /// <summary>
    /// Sets the scalar <see cref="Edge{T}"/> fragment to be used for getting the <see cref="Connection{T}.Edges"/>
    /// property of the <see cref="Connection{T}"/>.
    /// </summary>
    /// <param name="fragment">The scalar <see cref="Edge{T}"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public ConnectionFragment WithEdges(EdgeFragment? fragment)
    {
        return WithField("edges", fragment);
    }
}

/// <summary>
/// A fragment for requesting properties of a non-scalar <see cref="Connection{T}"/> returned by the platform.
/// </summary>
/// <typeparam name="TFragment">
/// The fragment describing the non-scalar data. Must implement <see cref="IGraphQlFragment{TFragment}"/>.
/// </typeparam>
/// <seealso cref="ConnectionFragment"/>
[PublicAPI]
public class ConnectionFragment<TFragment> : ConnectionFragmentBase<ConnectionFragment<TFragment>>
    where TFragment : IGraphQlFragment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionFragment{TFragment}"/> class.
    /// </summary>
    public ConnectionFragment()
    {
    }

    /// <summary>
    /// Sets the non-scalar <see cref="Edge{T}"/> fragment to be used for getting the <see cref="Connection{T}.Edges"/>
    /// property of the <see cref="Connection{T}"/>.
    /// </summary>
    /// <param name="fragment">The non-scalar <see cref="Edge{T}"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public ConnectionFragment<TFragment> WithEdges(EdgeFragment<TFragment>? fragment)
    {
        return WithField("edges", fragment);
    }
}