using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for querying an array of blocks optionally filtered by blockchain transaction IDs or blockchain
/// transaction hashes.
/// </summary>
/// <seealso cref="Connection{T}"/>
/// <seealso cref="Block"/>
[PublicAPI]
public class GetBlocks : GraphQlRequest<GetBlocks, BlockConnectionFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetBlocks"/> class.
    /// </summary>
    public GetBlocks() : base("GetBlocks", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the blockchain transaction IDs to filter to.
    /// </summary>
    /// <param name="numbers">The transaction IDs.</param>
    /// <returns>This request for chaining.</returns>
    public GetBlocks SetNumbers(params string[]? numbers)
    {
        return SetVariable("numbers", CoreTypes.StringArray, numbers);
    }

    /// <summary>
    /// Sets the blockchain transaction hashes to filter to.
    /// </summary>
    /// <param name="hashes">The transaction hashes.</param>
    /// <returns>This request for chaining.</returns>
    public GetBlocks SetHashes(params string[]? hashes)
    {
        return SetVariable("hashes", CoreTypes.StringArray, hashes);
    }
}