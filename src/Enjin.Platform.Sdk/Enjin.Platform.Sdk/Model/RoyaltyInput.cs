using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for the royalty for a new collection or token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<RoyaltyInput>))]
[PublicAPI]
public class RoyaltyInput : GraphQlParameter<RoyaltyInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RoyaltyInput"/> class.
    /// </summary>
    public RoyaltyInput()
    {
    }

    /// <summary>
    /// Sets the account that will receive the royalty.
    /// </summary>
    /// <param name="beneficiary">The account receiving the royalty.</param>
    /// <returns>This parameter for chaining.</returns>
    public RoyaltyInput SetBeneficiary(string? beneficiary)
    {
        return SetParameter("beneficiary", beneficiary);
    }

    /// <summary>
    /// Sets the amount of royalty the beneficiary receives in percentage.
    /// </summary>
    /// <param name="percentage">The amount as a percentage.</param>
    /// <returns>This parameter for chaining.</returns>
    public RoyaltyInput SetPercentage(double? percentage)
    {
        return SetParameter("percentage", percentage);
    }
}