using System.Text.Json.Serialization;

namespace Enjin.Platform.Sdk.PendingEvents
{
    /// <summary>
    /// Base class for pending event data.
    /// </summary>
    public class PendingEventDataBase
    {
        /// <summary>
        /// The idempotency key set for this transaction.
        /// </summary>
        [JsonInclude]
        [JsonPropertyName("idempotencyKey")]
        public string? IdempotencyKey { get; private set; }
    }
}