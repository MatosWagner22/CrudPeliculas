using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaWEB.Models;
using PruebaWEB.Services;

namespace PruebaWEB.Pages
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public EditModel(HttpClient httpClient, IConfiguration configuration)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _httpClient.PutAsJsonAsync($"{_apiUrl}/peliculas/{Pelicula.Id}", Pelicula);

            return RedirectToPage("./Index");
        }
    }
}
