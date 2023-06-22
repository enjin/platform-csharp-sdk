using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A fragment for requesting properties of a <see cref="BeamScan"/> returned by the platform.
/// </summary>
[PublicAPI]
public class BeamScanFragment : GraphQlFragment<BeamScanFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BeamScanFragment"/> class.
    /// </summary>
    public BeamScanFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="BeamScan"/> is to be returned with its <see cref="BeamScan.Id"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamScanFragment WithId(bool isIncluded = true)
    {
        return WithField("id", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="BeamScan"/> is to be returned with its <see cref="BeamScan.WalletPublicKey"/>
    /// property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamScanFragment WithWalletPublicKey(bool isIncluded = true)
    {
        return WithField("walletPublicKey", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="BeamScan"/> is to be returned with its <see cref="BeamScan.Message"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamScanFragment WithMessage(bool isIncluded = true)
    {
        return WithField("message", isIncluded);
    }
}