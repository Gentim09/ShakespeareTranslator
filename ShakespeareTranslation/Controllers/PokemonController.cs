using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ShakespeareTranslation.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        readonly ITranslate translator;
        readonly ILogger<PokemonController> logger;
        public PokemonController(ITranslate translator, ILogger<PokemonController> logger)
        {
            this.translator = translator;
            this.logger = logger;
        }

        [HttpGet("{pokemonName}")]
        public async Task<IActionResult> Get(string pokemonName)
        {
            try
            {
                logger.LogInformation("string input" + pokemonName);
                var translated = await translator.TranslateTextAsync(pokemonName);
                logger.LogInformation("result" + translated);
                return Ok(new { name = pokemonName, description = translated });
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
