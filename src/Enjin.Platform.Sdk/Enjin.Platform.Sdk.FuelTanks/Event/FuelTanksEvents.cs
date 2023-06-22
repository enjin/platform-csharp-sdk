using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.FuelTanks;

/// <summary>
/// Static class which contains members representing the name of each fuel tanks based event on the platform.
/// </summary>
[PublicAPI]
public static class FuelTanksEvents
{
    /// <summary>
    /// The name of the event for when an account is added.
    /// </summary>
    public const string AccountAdded = "platform:account-added";

    /// <summary>
    /// The name of the event for when an account is removed.
    /// </summary>
    public const string AccountRemoved = "platform:account-removed";

    /// <summary>
    /// The name of the event for when a call is dispatched.
    /// </summary>
    public const string CallDispatched = "platform:call-dispatched";

    /// <summary>
    /// The name of the event for when a freeze state is mutated.
    /// </summary>
    public const string FreezeStateMutated = "platform:freeze-state-mutated";

    /// <summary>
    /// The name of the event for when a fuel tank is created.
    /// </summary>
    public const string FuelTankCreated = "platform:fuel-tank-created";

    /// <summary>
    /// The name of the event for when a fuel tank is destroyed.
    /// </summary>
    public const string FuelTankDestroyed = "platform:fuel-tank-destroyed";

    /// <summary>
    /// The name of the event for when a fuel tank is mutated.
    /// </summary>
    public const string FuelTankMutated = "platform:fuel-tank-mutated";

    /// <summary>
    /// The name of the event for when a mutation of a freeze state is scheduled.
    /// </summary>
    public const string MutateFreezeStateScheduled = "platform:mutate-freeze-state-scheduled";

    /// <summary>
    /// The name of the event for when a rule set is inserted.
    /// </summary>
    public const string RuleSetInserted = "platform:rule-set-inserted";

    /// <summary>
    /// The name of the event for when a rule set is removed.
    /// </summary>
    public const string RuleSetRemoved = "platform:rule-set-removed";
}