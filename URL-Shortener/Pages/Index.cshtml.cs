using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UrlShortener.Models;

namespace UrlShortener.Pages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public IndexModel(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }
    [BindProperty]
    public string Url { get; set; }

    public List<UrlEntity> Urls { get; set; } = new();

    public string ErrorMessage = "";

    public async Task OnGetAsync()
    {
        Urls = await _httpClient.GetFromJsonAsync<List<UrlEntity>>(
            "http://localhost:5101/api/getAll"
        ) ?? new();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!Uri.TryCreate(Url, UriKind.Absolute, out _))
        {
            ErrorMessage = "Invalid URL";
            return Page();
        }

        var request = new UrlRequest
        {
            Url = Url
        };
        var response = await _httpClient.PostAsJsonAsync(
            "http://localhost:5101/api/shorten",
            request
            );

        return RedirectToPage();
    }
}