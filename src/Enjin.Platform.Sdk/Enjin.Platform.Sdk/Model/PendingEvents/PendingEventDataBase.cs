using System.Text.Json.Serialization;

namespace Enjin.Platform.Sdk.PendingEvents
{
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