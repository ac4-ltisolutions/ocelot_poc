using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lti.Poc.Ltid.Client
{
    public class LtidClientConfig
    {
        public string HttpClientName { get; set; } = "ltid";
        public string Scheme { get; set; } = "http";
        public string Host { get; set; } = "ltid";
        public int Port { get; set; } = 80;
        public int PollingInterval { get; set; }
    }
}
