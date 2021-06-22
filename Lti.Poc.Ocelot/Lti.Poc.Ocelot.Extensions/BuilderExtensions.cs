using Ocelot.DependencyInjection;
using Ocelot.Configuration.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ocelot.Middleware;
using Ocelot.ServiceDiscovery;

namespace Lti.Poc.Ocelot.Extensions
{
    /// <summary>
    /// class for housing extensions to IOcelotBuilder which is retruned
    /// </summary>
    public static class BuilderExtensions
    {
        public static IOcelotBuilder AddLtidForOcelotAutorouting(this IOcelotBuilder builder)
        {
            builder.Services.AddSingleton<ServiceDiscoveryFinderDelegate>(ServiceDiscovery.LtidProviderFactory.Get);
            builder.Services.AddSingleton<ILtidClientFactory, LtidClientFactory>();
            return builder;
        }
    }
}
