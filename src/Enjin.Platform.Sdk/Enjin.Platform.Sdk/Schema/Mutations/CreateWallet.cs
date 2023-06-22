using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// A request to act as a mutation for storing a new unverified wallet record using an external ID.
/// </summary>
[PublicAPI]
public class CreateWallet : GraphQlRequest<CreateWallet>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateWallet"/> class.
    /// </summary>
    public CreateWallet() : base("CreateWallet", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the external ID set for the wallet.
    /// </summary>
    /// <param name="externalId">The external ID.</param>
    /// <returns>This request for chaining.</returns>
    public CreateWallet SetExternalId(string? externalId)
    {
        return SetVariable("externalId", CoreTypes.String, externalId);
    }
}