namespace Lti.Poc.Ltid.Models
{
    public class LtiStorageReference
    {
        public string VolumeLabel { get; set; } = string.Empty;
        public string MountPath { get; set; } = string.Empty;
        public string PersistentVolumeClaimName { get; set; } = string.Empty;
    }
}
