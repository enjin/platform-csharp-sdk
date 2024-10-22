using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Models a parameter for fuel tank input fields.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<FuelTankMutationInputType>))]
[PublicAPI]
public class FuelTankMutationInputType : GraphQlParameter<FuelTankMutationInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FuelTankMutationInputType"/> class.
    /// </summary>
    public FuelTankMutationInputType()
    {
    }

    /// <summary>
    /// Sets the flag for account creation deposit.
    /// </summary>
    /// <param name="reservesAccountCreationDeposit">The flag.</param>
    /// <returns>This parameter for chaining.</returns>
    public FuelTankMutationInputType SetReservesAccountCreationDeposit(bool? reservesAccountCreationDeposit)
    {
        return SetParameter("reservesAccountCreationDeposit", reservesAccountCreationDeposit);
    }

    /// <summary>
    /// Sets the fuel tank coverage policy.
    /// </summary>
    /// <param name="coveragePolicy">The flag.</param>
    /// <returns>This parameter for chaining.</returns>
    public FuelTankMutationInputType SetCoveragePolicy(CoveragePolicy? coveragePolicy)
    {
        return SetParameter("coveragePolicy", coveragePolicy);
    }

    /// <summary>
    /// Sets the fuel tank account rules.
    /// </summary>
    /// <param name="accountRules">The rules.</param>
    /// <returns>This parameter for chaining.</returns>
    public FuelTankMutationInputType SetAccountRules(AccountRuleInputType? accountRules)
    {
        return SetParameter("accountRules", accountRules);
    }
}