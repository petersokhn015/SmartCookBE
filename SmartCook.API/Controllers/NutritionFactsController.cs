using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCook.Application.Spoonacular.Interfaces;

namespace SmartCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionFactsController : ControllerBase
    {
        private readonly INutritionFactsService _service;

        public NutritionFactsController(INutritionFactsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetNutritionFacts(string name)
        {
            try
            {
                var nutritionFacts = await _service.GetNutritionFacts(name);
                return Ok(nutritionFacts);
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exceptions
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return StatusCode(500, ex.Message);
            }

        }
    }
}
