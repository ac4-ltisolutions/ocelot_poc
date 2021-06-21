using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lti.Poc.Ltid.ClientTests.Data
{
    internal static class JsonStrings
    {
        public static string ServiceList { get; } = @"
        [
            {
                ""serviceName"": ""apigateway"",
                ""group"": ""lti-system"",
                ""versions"": [
                        {
                            ""isDefault"": false,
                            ""isDebug"": false,
                            ""version"": ""default"",
                            ""image"": ""ltits.azurecr.io/platform/apigateway:default"",
                            ""subscriptionsEnabled"": false,
                            ""upgresEnabled"": false,
                            ""hash"": ""placeholder"",
                            ""resources"": {
                                    ""limits"": {
                                        ""cpu"": ""200m"",
                                        ""memory"": ""200Mi""
                                    },
                                    ""requests"": {
                                        ""cpu"": ""10m"",
                                        ""memory"": ""100Mi""
                                    }
                                },
                            ""secrets"": [
                                    {
                                        ""environmentVariableName"": ""Admin__HostName"",
                                        ""secretName"": ""lti-environment-settings"",
                                        ""secretKey"": ""AdminHostName""
                                    },
                                    {
                                        ""environmentVariableName"": ""Admin__ApiKey"",
                                        ""secretName"": ""lti-environment-settings"",
                                        ""secretKey"": ""AdminApiKey""
                                    },
                                    {
                                        ""environmentVariableName"": ""Admin__RouteKey"",
                                        ""secretName"": ""lti-environment-settings"",
                                        ""secretKey"": ""AdminRouteKey""
                                    }
                                ],
                            ""desiredReplicas"": 1,
                            ""isEnabled"": true
                        }
                    ],
                ""attachedVolumes"": [],
                ""serviceAccountName"": """",
                ""includeKubectlSidecar"": false,
                ""authorizationPolicy"": ""None""
            },
            {
                ""serviceName"": ""authentication"",
                ""group"": ""lti-system"",
                ""versions"": [
                    {
                        ""isDefault"": false,
                        ""isDebug"": false,
                        ""version"": ""default"",
                        ""image"": ""ltits.azurecr.io/customer-portal/authentication:default"",
                        ""subscriptionsEnabled"": true,
                        ""upgresEnabled"": true,
                        ""hash"": ""placeholder"",
                        ""resources"": {
                            ""limits"": {
                                ""cpu"": ""200m"",
                                ""memory"": ""200Mi""
                            },
                            ""requests"": {
                                ""cpu"": ""10m"",
                                ""memory"": ""100Mi""
                            }
                        },
                        ""secrets"": [
                            {
                                ""environmentVariableName"": ""Admin__HostName"",
                                ""secretName"": ""lti-environment-settings"",
                                ""secretKey"": ""AdminHostName""
                            },
                            {
                                ""environmentVariableName"": ""Admin__ApiKey"",
                                ""secretName"": ""lti-environment-settings"",
                                ""secretKey"": ""AdminApiKey""
                            },
                            {
                                ""environmentVariableName"": ""Admin__RouteKey"",
                                ""secretName"": ""lti-environment-settings"",
                                ""secretKey"": ""AdminRouteKey""
                            }
                        ],
                        ""desiredReplicas"": 1,
                        ""isEnabled"": true
                    }
                ],
                ""attachedVolumes"": [],
                ""serviceAccountName"": """",
                ""includeKubectlSidecar"": false,
                ""authorizationPolicy"": ""None""
            },
            {
                ""serviceName"": ""accounting-bulk_contract"",
                ""group"": ""api"",
                ""versions"": [
                    {
                        ""isDefault"": false,
                        ""isDebug"": false,
                        ""version"": ""default"",
                        ""image"": ""ltits.azurecr.io/accounting/bulk_contract-api:default"",
                        ""subscriptionsEnabled"": false,
                        ""upgresEnabled"": false,
                        ""hash"": ""placeholder"",
                        ""resources"": {
                            ""limits"": {
                                ""cpu"": ""50m"",
                                ""memory"": ""500Mi""
                            },
                            ""requests"": {
                                ""cpu"": ""10m"",
                                ""memory"": ""100Mi""
                            }
                        },
                        ""secrets"": [],
                        ""desiredReplicas"": 1,
                        ""isEnabled"": true
                    }
                ],
                ""attachedVolumes"": [
                    {
                        ""volumeLabel"": ""api-persistent-storage"",
                        ""mountPath"": ""/app/private-label"",
                        ""persistentVolumeClaimName"": ""lti-api-storage""
                    }
                ],
                ""serviceAccountName"": """",
                ""includeKubectlSidecar"": false,
                ""authorizationPolicy"": ""None""
            },
            {
                ""serviceName"": ""accounting-journal"",
                ""group"": ""api"",
                ""versions"": [
                    {
                        ""isDefault"": false,
                        ""isDebug"": false,
                        ""version"": ""default"",
                        ""image"": ""ltits.azurecr.io/accounting/journal-api:default"",
                        ""subscriptionsEnabled"": false,
                        ""upgresEnabled"": false,
                        ""hash"": ""placeholder"",
                        ""resources"": {
                            ""limits"": {
                                ""cpu"": ""50m"",
                                ""memory"": ""500Mi""
                            },
                            ""requests"": {
                                ""cpu"": ""10m"",
                                ""memory"": ""100Mi""
                            }
                        },
                        ""secrets"": [],
                        ""desiredReplicas"": 1,
                        ""isEnabled"": true
                    },
{
                        ""isDefault"": false,
                        ""isDebug"": false,
                        ""version"": ""1.2.1"",
                        ""image"": ""ltits.azurecr.io/accounting/journal-api:default"",
                        ""subscriptionsEnabled"": false,
                        ""upgresEnabled"": false,
                        ""hash"": ""placeholder"",
                        ""resources"": {
                            ""limits"": {
                                ""cpu"": ""50m"",
                                ""memory"": ""500Mi""
                            },
                            ""requests"": {
                                ""cpu"": ""10m"",
                                ""memory"": ""100Mi""
                            }
                        },
                        ""secrets"": [],
                        ""desiredReplicas"": 1,
                        ""isEnabled"": true
                    }
                ],
                ""attachedVolumes"": [
                    {
                        ""volumeLabel"": ""api-persistent-storage"",
                        ""mountPath"": ""/app/private-label"",
                        ""persistentVolumeClaimName"": ""lti-api-storage""
                    }
                ],
                ""serviceAccountName"": """",
                ""includeKubectlSidecar"": false,
                ""authorizationPolicy"": ""None""
            }
        ]";
    }
}
