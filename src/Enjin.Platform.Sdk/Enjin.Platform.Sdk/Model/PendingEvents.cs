using System.Text.Json;
using JetBrains.Annotations;

namespace Enjin.Platform.Sdk;

/// <summary>
/// Models events that have been broadcasted, but not yet acknowledge.
/// </summary>
[PublicAPI]
public class PendingEvents : Connection<JsonElement?>
{
}