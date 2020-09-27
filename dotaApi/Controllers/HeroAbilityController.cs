using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RestSharp;
using dotaApi;

namespace dotaApi.Controllers
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
        public HeroAbility Get(string hero)
        {
            var client = new RestClient("https://api.opendota.com/api");
            var request = new RestRequest("constants/hero_abilities", DataFormat.Json);

            var response = client.Get<Dictionary<string, HeroAbility>>(request);

            return response.Data[hero];
        }

        [HttpGet]
        public Dictionary<string, HeroAbility> Get()
        {
            var client = new RestClient("https://api.opendota.com/api");
            var request = new RestRequest("constants/hero_abilities", DataFormat.Json);

            var response = client.Get<Dictionary<string, HeroAbility>>(request);

            return response.Data;
        }
    }
}
