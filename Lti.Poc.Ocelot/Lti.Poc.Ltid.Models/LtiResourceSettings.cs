using System.Text.Json.Serialization;

namespace Lti.Poc.Ltid.Models
{
    public class LtiResourceSettings
    {
        [JsonPropertyName("cpu")]
        public string Cpu { get; set; } = "10m";
        [JsonPropertyName("memory")]
        public string Memory { get; set; } = "100Mi";
    }
}
