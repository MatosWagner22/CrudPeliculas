using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaWEB.Models;
using PruebaWEB.Services;

namespace PruebaWEB.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public DeleteModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("ApiUrl");
        }

        [BindProperty]
        public Pelicula Pelicula { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pelicula = await _httpClient.GetFromJsonAsync<Pelicula>($"{_apiUrl}/peliculas/{id}");

            if (Pelicula == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/peliculas/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            return NotFound();
        }
    }
}
