using PruebaWEB.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace PruebaWEB.Services
{
    public class PeliculaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public PeliculaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("ApiUrl");
            _httpClient.BaseAddress = new Uri(_apiUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Pelicula>> GetPeliculasAsync()
        {
            var response = await _httpClient.GetAsync("peliculas");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Pelicula>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Pelicula> GetPeliculaAsync(int id)
        {
            var response = await _httpClient.GetAsync($"peliculas/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pelicula>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Pelicula> CreatePeliculaAsync(Pelicula pelicula)
        {
            var peliculaJson = new StringContent(
                JsonSerializer.Serialize(pelicula),
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("peliculas", peliculaJson);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pelicula>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdatePeliculaAsync(int id, Pelicula pelicula)
        {
            var peliculaJson = new StringContent(
                JsonSerializer.Serialize(pelicula),
                System.Text.Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PutAsync($"peliculas/{id}", peliculaJson);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePeliculaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"peliculas/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
