using JetBrains.Annotations;

namespace Enjin.Platform.Sdk.Beam;

/// <summary>
/// Contains fields describing variable types used in the platform's Beam API.
/// </summary>
[PublicAPI]
public static class BeamTypes
{
    // BeamFlagInputType

    /// <summary>
    /// String for <c>BeamFlagInputType</c> type.
    /// </summary>
    public const string BeamFlagInputType = "BeamFlagInputType!";

    /// <summary>
    /// String for an array of <c>BeamFlagInputType</c> type.
    /// </summary>
    public const string BeamFlagInputTypeArray = "[BeamFlagInputType!]!";

    // ClaimStatus

    /// <summary>
    /// String for <c>ClaimStatus</c> type.
    /// </summary>
    public const string ClaimStatus = "ClaimStatus!";

    /// <summary>
    /// String for an array of <c>ClaimStatus</c> type.
    /// </summary>
    public const string ClaimStatusArray = "[ClaimStatus!]!";

    // ClaimToken

    /// <summary>
    /// String for <c>ClaimToken</c> type.
    /// </summary>
    public const string ClaimToken = "ClaimToken!";

    /// <summary>
    /// String for an array of <c>ClaimToken</c> type.
    /// </summary>
    public const string ClaimTokenArray = "[ClaimToken!]!";
}