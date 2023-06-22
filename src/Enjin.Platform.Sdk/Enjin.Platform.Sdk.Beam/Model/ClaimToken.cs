using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Models a parameter for setting the claimable tokens of a beam.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<ClaimToken>))]
[PublicAPI]
public class ClaimToken : GraphQlParameter<ClaimToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClaimToken"/> class.
    /// </summary>
    public ClaimToken()
    {
    }

    /// <summary>
    /// Sets the token chain IDs to claim.
    /// </summary>
    /// <param name="tokenIds">The token chain IDs.</param>
    /// <returns>This parameter for chaining.</returns>
    public ClaimToken SetTokenIds(params IntegerRange[]? tokenIds)
    {
        return SetParameter("tokenIds", tokenIds);
    }

    /// <summary>
    /// Sets the text file to upload which contains one token ID range per line.
    /// </summary>
    /// <param name="tokenIdDataUpload">The <see cref="Upload"/>.</param>
    /// <returns>This parameter for chaining.</returns>
    public ClaimToken SetTokenIdDataUpload(Upload? tokenIdDataUpload)
    {
        return SetParameter("tokenIdDataUpload", tokenIdDataUpload);
    }

    /// <summary>
    /// Sets the initial attributes for the token.
    /// </summary>
    /// <param name="attributes">The initial attributes.</param>
    /// <returns>This parameter for chaining.</returns>
    public ClaimToken SetAttributes(params AttributeInput[]? attributes)
    {
        return SetParameter("attributes", attributes);
    }

    /// <summary>
    /// Sets the quantity of tokens that can be received per claim.
    /// </summary>
    /// <param name="tokenQuantityPerClaim">The amount received per claim.</param>
    /// <returns>This parameter for chaining.</returns>
    /// <remarks>
    /// If <c>null</c> or left unset, then the platform may default this argument to 1.
    /// </remarks>
    public ClaimToken SetTokenQuantityPerClaim(int? tokenQuantityPerClaim)
    {
        return SetParameter("tokenQuantityPerClaim", tokenQuantityPerClaim);
    }

    /// <summary>
    /// Sets the total amount of tokens than can be claimed.
    /// </summary>
    /// <param name="claimQuantity">The amount that can be claimed.</param>
    /// <returns>This parameter for chaining.</returns>
    /// <remarks>
    /// If <c>null</c> or left unset, then the platform may default this argument to 1.
    /// </remarks>
    public ClaimToken SetClaimQuantity(int? claimQuantity)
    {
        return SetParameter("claimQuantity", claimQuantity);
    }

    /// <summary>
    /// Sets the type of the beam.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>This parameter for chaining.</returns>
    /// <remarks>
    /// If not set or <c>null</c>, then the platform may default this argument to <see cref="BeamType.TransferToken"/>.
    /// </remarks>
    public ClaimToken SetType(BeamType? type)
    {
        return SetParameter("type", type);
    }
}