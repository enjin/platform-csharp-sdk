using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Static class which contains members representing the name of each global event on the platform.
/// </summary>
[PublicAPI]
public static class GlobalEvents
{
    /// <summary>
    /// The name of the event for when a <c>Transaction</c> is created.
    /// </summary>
    public const string TransactionCreated = "platform:transaction-created";

    /// <summary>
    /// The name of the event for when a <c>Transaction</c> is updated.
    /// </summary>
    public const string TransactionUpdated = "platform:transaction-updated";
}