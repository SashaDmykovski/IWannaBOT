using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IWannaBOT.Controllers
{
    [ApiController]
    [Route("api/dishes")]
    public class DishesController : ControllerBase
    {
        private static readonly List<string> Dishes = new List<string>
        {
            "Зелений чай",
            "Чорний чай",
            "Трав'яний чай",
            "Фруктовий чай",
            "Ройбуш"
        };

        [HttpGet]
        public IActionResult GetDishes()
        {
            return Ok(Dishes.Select(text => new { text }));
        }
    }
}
