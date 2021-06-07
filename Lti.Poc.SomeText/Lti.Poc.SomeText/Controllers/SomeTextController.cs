using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lti.Poc.SomeText.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SomeTextController : ControllerBase
    {
        private readonly ILogger<SomeTextController> _logger;

        public SomeTextController(ILogger<SomeTextController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {

            return (new List<string>()
            {
                "Yup, a string"
            })
            .ToArray();
        }
        
    }
}
