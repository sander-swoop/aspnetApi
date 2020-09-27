using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RestSharp;


namespace hotsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroAbilityController : ControllerBase
    {
        private readonly ILogger<HeroAbilityController> _logger;

        public HeroAbilityController(ILogger<HeroAbilityController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{hero}")]
        public Ability Get(string heroName)
        {
            var client = new RestClient("https://hotsapi.net/api/v1");
            var request = new RestRequest("", DataFormat.Json);

            var response = client.Get<Dictionary<string, Ability>>(request);

            return response.Data[heroName];
        }

        [HttpGet]
        public Dictionary<string, Ability> Get()
        {
            var client = new RestClient("https://hotsapi.net/api/v1");
            var request = new RestRequest("constants/hero_abilities", DataFormat.Json);

            var response = client.Get<Dictionary<string, Ability>>(request);

            return response.Data;
        }
    }
}
