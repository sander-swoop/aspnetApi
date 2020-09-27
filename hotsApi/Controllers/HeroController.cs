using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RestSharp;


namespace hotsApi.Controllers
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
            var client = new RestClient("https://hotsapi.net/api/v1");
            var request = new RestRequest("heroes", DataFormat.Json);

            var response = client.Get<List<Hero>>(request).Data;

            return response;
        }

         [HttpGet("{hero}")]
        public Ability Get(string heroName)
        {
            var client = new RestClient("https://hotsapi.net/api/v1");
            var request = new RestRequest("", DataFormat.Json);

            var response = client.Get<Dictionary<string, Ability>>(request);

            return response.Data[heroName];
        }
    }
}
