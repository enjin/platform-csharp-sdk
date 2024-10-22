using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of an <see cref="Attribute"/> returned by the platform.
/// </summary>
[PublicAPI]
public class TokenMetadataFragment : GraphQlFragment<TokenMetadataFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TokenMetadataFragment"/> class.
    /// </summary>
    public TokenMetadataFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="TokenMetadata"/> is to be returned with its <see cref="TokenMetadata.Name"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenMetadataFragment WithName(bool isIncluded = true)
    {
        return WithField("name", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="TokenMetadata"/> is to be returned with its <see cref="TokenMetadata.Symbol"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenMetadataFragment WithSymbol(bool isIncluded = true)
    {
        return WithField("symbol", isIncluded);
    }
    
    /// <summary>
    /// Sets whether the <see cref="TokenMetadata"/> is to be returned with its <see cref="TokenMetadata.DecimalCount"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public TokenMetadataFragment WithDecimalCount(bool isIncluded = true)
    {
        return WithField("decimalCount", isIncluded);
    }
}