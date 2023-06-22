using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request for for creating a new linking code to associate an external ID to a wallet account.
/// </summary>
/// <seealso cref="WalletLink"/>
[PublicAPI]
public class GetLinkingCode : GraphQlRequest<GetLinkingCode, WalletLinkFragment>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetLinkingCode"/> class.
    /// </summary>
    public GetLinkingCode() : base("GetLinkingCode", GraphQlRequestType.Query)
    {
    }

    /// <summary>
    /// Sets the external ID to link.
    /// </summary>
    /// <param name="externalId">The external ID.</param>
    /// <returns>This request for chaining.</returns>
    public GetLinkingCode SetExternalId(string? externalId)
    {
        return SetVariable("externalId", CoreTypes.String, externalId);
    }
}