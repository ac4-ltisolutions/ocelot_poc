using Ocelot.Logging;
using Ocelot.ServiceDiscovery.Providers;
using Ocelot.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lti.Poc.Ocelot.Extensions
{
    /// <summary>
    /// class to add timed polling with memory cache for any IServiceDiscoveryProvider
    /// </summary>
    public class PollingServiceDiscoveryProvider : IServiceDiscoveryProvider, IDisposable
    {
        private readonly IOcelotLogger logger;
        private readonly IServiceDiscoveryProvider serviceDiscoveryProvider;
        private Timer timer;
        private bool currentlyPolling;
        private List<Service> services;

        /// <summary>
        /// constructor that sets up timed polling
        /// </summary>
        /// <param name="pollingInterval"></param>
        /// <param name="factory"></param>
        /// <param name="serviceDiscoveryProvider"></param>
        public PollingServiceDiscoveryProvider(int pollingInterval, IOcelotLoggerFactory factory, IServiceDiscoveryProvider serviceDiscoveryProvider)
        {
            this.logger = factory.CreateLogger<PollingServiceDiscoveryProvider>();
            this.serviceDiscoveryProvider = serviceDiscoveryProvider;
            this.services = new List<Service>();

            this.timer = new Timer(async x =>
            {
                if (this.currentlyPolling)
                {
                    return;
                }

                this.currentlyPolling = true;
                await this.Poll();
                this.currentlyPolling = false;
            }, null, pollingInterval, pollingInterval);
        }

        public void Dispose()
        {
            this.timer?.Dispose();
            this.timer = null;
        }

        /// <summary>
        /// implements interface method from memory cached results
        /// </summary>
        /// <see cref="IServiceDiscoveryProvider"/>
        public Task<List<Service>> Get()
        {
            return Task.FromResult(this.services);
        }

        /// <summary>
        /// called periodically to refresh memory list
        /// </summary>
        private async Task Poll()
        {
            this.services = await this.serviceDiscoveryProvider.Get();
        }
    }
}
