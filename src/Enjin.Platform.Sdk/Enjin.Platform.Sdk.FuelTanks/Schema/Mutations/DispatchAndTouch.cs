using System.Numerics;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Similar mutation as <see cref="Dispatch"/>, but creates an account for <c>origin</c> if it does not exist.
/// </summary>
/// <seealso cref="Transaction"/>
[PublicAPI]
public class DispatchAndTouch : GraphQlRequest<DispatchAndTouch, TransactionFragment>,
                                IHasIdempotencyKey<DispatchAndTouch>,
                                IHasSigningAccount<DispatchAndTouch>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DispatchAndTouch"/> class.
    /// </summary>
    public DispatchAndTouch() : base("DispatchAndTouch", GraphQlRequestType.Mutation)
    {
    }

    /// <summary>
    /// Sets the wallet address of the fuel tank.
    /// </summary>
    /// <param name="tankId">The address.</param>
    /// <returns>This request for chaining.</returns>
    public DispatchAndTouch SetTankId(string? tankId)
    {
        return SetVariable("tankId", CoreTypes.String, tankId);
    }

    /// <summary>
    /// Sets the rule set ID.
    /// </summary>
    /// <param name="ruleSetId">The ID.</param>
    /// <returns>This request for chaining.</returns>
    public DispatchAndTouch SetRuleSetId(BigInteger? ruleSetId)
    {
        return SetVariable("ruleSetId", CoreTypes.BigInt, ruleSetId);
    }

    /// <summary>
    /// Sets the dispatch call.
    /// </summary>
    /// <param name="dispatch">The dispatch call.</param>
    /// <returns>This request for chaining.</returns>
    public DispatchAndTouch SetDispatch(DispatchInputType? dispatch)
    {
        return SetVariable("dispatch", FuelTanksTypes.DispatchInputType, dispatch);
    }

    /// <summary>
    /// Sets the flag for paying the remaining fee. May default to <c>false</c> by the platform if not set.
    /// </summary>
    /// <param name="paysRemainingFee">The flag.</param>
    /// <returns>This request for chaining.</returns>
    public DispatchAndTouch SetPaysRemainingFee(bool? paysRemainingFee)
    {
        return SetVariable("paysRemainingFee", CoreTypes.Boolean, paysRemainingFee);
    }
    
    /// <summary>
    /// Sets the signing wallet for the transaction.
    /// </summary>
    /// <param name="signingAccount">The signing wallet account.</param>
    /// <returns>This request for chaining.</returns>
    public DispatchAndTouch SetSigningAccount(string? signingAccount)
    {
        return SetVariable("signingAccount", CoreTypes.String, signingAccount);
    }
}