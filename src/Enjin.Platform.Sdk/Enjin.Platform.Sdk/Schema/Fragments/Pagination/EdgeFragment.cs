using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a scalar <see cref="Edge{T}"/> returned by the platform.
/// </summary>
/// <seealso cref="EdgeFragment{TFragment}"/>
[PublicAPI]
public class EdgeFragment : EdgeFragmentBase<EdgeFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EdgeFragment"/> class.
    /// </summary>
    public EdgeFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Edge{T}"/> is to be returned with its <see cref="Edge{T}.Node"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public EdgeFragment WithNode(bool isIncluded = true)
    {
        return WithField("node", isIncluded);
    }
}

/// <summary>
/// A fragment for requesting properties of a non-scalar <see cref="Edge{T}"/> returned by the platform.
/// </summary>
/// <typeparam name="TFragment">
/// The fragment describing the non-scalar data. Must implement <see cref="IGraphQlFragment{TFragment}"/>.
/// </typeparam>
/// <seealso cref="EdgeFragment"/>
[PublicAPI]
public class EdgeFragment<TFragment> : EdgeFragmentBase<EdgeFragment<TFragment>>
    where TFragment : IGraphQlFragment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EdgeFragment{TFragment}"/> class.
    /// </summary>
    public EdgeFragment()
    {
    }

    /// <summary>
    /// Sets the fragment to be used for getting the <see cref="Edge{T}.Node"/> property of the <see cref="Edge{T}"/>.
    /// </summary>
    /// <param name="fragment">The fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public EdgeFragment<TFragment> WithNode(TFragment? fragment)
    {
        return WithField("node", fragment);
    }
}