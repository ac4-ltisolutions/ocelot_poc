using Ocelot.Logging;
using Ocelot.ServiceDiscovery;
using Microsoft.Extensions.DependencyInjection;
using Lti.Poc.Ltid.Client;
using Ocelot.Configuration;
using System;
using System.Net.Http;

namespace Lti.Poc.Ocelot.Extensions.ServiceDiscovery
{
    public static class LtidProviderFactory
    {
        public static ServiceDiscoveryFinderDelegate Get = (provider, config, route) =>
        {
            var loggerFactory = provider.GetService<IOcelotLoggerFactory>();
            var httpFactory = provider.GetService<IHttpClientFactory>();
            var clientFactory = provider.GetService<ILtidClientFactory>();
            var clientConfig = config.ToLtidClientConfiguration();            

            var serviceDiscoverProvider = new LtidServiceDiscoveryProvider(clientConfig, clientFactory, httpFactory, loggerFactory);

            if (config.Type?.ToLower() == "realtime" || config.PollingInterval == 0)
            {
                return serviceDiscoverProvider;
            }

            return new PollingServiceDiscoveryProvider(config.PollingInterval, loggerFactory, serviceDiscoverProvider);
                        
        };

        public static LtidClientConfig ToLtidClientConfiguration(this ServiceProviderConfiguration config)
        {
            var clientConfig = new Ltid.Client.LtidClientConfig();
            if (!String.IsNullOrEmpty(config.Scheme)) clientConfig.Scheme = config.Scheme;
            if (!String.IsNullOrEmpty(config.Host)) clientConfig.Host = config.Host;
            if (config.Port > 0) clientConfig.Port = config.Port;
            if (config.PollingInterval > 0) clientConfig.PollingInterval = config.PollingInterval;
            return clientConfig;
        }
    }
}
