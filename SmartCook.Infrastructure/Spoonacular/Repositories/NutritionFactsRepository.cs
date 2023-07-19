using Google.Apis.Http;
using Newtonsoft.Json;
using SmartCook.Application.Spoonacular.Interfaces;
using SmartCook.Domain.SpoonacularEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCook.Infrastructure.Spoonacular.Repositories
{
    public class NutritionFactsRepository : INutritionFactsRepository
    {
        private HttpClient _client;
        public NutritionFactsRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<Dish> GetNutritionFacts(string name)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://dietagram.p.rapidapi.com/apiFood.php?name={name}&lang=en"),
                Headers =
                {
                    { "X-RapidAPI-Key", Constants.RapidAPIKey },
                    { "X-RapidAPI-Host",Constants.RapidAPIHost },
                },
            };

            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<NutritionFacts>(body);
                var firstFood = apiResponse.dishes.FirstOrDefault();
                return firstFood;
            }

        }
    }
}
