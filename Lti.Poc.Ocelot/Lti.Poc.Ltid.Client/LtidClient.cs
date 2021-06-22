using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Primitives;
using Lti.Poc.Ltid.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lti.Poc.Ltid.Client
{
    /// <summary>
    /// concreet ltid client
    /// <see cref="ILtidClient"/>
    /// </summary>
    public class LtidClient : ILtidClient
    {
        /// <summary>
        /// abstracted http client factory
        /// </summary>
        protected readonly IHttpClientFactory clientFactory;
        protected readonly LtidClientConfig config;

        public LtidClient(IHttpClientFactory clientFactory, LtidClientConfig config)
        {
            this.clientFactory = clientFactory;
            this.config = config;
        }

        /// <summary>
        /// get information about all services
        /// </summary>
        public async Task<IEnumerable<LtiServiceInstanceDescription>> GetAllServiceInstanceDescriptions()
        {
            var client = GetHttpClient();

#pragma warning disable SecurityIntelliSenseCS // MS Security rules violation
            HttpResponseMessage response = await client.GetAsync($"/services/list");
#pragma warning restore SecurityIntelliSenseCS // MS Security rules violation

            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception($"Unable to get service instance descriptions. HTTP{response.StatusCode}: {response.ReasonPhrase}");
            }

            var services = JsonConvert.DeserializeObject<List<LtiServiceInstanceDescription>>(await response.Content.ReadAsStringAsync());

            return services;
        }

        /// <summary>
        /// return all service names only
        /// </summary>
        public async Task<IEnumerable<string>> GetAllServiceNames()
        {
            return GetServiceNames(await this.GetAllServiceInstanceDescriptions());
        }

        /// <summary>
        /// group name indicating api services exposed to general consumption
        /// </summary>
        public string ApiServiceGroupName { get; set; }

        /// <summary>
        /// return API service instance information
        /// API services are indicated by having a group value equal to ApiServiceGroupName
        /// </summary>
        public async Task<IEnumerable<LtiServiceInstanceDescription>> GetApiServiceDescriptions()
        {
            if (string.IsNullOrEmpty(this.ApiServiceGroupName))
                throw new System.ArgumentException("ApiServiceGroupName cannot be empty.");
                    
            return (await this.GetAllServiceInstanceDescriptions())
                .Where(o => o.Group == this.ApiServiceGroupName).ToList();
        }

        /// <summary>
        /// return API service names
        /// API services are indicated by having a group value equal to ApiServiceGroupName
        /// </summary>
        public async Task<IEnumerable<string>> GetApiServiceNames()
        {
            return GetServiceNames(await this.GetApiServiceDescriptions());
        }

        /// <summary>
        /// extracts service names from service collection
        /// </summary>
        /// <param name="services"></param>
        protected IEnumerable<string> GetServiceNames(IEnumerable<LtiServiceInstanceDescription> services)
        {
            return services.Select(o => o.ServiceName).ToList();
        }

        /// <summary>
        /// debug header for storing session key from client for debuging
        /// </summary>
        protected const string DEBUGHEADER = "Lti-DebugSessionKey";

        public async Task<bool> ValidateDebugSession(HttpContext context)
        {
            var sessionExists = false;
            if (context.Request.Headers.TryGetValue(DEBUGHEADER, out StringValues sessionKey))
            {
                sessionExists = await this.ValidateDebugSession(context.Request.Host.Value, sessionKey.ToString());
            }
            return sessionExists;
        }

        public async Task<bool> ValidateDebugSession(string hostName, string sessionKey)
        {
            var client = GetHttpClient();

#pragma warning disable SecurityIntelliSenseCS // MS Security rules violation
            var response = await client.GetAsync($"session/{hostName}/{sessionKey}/exists");
#pragma warning restore SecurityIntelliSenseCS // MS Security rules violation

            if (response.IsSuccessStatusCode)
            {
                var exists = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                return exists;
            }
            return false;
        }

        /// <summary>
        /// use Http Client factory to get Http Client based on configuration
        /// </summary>
        /// <returns></returns>
        protected HttpClient GetHttpClient()
        {
            var client = clientFactory.CreateClient(this.config.HttpClientName);
#pragma warning disable SecurityIntelliSenseCS // MS Security rules violation
            client.BaseAddress = new System.Uri($"{this.config.Scheme}://{this.config.Host}:{this.config.Port}");
#pragma warning restore SecurityIntelliSenseCS // MS Security rules violation
            return client;
        }
    }
}
