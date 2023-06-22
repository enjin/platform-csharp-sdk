using System.Numerics;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Models a parameter for the rule for a fuel budget.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<FuelBudgetInputType>))]
[PublicAPI]
public class FuelBudgetInputType : GraphQlParameter<FuelBudgetInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FuelBudgetInputType"/> class.
    /// </summary>
    public FuelBudgetInputType()
    {
    }

    /// <summary>
    /// Sets the amount of fuel.
    /// </summary>
    /// <param name="amount">The amount.</param>
    /// <returns>This parameter for chaining.</returns>
    public FuelBudgetInputType SetAmount(BigInteger? amount)
    {
        return SetParameter("amount", amount);
    }

    /// <summary>
    /// Sets the period when the amount will reset.
    /// </summary>
    /// <param name="resetPeriod">The reset period.</param>
    /// <returns>This parameter for chaining.</returns>
    public FuelBudgetInputType SetResetPeriod(int? resetPeriod)
    {
        return SetParameter("resetPeriod", resetPeriod);
    }
}