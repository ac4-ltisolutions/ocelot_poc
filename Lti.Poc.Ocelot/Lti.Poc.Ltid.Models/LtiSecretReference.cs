using System.Text.Json.Serialization;

namespace Lti.Poc.Ltid.Models
{
    public class LtiSecretReference
    {
        [JsonPropertyName("environmentVariableName")]
        public string? EnvironmentVariableName { get; set; }
        [JsonPropertyName("secretName")]
        public string? SecretName { get; set; }
        [JsonPropertyName("secretKey")]
        public string? SecretKey { get; set; }
    }
}
