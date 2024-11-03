using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PruebaWEB.Models;
using PruebaWEB.Services;

namespace PruebaWEB.Pages
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public CreateModel(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("ApiUrl");
        }

        [BindProperty]
        public Pelicula Pelicula { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _httpClient.PostAsJsonAsync($"{_apiUrl}/peliculas", Pelicula);

            return RedirectToPage("./Index");
        }
    }
}
