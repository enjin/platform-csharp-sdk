using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for adding a new account to the fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class AddAccount : GraphQlRequest<AddAccount, TransactionFragment>,
                          IHasIdempotencyKey<AddAccount>,
                          IHasSkipValidation<AddAccount>,
                          IHasSigningAccount<AddAccount>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddAccount"/> class.
    /// </summary>
    public AddAccount() : base("AddAccount", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public AddAccount SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the wallet account to be added to the fuel tank.
    /// </summary>
    /// <param name="userId">The account.</param>
    /// <returns>This request for chaining.</returns>
    public AddAccount SetUserId(string? userId)
    {
        return SetVariable("userId", CoreTypes.String, userId);
    }
}