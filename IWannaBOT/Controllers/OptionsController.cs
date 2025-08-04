using Microsoft.AspNetCore.Mvc;

namespace IWannaBOT.Controllers
{
    [ApiController]
    [Route("api/options")]
    public class OptionsController : ControllerBase
    {
        private static readonly List<string> Options = new List<string>
        {
            "НІЧОГО",
            "Ванільний БЕГЕМОТ",
            "Чорні",
            "Фруктовий",
            "Любий"
        };

        [HttpGet]
        public IActionResult GetOptions()
        {
            return Ok(Options.Select(text => new { text }));
        }
    }
}
