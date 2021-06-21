using Lti.Poc.Ltid.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lti.Poc.Ltid.ClientTests.Factories
{
    internal static class LtidClientTestFactory
    {
        public static LtidClient GetForServiceList()
        {
            var httpFactory = FakeHttpClientFactoryFactory.GetJsonResultFromString(Data.JsonStrings.ServiceList);
            return new LtidClient(httpFactory)
            {
                ApiServiceGroupName = "api"
            };
        }
    }
}
