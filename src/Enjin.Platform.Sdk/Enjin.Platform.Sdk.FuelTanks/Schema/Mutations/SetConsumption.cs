using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation to force set the consumption of a fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class SetConsumption : GraphQlRequest<SetConsumption, TransactionFragment>,
                              IHasIdempotencyKey<SetConsumption>,
                              IHasSkipValidation<SetConsumption>,
                              IHasSigningAccount<SetConsumption>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetConsumption"/> class.
    /// </summary>
    public SetConsumption() : base("SetConsumption", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public SetConsumption SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the rule set ID.
    /// </summary>
    /// <param name="ruleSetId">The ID.</param>
    /// <returns>This request for chaining.</returns>
    public SetConsumption SetRuleSetId(BigInteger? ruleSetId)
    {
        return SetVariable("ruleSetId", CoreTypes.BigInt, ruleSetId);
    }

    /// <summary>
    /// Sets the wallet account to be added to the fuel tank.
    /// </summary>
    /// <param name="userId">The account.</param>
    /// <returns>This request for chaining.</returns>
    public SetConsumption SetUserId(string? userId)
    {
        return SetVariable("userId", CoreTypes.String, userId);
    }

    /// <summary>
    /// Sets the total consumption.
    /// </summary>
    /// <param name="totalConsumed">The total consumption.</param>
    /// <returns>This request for chaining.</returns>
    public SetConsumption SetTotalConsumed(BigInteger? totalConsumed)
    {
        return SetVariable("totalConsumed", CoreTypes.BigInt, totalConsumed);
    }

    /// <summary>
    /// Sets the last reset block.
    /// </summary>
    /// <param name="lastResetBlock">The last reset block.</param>
    /// <returns>This request for chaining.</returns>
    public SetConsumption SetLastResetBlock(int? lastResetBlock)
    {
        return SetVariable("lastResetBlock", CoreTypes.Int, lastResetBlock);
    }
}