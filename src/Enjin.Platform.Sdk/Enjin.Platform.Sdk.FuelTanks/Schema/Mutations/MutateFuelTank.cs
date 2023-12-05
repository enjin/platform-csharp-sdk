using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for applying a mutation to a fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class MutateFuelTank : GraphQlRequest<MutateFuelTank, TransactionFragment>,
                              IHasIdempotencyKey<MutateFuelTank>,
                              IHasSigningAccount<MutateFuelTank>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MutateFuelTank"/> class.
    /// </summary>
    public MutateFuelTank() : base("MutateFuelTank", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public MutateFuelTank SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the fuel tank input fields.
    /// </summary>
    /// <param name="mutation">The mutation.</param>
    /// <returns>This request for chaining.</returns>
    public MutateFuelTank SetMutation(FuelTankMutationInputType? mutation)
    {
        return SetVariable("mutation", FuelTanksTypes.FuelTankMutationInputType, mutation);
    }
}