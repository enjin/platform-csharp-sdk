using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// A request to act as a mutation to dispatch a call using the <c>tankId</c> subject to the rules of <c>ruleSetId</c>.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class Dispatch : GraphQlRequest<Dispatch, TransactionFragment>,
                        IHasIdempotencyKey<Dispatch>,
                        IHasSkipValidation<Dispatch>,
                        IHasSimulate<Dispatch>,
                        IHasSigningAccount<Dispatch>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Dispatch"/> class.
    /// </summary>
    public Dispatch() : base("Dispatch", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public Dispatch SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the rule set ID.
    /// </summary>
    /// <param name="ruleSetId">The ID.</param>
    /// <returns>This request for chaining.</returns>
    public Dispatch SetRuleSetId(BigInteger? ruleSetId)
    {
        return SetVariable("ruleSetId", CoreTypes.BigInt, ruleSetId);
    }

    /// <summary>
    /// Sets the dispatch call.
    /// </summary>
    /// <param name="dispatch">The dispatch call.</param>
    /// <returns>This request for chaining.</returns>
    public Dispatch SetDispatch(DispatchInputType? dispatch)
    {
        return SetVariable("dispatch", FuelTanksTypes.DispatchInputType, dispatch);
    }

    /// <summary>
    /// Sets the flag for paying the remaining fee. May default to <c>false</c> by the platform if not set.
    /// </summary>
    /// <param name="paysRemainingFee">The flag.</param>
    /// <returns>This request for chaining.</returns>
    public Dispatch SetPaysRemainingFee(bool? paysRemainingFee)
    {
        return SetVariable("paysRemainingFee", CoreTypes.Boolean, paysRemainingFee);
    }
}