using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Lti.Poc.Ltid.Models
{
    public class LtiServiceVersion
    {
        [JsonPropertyName("isDefault")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("isDebug")]
        public bool IsDebug { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;

        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; } = default!;

        [JsonPropertyName("image")]
        public string Image { get; set; } = string.Empty;

        [JsonPropertyName("subscriptionsEnabled")]
        public bool SubscriptionsEnabled { get; set; }

        [JsonPropertyName("upgresEnabled")]
        public bool UpgresEnabled { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; } = string.Empty;

        [JsonPropertyName("resources")]
        public LtiServiceResources Resources { get; set; } = new LtiServiceResources();

        [JsonPropertyName("secrets")]
        public List<LtiSecretReference> Secrets { get; set; } = new List<LtiSecretReference>();

        [JsonPropertyName("desiredReplicas")]
        public int DesiredReplicas { get; set; } = 1;

        public bool IsEnabled => (Enabled ?? true) == true;

    }
}
