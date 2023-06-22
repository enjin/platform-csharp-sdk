using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Static class which contains members representing the name of each beam based event on the platform.
/// </summary>
[PublicAPI]
public static class BeamEvents
{
    /// <summary>
    /// The name of the event for when a claim for a beam is in progress.
    /// </summary>
    public const string BeamClaimInProgress = "platform:beam-claim-in-progress";

    /// <summary>
    /// The name of the event for when a claim for a beam becomes pending.
    /// </summary>
    public const string BeamClaimPending = "platform:beam-claim-pending";

    /// <summary>
    /// The name of the event for when a claim for a beam is completed.
    /// </summary>
    public const string BeamClaimsComplete = "platform:beam-claims-complete";

    /// <summary>
    /// The name of the event for when a claim for a beam fails.
    /// </summary>
    public const string BeamClaimsFailed = "platform:beam-claims-failed";

    /// <summary>
    /// The name of the event for when a beam is created.
    /// </summary>
    public const string BeamCreated = "platform:beam-created";

    /// <summary>
    /// The name of the event for when a beam is deleted.
    /// </summary>
    public const string BeamDeleted = "platform:beam-deleted";

    /// <summary>
    /// The name of the event for when a beam is updated.
    /// </summary>
    public const string BeamUpdated = "platform:beam-updated";
}