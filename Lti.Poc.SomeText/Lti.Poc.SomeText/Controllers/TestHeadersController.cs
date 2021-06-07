using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lti.Poc.SomeText.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestHeadersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var headers = new List<string>();
            foreach(var headerPair in Request.Headers)
            {
                headers.Add($"{headerPair.Key}:{headerPair.Value}");
            }
            return headers.ToArray();
        }
    }
}
