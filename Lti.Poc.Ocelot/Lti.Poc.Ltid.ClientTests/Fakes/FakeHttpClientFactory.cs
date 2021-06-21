using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lti.Poc.Ltid.ClientTests.Fakes
{
    internal class FakeHttpClientFactory : IHttpClientFactory
    {
        private FakeHttpMessageHandler fakeMessageHandler;

        public FakeHttpClientFactory(FakeHttpMessageHandler fakeMessageHandler)
        {
            this.fakeMessageHandler = fakeMessageHandler;
        }
        public HttpClient CreateClient(string name)
        {
            return new HttpClient(this.fakeMessageHandler);
        }
    }
}
