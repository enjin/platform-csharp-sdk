using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Models a parameter for dispatch rules of a fuel tank.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<DispatchRuleInputType>))]
[PublicAPI]
public class DispatchRuleInputType : GraphQlParameter<DispatchRuleInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DispatchRuleInputType"/> class.
    /// </summary>
    public DispatchRuleInputType()
    {
    }

    /// <summary>
    /// Sets the wallet accounts that are allowed to use the fuel tank.
    /// </summary>
    /// <param name="whitelistedCallers">The allowed accounts.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchRuleInputType SetWhitelistedCallers(params string[]? whitelistedCallers)
    {
        return SetParameter("whitelistedCallers", whitelistedCallers);
    }

    /// <summary>
    /// Sets the specific token the wallet account(s) must have to use the fuel tank.
    /// </summary>
    /// <param name="requireToken">The required token.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchRuleInputType SetRequireToken(MultiTokenIdInput? requireToken)
    {
        return SetParameter("requireToken", requireToken);
    }

    /// <summary>
    /// Sets the collections that are allowed to use the fuel tank.
    /// </summary>
    /// <param name="whitelistedCollections">The allowed collections.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchRuleInputType SetWhitelistedCollections(params BigInteger[]? whitelistedCollections)
    {
        return SetParameter("whitelistedCollections", whitelistedCollections);
    }

    /// <summary>
    /// Sets the maximum amount of fuel that can be used per transaction.
    /// </summary>
    /// <param name="maxFuelBurnPerTransaction">The maximum amount.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchRuleInputType SetMaxFuelBurnPerTransaction(BigInteger? maxFuelBurnPerTransaction)
    {
        return SetParameter("maxFuelBurnPerTransaction", maxFuelBurnPerTransaction);
    }
    
    /// <summary>
    /// Sets the permitted extrinsics that can be used with the fuel tank.
    /// </summary>
    /// <param name="permittedExtrinsics">The permitted extrinsics.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchRuleInputType SetPermittedExtrinsics(params TransactionMethod[] permittedExtrinsics)
    {
        return SetParameter("permittedExtrinsics", permittedExtrinsics);
    }

    /// <summary>
    /// Sets the rule for user fuel budget.
    /// </summary>
    /// <param name="userFuelBudget">The budget rule.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchRuleInputType SetUserFuelBudget(FuelBudgetInputType? userFuelBudget)
    {
        return SetParameter("userFuelBudget", userFuelBudget);
    }

    /// <summary>
    /// Sets the rule for tank fuel budget.
    /// </summary>
    /// <param name="tankFuelBudget">The budget rule.</param>
    /// <returns>This parameter for chaining.</returns>
    public DispatchRuleInputType SetTankFuelBudget(FuelBudgetInputType? tankFuelBudget)
    {
        return SetParameter("tankFuelBudget", tankFuelBudget);
    }
}