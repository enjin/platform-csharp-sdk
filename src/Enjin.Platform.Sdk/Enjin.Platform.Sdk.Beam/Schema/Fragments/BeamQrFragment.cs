using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// A fragment for requesting properties of a <see cref="BeamQr"/> returned by the platform.
/// </summary>
[PublicAPI]
public class BeamQrFragment : GraphQlFragment<BeamQrFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BeamQrFragment"/> class.
    /// </summary>
    public BeamQrFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="BeamQr"/> is to be returned with its <see cref="BeamQr.Url"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamQrFragment WithUrl(bool isIncluded = true)
    {
        return WithField("url", isIncluded);
    }

    /// <summary>
    /// Sets whether the <see cref="BeamQr"/> is to be returned with its <see cref="BeamQr.Payload"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public BeamQrFragment WithPayload(bool isIncluded = true)
    {
        return WithField("payload", isIncluded);
    }
}