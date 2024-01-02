using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A fragment for requesting properties of a <see cref="BeamClaim"/> returned by the platform.
/// </summary>
[PublicAPI]
public class BeamClaimFragment : GraphQlFragment<BeamClaimFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BeamClaimFragment"/> class.
    /// </summary>
    public BeamClaimFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="BeamClaim"/> is to be returned with its <see cref="BeamClaim.Id"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Collection"/> fragment to be used for getting the <see cref="BeamClaim.Collection"/>
    /// property of the <see cref="BeamClaim"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Collection"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithCollection(CollectionFragment? fragment)
    {
        return WithField("collection", fragment);
    }

    /// <summary>
    /// Sets whether the <see cref="BeamClaim"/> is to be returned with its <see cref="BeamClaim.TokenId"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithTokenId(bool isIncluded = true)
    {
        return WithField("tokenId", isIncluded);
    }

    /// <summary>
    /// Sets the <see cref="Beam"/> fragment to be used for getting the <see cref="BeamClaim.Beam"/> property of
    /// the <see cref="BeamClaim"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Beam"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithBeam(BeamFragment? fragment)
    {
        return WithField("beam", fragment);
    }

    /// <summary>
    /// Sets the <see cref="Wallet"/> fragment to be used for getting the <see cref="BeamClaim.Wallet"/> property of the
    /// <see cref="BeamClaim"/>.
    /// </summary>
    /// <param name="fragment">The <see cref="Wallet"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithWallet(WalletFragment? fragment)
    {
        return WithField("wallet", fragment);
    }

    /// <summary>
    /// Sets whether the <see cref="BeamClaim"/> is to be returned with its <see cref="BeamClaim.ClaimedAt"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithClaimedAt(bool isIncluded = true)
    {
        return WithField("claimedAt", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="BeamClaim"/> is to be returned with its <see cref="BeamClaim.ClaimStatus"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithClaimStatus(bool isIncluded = true)
    {
        return WithField("claimStatus", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="BeamClaim"/> is to be returned with its <see cref="BeamClaim.Code"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithCode(bool isIncluded = true)
    {
        return WithField("code", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="BeamClaim"/> is to be returned with its <see cref="BeamClaim.Qr"/> property.
    /// </summary>
    /// <param name="fragment">The <see cref="BeamQrFragment"/> fragment.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamClaimFragment WithQr(BeamQrFragment? fragment)
    {
        return WithField("qr", fragment);
    }
}