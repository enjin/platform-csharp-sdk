using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Abstract base class for GraphQL fragments of the platform's <c>Connection</c> type to extend from.
/// </summary>
/// <typeparam name="TConnection">The inheriting connection class. Must extend this class.</typeparam>
[PublicAPI]
public abstract class ConnectionFragmentBase<TConnection> : GraphQlFragment<TConnection>
    where TConnection : ConnectionFragmentBase<TConnection>
{
    /// <summary>
    /// Sets the cursor to fetch.
    /// </summary>
    /// <param name="after">The cursor.</param>
    /// <returns>This fragment for chaining.</returns>
    public TConnection SetAfter(string? after)
    {
        return SetParameter("after", after);
    }

    /// <summary>
    /// Sets the number results to return per page.
    /// </summary>
    /// <param name="first">The number of result per page.</param>
    /// <returns>This fragment for chaining.</returns>
    public TConnection SetFirst(int? first)
    {
        return SetParameter("first", first);
    }

    /// <summary>
    /// Sets the <see cref="PageInfo"/> fragment to be used for getting the <see cref="Connection{T}.PageInfo"/>
    /// property of the <see cref="Connection{T}"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="PageInfo"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public TConnection WithPageInfo(PageInfoFragment? fragment)
    {
        return WithField("pageInfo", fragment);
    }

    /// <summary>
    /// Sets whether the <see cref="Connection{T}"/> is to be returned with its <see cref="Connection{T}.TotalCount"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TConnection WithTotalCount(bool isIncluded = true)
    {
        return WithField("totalCount", isIncluded);
    }
}