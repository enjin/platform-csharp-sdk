using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Models a fuel tank.
/// </summary>
[PublicAPI]
public class FuelTank
{
    /// <summary>
    /// The account of this fuel tank.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("tankId")]
    public Account? TankId { get; private set; }

    /// <summary>
    /// The name of this fuel tank.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("name")]
    public string? Name { get; private set; }

    /// <summary>
    /// The flag for existential deposit.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("reservesExistentialDeposit")]
    public bool? ReservesExistentialDeposit { get; private set; }

    /// <summary>
    /// The flag for account creation deposit.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("reservesAccountCreationDeposit")]
    public bool? ReservesAccountCreationDeposit { get; private set; }

    /// <summary>
    /// The flag for deposit.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("providesDeposit")]
    public bool? ProvidesDeposit { get; private set; }

    /// <summary>
    /// The flag for frozen state.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("isFrozen")]
    public bool? IsFrozen { get; private set; }

    /// <summary>
    /// The number of accounts.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("accountCount")]
    public int? AccountCount { get; private set; }

    /// <summary>
    /// The wallet account for this fuel tank.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("owner")]
    public Wallet? Owner { get; private set; }

    /// <summary>
    /// The accounts for this fuel tank.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("accounts")]
    public IEnumerable<Wallet>? Accounts { get; private set; }

    /// <summary>
    /// The account rules for this fuel tank.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("accountRules")]
    public IEnumerable<AccountRule>? AccountRules { get; private set; }

    /// <summary>
    /// The dispatch rules for this fuel tank.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("dispatchRules")]
    public IEnumerable<DispatchRule>? DispatchRules { get; private set; }
}