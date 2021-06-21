using System.Text.Json.Serialization;

namespace Lti.Poc.Ltid.Models
{
    public class LtiServiceResources
    {
        [JsonPropertyName("limits")]
        public LtiResourceSettings Limits { get; set; } = new LtiResourceSettings();
        [JsonPropertyName("requests")]
        public LtiResourceSettings Requests { get; set; } = new LtiResourceSettings();
    }
}
