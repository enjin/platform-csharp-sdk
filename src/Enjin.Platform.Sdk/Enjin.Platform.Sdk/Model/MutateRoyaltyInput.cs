using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models a parameter for mutating the royalty for a new collection or token.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<MutateRoyaltyInput>))]
[PublicAPI]
public class MutateRoyaltyInput : GraphQlParameter<MutateRoyaltyInput>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MutateRoyaltyInput"/> class.
    /// </summary>
    public MutateRoyaltyInput()
    {
    }

    /// <summary>
    /// Sets the account that will receive the royalty.
    /// </summary>
    /// <param name="beneficiary">The beneficiary account.</param>
    /// <returns>This parameter for chaining.</returns>
    public MutateRoyaltyInput SetBeneficiary(string? beneficiary)
    {
        return SetParameter("beneficiary", beneficiary);
    }

    /// <summary>
    /// Sets the amount of royalty the beneficiary receives in percentage.
    /// </summary>
    /// <param name="percentage">The amount as a percentage.</param>
    /// <returns>This parameter for chaining.</returns>
    public MutateRoyaltyInput SetPercentage(double? percentage)
    {
        return SetParameter("percentage", percentage);
    }
}