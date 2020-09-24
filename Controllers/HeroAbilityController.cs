using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace helloworld_api.Controllers
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

        [HttpGet("{heroName}")]
        public HeroAbility Get(string heroName)
        {
            var client = new RestClient("https://api.opendota.com/api");
            var request = new RestRequest("constants/hero_abilities", DataFormat.Json);

            var response = client.Get<Dictionary<string, HeroAbility>>(request);

            return response.Data[heroName];
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
