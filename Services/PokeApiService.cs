using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PokemonEH.Services
{
    public class PokeApiService
    {
        private readonly HttpClient _httpClient;

        public PokeApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://pokeapi.co/api/v2/")
            };
        }

        public async Task<JObject> GetPokemonByNameAsync(string name)
        {
            var response = await _httpClient.GetAsync($"pokemon/{name}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JObject.Parse(jsonString);
            }

            return null;
        }
    }
}
