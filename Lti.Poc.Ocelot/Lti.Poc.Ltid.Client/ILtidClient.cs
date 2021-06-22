using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Primitives;
using Lti.Poc.Ltid.Models;
using System.Collections.Generic;

namespace Lti.Poc.Ltid.Client
{
    /// <summary>
    /// client for communicating with the environment
    /// </summary>
    public interface ILtidClient
    {
        /// <summary>
        /// validate current context session
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<bool> ValidateDebugSession(HttpContext context);
        /// <summary>
        /// validate current context session from host and session
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<bool> ValidateDebugSession(string hostName, string sessionKey);

        /// <summary>
        /// get information about all services
        /// </summary>
        Task<IEnumerable<LtiServiceInstanceDescription>> GetAllServiceInstanceDescriptions();

        /// <summary>
        /// group name indicating api services exposed to general consumption
        /// </summary>
        string ApiServiceGroupName { get; set; }

        /// <summary>
        /// return API service instance information
        /// API services are indicated by having a group value equal to ApiServiceGroupName
        /// </summary>
        Task<IEnumerable<LtiServiceInstanceDescription>> GetApiServiceDescriptions();

        /// <summary>
        /// return API service names
        /// API services are indicated by having a group value equal to ApiServiceGroupName
        /// </summary>
        Task<IEnumerable<string>> GetApiServiceNames();
    }
}
