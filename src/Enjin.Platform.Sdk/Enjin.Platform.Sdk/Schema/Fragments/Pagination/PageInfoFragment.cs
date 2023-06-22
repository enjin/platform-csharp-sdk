using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="PageInfo"/> returned by the platform.
/// </summary>
[PublicAPI]
public class PageInfoFragment : GraphQlFragment<PageInfoFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PageInfoFragment"/> class.
    /// </summary>
    public PageInfoFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="PageInfo"/> is to be returned with its <see cref="PageInfo.HasNextPage"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PageInfoFragment WithHasNextPage(bool isIncluded = true)
    {
        return WithField("hasNextPage", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="PageInfo"/> is to be returned with its <see cref="PageInfo.HasPreviousPage"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PageInfoFragment WithHasPreviousPage(bool isIncluded = true)
    {
        return WithField("hasPreviousPage", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="PageInfo"/> is to be returned with its <see cref="PageInfo.StartCursor"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PageInfoFragment WithStartCursor(bool isIncluded = true)
    {
        return WithField("startCursor", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="PageInfo"/> is to be returned with its <see cref="PageInfo.EndCursor"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public PageInfoFragment WithEndCursor(bool isIncluded = true)
    {
        return WithField("endCursor", isIncluded);
    }
}