using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation for removing account rule from a fuel tank.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class RemoveAccountRuleData : GraphQlRequest<RemoveAccountRuleData, TransactionFragment>,
                                     IHasIdempotencyKey<RemoveAccountRuleData>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveAccountRuleData"/> class.
    /// </summary>
    public RemoveAccountRuleData() : base("RemoveAccountRuleData", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveAccountRuleData SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the wallet account.
    /// </summary>
    /// <param name="userId">The account.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveAccountRuleData SetUserId(string? userId)
    {
        return SetVariable("userId", CoreTypes.String, userId);
    }

    /// <summary>
    /// Sets the rule set ID.
    /// </summary>
    /// <param name="ruleSetId">The ID.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveAccountRuleData SetRuleSetId(BigInteger? ruleSetId)
    {
        return SetVariable("ruleSetId", CoreTypes.BigInt, ruleSetId);
    }

    /// <summary>
    /// Sets the dispatch rule options.
    /// </summary>
    /// <param name="rule">The rule options.</param>
    /// <returns>This request for chaining.</returns>
    public RemoveAccountRuleData SetRule(DispatchRuleEnum? rule)
    {
        return SetVariable("rule", FuelTanksTypes.DispatchRuleEnum, rule);
    }
}