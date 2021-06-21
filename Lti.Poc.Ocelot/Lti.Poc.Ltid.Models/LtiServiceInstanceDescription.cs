using Lti.Poc.Ltid.Models.Enum;
using System.Collections.Generic;

namespace Lti.Poc.Ltid.Models
{
    public class LtiServiceInstanceDescription
    {
        public string ServiceName { get; set; } = string.Empty;
        public string Group { get; set; } = "internal";
        public List<LtiServiceVersion> Versions { get; set; } = new List<LtiServiceVersion>();
        public List<LtiStorageReference> AttachedVolumes { get; set; } = new List<LtiStorageReference>();
        public string ServiceAccountName { get; set; } = string.Empty;
        public string? RouteSyncTimestamp { get; set; }
        public bool IncludeKubectlSidecar { get; set; }
        public string AuthorizationPolicy { get; set; } = AuthPolicy.None.ToString();
    }
}
