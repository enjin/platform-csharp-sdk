using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Models a parameter for account rules of a fuel tank.
/// </summary>
[JsonConverter(typeof(GraphQlParameterJsonConverter<AccountRuleInputType>))]
[PublicAPI]
public class AccountRuleInputType : GraphQlParameter<AccountRuleInputType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountRuleInputType"/> class.
    /// </summary>
    public AccountRuleInputType()
    {
    }

    /// <summary>
    /// Sets the wallet accounts that are allowed to use the fuel tank.
    /// </summary>
    /// <param name="whitelistedCallers">The allowed accounts.</param>
    /// <returns>This parameter for chaining.</returns>
    public AccountRuleInputType SetWhitelistedCallers(params string[]? whitelistedCallers)
    {
        return SetParameter("whitelistedCallers", whitelistedCallers);
    }

    /// <summary>
    /// Sets the specific token the wallet account(s) must have to use the fuel tank.
    /// </summary>
    /// <param name="requireToken">The required token.</param>
    /// <returns>This parameter for chaining.</returns>
    public AccountRuleInputType SetRequireToken(MultiTokenIdInput? requireToken)
    {
        return SetParameter("requireToken", requireToken);
    }
}