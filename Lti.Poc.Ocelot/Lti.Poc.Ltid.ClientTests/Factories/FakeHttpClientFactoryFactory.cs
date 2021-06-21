using Newtonsoft.Json;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lti.Poc.Ltid.ClientTests.Factories
{
    public static class FakeHttpClientFactoryFactory
    {
        public static IHttpClientFactory GetJsonResultFromString(string body)
        {
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();

            var fakeHttpMessageHandler = new Fakes.FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            });

            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            httpClientFactoryMock.CreateClient(Arg.Any<string>()).Returns(fakeHttpClient);

            return httpClientFactoryMock;
        }
    }
}
