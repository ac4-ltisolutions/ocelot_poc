using Lti.Poc.Ltid.Client;
using Ocelot.Logging;
using Ocelot.ServiceDiscovery.Providers;
using Ocelot.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lti.Poc.Ocelot.Extensions.ServiceDiscovery
{
    public class LtidServiceDiscoveryProvider : IServiceDiscoveryProvider
    {
        public int DownstreamPort { get; set; } = 80;

        private LtidClientConfig clientConfig;
        private ILtidClient ltidClient;
        private IOcelotLogger logger;

        public LtidServiceDiscoveryProvider(LtidClientConfig clientConfig, ILtidClientFactory clientFactory, IHttpClientFactory httpFactory, IOcelotLoggerFactory loggerFactory)
        {
            this.clientConfig = clientConfig;
            this.ltidClient = clientFactory.Get(httpFactory, this.clientConfig);
            this.logger = loggerFactory.CreateLogger<LtidServiceDiscoveryProvider>();
        }

        public async Task<List<Service>> Get()
        {
            var services = new List<Service>();

            foreach(var serviceDescription in await this.ltidClient.GetAllServiceInstanceDescriptions())
            {
                services.Add(this.ConvertServiceDescription(serviceDescription));
            }

            return services;
        }

        private Service ConvertServiceDescription(Ltid.Models.LtiServiceInstanceDescription serviceDescription)
        {
            var hostPort = new ServiceHostAndPort(serviceDescription.ServiceName, this.DownstreamPort);
            return new Service(serviceDescription.ServiceName, hostPort, serviceDescription.ServiceName, "na", null);
        }
    }
}
