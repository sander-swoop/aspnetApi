using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly ILogger<HeroController> _logger;

        public HeroController(ILogger<HeroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Hero> Get()
        {
            var client = new RestClient("https://api.opendota.com/api");
            var request = new RestRequest("heroes", DataFormat.Json);

            var response = client.Get<List<Hero>>(request).Data;

            return response;
        }
    }
}
