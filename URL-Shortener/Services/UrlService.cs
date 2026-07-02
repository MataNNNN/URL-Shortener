using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using UrlShortener.Data;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public class UrlService
    {
        private readonly AppDbContext _db;
        long counter = 1;

        public UrlService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<UrlEntity>> GetUrls()
        {
            var urls = await _db.Urls.ToListAsync();
            return urls;

        }

        public async Task<string> GenerateShortenUrl(string url)
        {
            var entity = new UrlEntity
            {   
                OriginalUrl = url,
            };

            _db.Urls.Add(entity);
            await _db.SaveChangesAsync();

            string shortCode = Base62Encoder.Encode(entity.Id);
            entity.ShortCode = shortCode;

            await _db.SaveChangesAsync();
            return shortCode;
        }

        public async Task<string?> GetOriginalUrl(string code)
        {
            var urlEntry = await _db.Urls.FirstOrDefaultAsync(x => x.ShortCode == code);

            if (urlEntry == null)
            {
                return null;
            }

            return urlEntry.OriginalUrl;
        }
    }
}
