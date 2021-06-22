using Lti.Poc.Ltid.Client;
using System.Net.Http;

namespace Lti.Poc.Ocelot.Extensions
{
    public interface ILtidClientFactory
    {
        ILtidClient Get(IHttpClientFactory clientFactory, LtidClientConfig config);
    }
}