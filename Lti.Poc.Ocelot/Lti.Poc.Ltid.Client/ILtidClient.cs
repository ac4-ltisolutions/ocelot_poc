using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Primitives;

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
        Task<bool> ValidateSession(HttpContext context);
        /// <summary>
        /// validate current context session from host and session
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<bool> ValidateSession(string hostName, string sessionKey);
    }
}
