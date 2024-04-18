using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for removing a rule set from a fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class RemoveRuleSet : GraphQlRequest<RemoveRuleSet, TransactionFragment>,
                             IHasIdempotencyKey<RemoveRuleSet>,
                             IHasSkipValidation<RemoveRuleSet>,
                             IHasSigningAccount<RemoveRuleSet>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveRuleSet"/> class.
    /// </summary>
    public RemoveRuleSet() : base("RemoveRuleSet", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveRuleSet SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the rule set ID.
    /// </summary>
    /// <param name="ruleSetId">The ID.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveRuleSet SetRuleSetId(BigInteger? ruleSetId)
    {
        return SetVariable("ruleSetId", CoreTypes.BigInt, ruleSetId);
    }
}