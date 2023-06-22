using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for scheduling a mutation of the <c>is_frozen</c> state that determines if a fuel
/// tank or rule set may be frozen.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class ScheduleMutateFreezeState : GraphQlRequest<ScheduleMutateFreezeState, TransactionFragment>,
                                         IHasIdempotencyKey<ScheduleMutateFreezeState>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ScheduleMutateFreezeState"/> class.
    /// </summary>
    public ScheduleMutateFreezeState() : base("ScheduleMutateFreezeState", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public ScheduleMutateFreezeState SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the flag for the frozen state.
    /// </summary>
    /// <param name="isFrozen">The flag.</param>
    /// <returns>This request for chaining.</returns>
    public ScheduleMutateFreezeState SetIsFrozen(bool? isFrozen)
    {
        return SetVariable("isFrozen", CoreTypes.Boolean, isFrozen);
    }

    /// <summary>
    /// Sets the rule set ID.
    /// </summary>
    /// <param name="ruleSetId">The ID.</param>
    /// <returns>This request for chaining.</returns>
    public ScheduleMutateFreezeState SetRuleSetId(BigInteger? ruleSetId)
    {
        return SetVariable("ruleSetId", CoreTypes.BigInt, ruleSetId);
    }
}