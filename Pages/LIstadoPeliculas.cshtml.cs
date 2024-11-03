using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaWEB.Models;
using PruebaWEB.Services;

namespace PruebaWEB.Pages
{
    public class LIstadoPeliculas : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public LIstadoPeliculas(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("ApiUrl");
        }

        public IList<Pelicula> Peliculas { get; set; }

        public async Task OnGetAsync()
        {
            Peliculas = await _httpClient.GetFromJsonAsync<IList<Pelicula>>($"{_apiUrl}/peliculas");
        }

    }
}