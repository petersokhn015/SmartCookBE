using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartCook.Domain.SpoonacularEntities.RecipeDetails;
using SmartCook.Domain.SpoonacularEntities;
using SmartCook.Infrastructure.Spoonacular;

namespace SmartCook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testcontroller : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public testcontroller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("Testing")]
        public async Task<IActionResult> Testing()
        {
            int recipeId = 716429;
            string apiResponse = "";
            TestModel model = new TestModel();
            try
            {
                var response = await _httpClient.GetAsync(new Uri(Constants.SpoonacularBaseUrl + recipeId + Constants.GetRecipeInfoByIdContinued));
                if (response.IsSuccessStatusCode)
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<TestModel>(apiResponse)!;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return Ok(model);

        }
    }
}
