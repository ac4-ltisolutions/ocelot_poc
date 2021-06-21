using Xunit;
using Lti.Poc.Ltid.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lti.Poc.Ltid.ClientTests
{
    public class LtidClientTests
    {
        [Fact()]
        public async void GetServiceInstanceDescriptions_dafault_ReturnsResults()
        {
            var LtidClient_Ut = Factories.LtidClientTestFactory.GetForServiceList();

            var descriptions = await LtidClient_Ut.GetServiceInstanceDescriptions();

            Assert.NotEmpty(descriptions);
            Assert.Equal(4, descriptions.Count);
        }

        [Fact()]
        public async void GetApiServiceDescriptions_EmptyGroupName_Throws()
        {
            var LtidClient_Ut = Factories.LtidClientTestFactory.GetForServiceList();

            LtidClient_Ut.ApiServiceGroupName = String.Empty;

            await Assert.ThrowsAsync<ArgumentException>(async ()=> await LtidClient_Ut.GetApiServiceDescriptions());
        }

        [Fact()]
        public async void GetApiServiceDescriptions_dafault_ReturnsResults()
        {
            var LtidClient_Ut = Factories.LtidClientTestFactory.GetForServiceList();

            var descriptions = await LtidClient_Ut.GetApiServiceDescriptions();

            Assert.NotEmpty(descriptions);
            Assert.Equal(2, descriptions.Count);
        }
    }
}