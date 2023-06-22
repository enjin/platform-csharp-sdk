using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="Block"/> returned by the platform.
/// </summary>
[PublicAPI]
public class BlockFragment : GraphQlFragment<BlockFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlockFragment"/> class.
    /// </summary>
    public BlockFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="Block"/> is to be returned with its <see cref="Block.Id"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BlockFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Block"/> is to be returned with its <see cref="Block.Number"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BlockFragment WithNumber(bool isIncluded = true)
    {
        return WithField("number", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Block"/> is to be returned with its <see cref="Block.Hash"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BlockFragment WithHash(bool isIncluded = true)
    {
        return WithField("hash", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Block"/> is to be returned with its <see cref="Block.Synced"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BlockFragment WithSynced(bool isIncluded = true)
    {
        return WithField("synced", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Block"/> is to be returned with its <see cref="Block.Failed"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BlockFragment WithFailed(bool isIncluded = true)
    {
        return WithField("failed", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="Block"/> is to be returned with its <see cref="Block.Exception"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BlockFragment WithException(bool isIncluded = true)
    {
        return WithField("exception", isIncluded);
    }
}