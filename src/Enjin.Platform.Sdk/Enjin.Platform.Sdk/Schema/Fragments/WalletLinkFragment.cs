using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A fragment for requesting properties of a <see cref="WalletLink"/> returned by the platform.
/// </summary>
[PublicAPI]
public class WalletLinkFragment : GraphQlFragment<WalletLinkFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WalletLinkFragment"/> class.
    /// </summary>
    public WalletLinkFragment()
    {
    }

    /// <summary>
    /// Sets whether the <see cref="WalletLink"/> is to be returned with its <see cref="WalletLink.Code"/> property.
    /// </summary>
    /// <param name="isIncluded">Whether the field is included.</param>
    /// <returns>This fragment for chaining.</returns>
    public WalletLinkFragment WithCode(bool isIncluded = true)
    {
        return WithField("code", isIncluded);
    }
}