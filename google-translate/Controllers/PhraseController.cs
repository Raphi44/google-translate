using google_translate.Models;
using google_translate.services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace google_translate.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PhraseController : ControllerBase
    {
        private readonly IPhraseService _phraseService;
        public PhraseController(IPhraseService phraseService)
        {
            _phraseService = phraseService;
        }

        // GET api/<PhraseController>/5
        [HttpGet("{id}")]
        public ActionResult<Phrase> Get(string key)
        {
            var phrase = _phraseService.Get(key);
            if (phrase == null)
            {
                return NotFound($"phrase with key = {key} not found");
            }
            return phrase;
        }

        // POST api/<PhraseController>
        [HttpPost]
        public ActionResult<Phrase> Post([FromBody] Phrase phrase)
        {
            _phraseService.Create(phrase);
            return CreatedAtAction(nameof(Get), new { key = phrase.key }, phrase);


        }
    }
}
