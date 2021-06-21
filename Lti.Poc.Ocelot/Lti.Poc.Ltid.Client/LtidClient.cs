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
        private readonly IHttpClientFactory clientFactory;

        public LtidClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        /// <summary>
        /// get information about all services
        /// </summary>
        /// <returns></returns>
        public async Task<List<LtiServiceInstanceDescription>> GetServiceInstanceDescriptions()
        {
            var services = new List<LtiServiceInstanceDescription>();

            var client = GetHttpClient();

#pragma warning disable SecurityIntelliSenseCS // MS Security rules violation
            HttpResponseMessage response = await client.GetAsync($"/services/list");
#pragma warning restore SecurityIntelliSenseCS // MS Security rules violation

            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception($"Unable to get service instance descriptions. HTTP{response.StatusCode}: {response.ReasonPhrase}");
            }

            services = JsonConvert.DeserializeObject<List<LtiServiceInstanceDescription>>(await response.Content.ReadAsStringAsync());

            return services;
        }

        /// <summary>
        /// group name indicating api services exposed to general consumption
        /// </summary>
        public string ApiServiceGroupName { get; set; }

        /// <summary>
        /// return instance information of only api groups
        /// </summary>
        /// <returns></returns>
        public async Task<List<LtiServiceInstanceDescription>> GetApiServiceDescriptions()
        {
            if (string.IsNullOrEmpty(this.ApiServiceGroupName))
                throw new System.ArgumentException("ApiServiceGroupName cannot be empty.");
                    
            return (await this.GetServiceInstanceDescriptions())
                .Where(o => o.Group == this.ApiServiceGroupName).ToList();
        }

        public async Task<List<LtiServiceInstanceDescription>> GetApiServiceNames()
        {
            return (await this.GetApiServiceDescriptions())
                .Where(o => o.Group == this.ApiServiceGroupName).ToList();
        }

        /// <summary>
        /// debug header for storing session key from client for debuging
        /// </summary>
        private const string DEBUGHEADER = "Lti-DebugSessionKey";

        public async Task<bool> ValidateSession(HttpContext context)
        {
            var sessionExists = false;
            if (context.Request.Headers.TryGetValue(DEBUGHEADER, out StringValues sessionKey))
            {
                sessionExists = await this.ValidateSession(context.Request.Host.Value, sessionKey.ToString());
            }
            return sessionExists;
        }

        public async Task<bool> ValidateSession(string hostName, string sessionKey)
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

        protected HttpClient GetHttpClient()
        {
            var client = clientFactory.CreateClient("ltid");
#pragma warning disable SecurityIntelliSenseCS // MS Security rules violation
            client.BaseAddress = new System.Uri("http://ltid");
#pragma warning restore SecurityIntelliSenseCS // MS Security rules violation
            return client;
        }
    }
}
