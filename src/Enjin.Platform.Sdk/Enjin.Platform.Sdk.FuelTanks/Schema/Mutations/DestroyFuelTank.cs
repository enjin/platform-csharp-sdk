using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for destroying a fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class DestroyFuelTank : GraphQlRequest<DestroyFuelTank, TransactionFragment>,
                               IHasIdempotencyKey<DestroyFuelTank>,
                               IHasSkipValidation<DestroyFuelTank>,
                               IHasSigningAccount<DestroyFuelTank>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DestroyFuelTank"/> class.
    /// </summary>
    public DestroyFuelTank() : base("DestroyFuelTank", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public DestroyFuelTank SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }
}