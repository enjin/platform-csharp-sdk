using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for inserting a new rule set for a fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class InsertRuleSet : GraphQlRequest<InsertRuleSet, TransactionFragment>,
                             IHasIdempotencyKey<InsertRuleSet>,
                             IHasSkipValidation<InsertRuleSet>,
                             IHasSigningAccount<InsertRuleSet>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InsertRuleSet"/> class.
    /// </summary>
    public InsertRuleSet() : base("InsertRuleSet", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public InsertRuleSet SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the rule set ID.
    /// </summary>
    /// <param name="ruleSetId">The ID.</param>
    /// <returns>This request for chaining.</returns>
    public InsertRuleSet SetRuleSetId(BigInteger? ruleSetId)
    {
        return SetVariable("ruleSetId", CoreTypes.BigInt, ruleSetId);
    }

    /// <summary>
    /// Sets the fuel tank dispatch rules.
    /// </summary>
    /// <param name="dispatchRules">The dispatch rules.</param>
    /// <returns>This request for chaining.</returns>
    public InsertRuleSet SetDispatchRules(params DispatchRuleInputType[]? dispatchRules)
    {
        return SetVariable("dispatchRules", FuelTanksTypes.DispatchRuleInputTypeArray, dispatchRules);
    }
}