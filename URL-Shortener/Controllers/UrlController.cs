using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly UrlService _urlService;

        public UrlController(UrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet("api/getAll")]
        public async Task<IActionResult> GetAllUrls()
        {
            var urls = await _urlService.GetUrls();
            return Ok(urls);
        }

        [HttpPost("api/shorten")]
        public async Task<IActionResult> Shorten([FromBody] UrlRequest request)
        {
            var shortcode = await _urlService.GenerateShortenUrl(request.Url);

            return Ok(shortcode);
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal(string shortCode)
        {
            string? url = await _urlService.GetOriginalUrl(shortCode);

            if (url == null)
                return NotFound();

            return Redirect(url);
        }
    }
}