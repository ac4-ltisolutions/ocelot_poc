using Lti.Poc.Ltid.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lti.Poc.Ocelot.Extensions
{
    public class LtidClientFactory : ILtidClientFactory
    {
        public ILtidClient Get(IHttpClientFactory clientFactory, LtidClientConfig config)
        {
            return new LtidClient(clientFactory, config);
        }
    }
}
