using Newtonsoft.Json;
using AnimeCatalog.Models;

namespace AnimeCatalog.Services
{
    public class JikanApiClient
    {
        private HttpClient httpClient = new HttpClient();
        private HttpClient fallHttpClient = new HttpClient();
        public async Task<List<Anime>> GetTopAnimeAsync()
        {
            try
            {
                string url = "https://api.jikan.moe/v4/top/anime";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                AnimeDTO animeList = JsonConvert.DeserializeObject<AnimeDTO>(json);

                return animeList.Data.Select(entry => new Anime
                {
                    Title = entry.Title,
                    Synopsis = entry.Synopsis,
                    Images = entry.Images,
                    Score = entry.Score,
                    Genres = entry.Genres
                }).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching top anime: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Anime>> GetFallAnimeAsync()
        {
            try
            {
                string url = "https://api.jikan.moe/v4/seasons/2023/fall";
                HttpResponseMessage response = await fallHttpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                AnimeDTO animeList = JsonConvert.DeserializeObject<AnimeDTO>(json);

                return animeList.Data.Select(entry => new Anime
                {
                    Title = entry.Title,
                    Synopsis = entry.Synopsis,
                    Images = entry.Images,
                    Score = entry.Score,
                    Genres = entry.Genres
                }).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching fall anime: {ex.Message}");
                return null;
            }
        }
        public async Task<List<Anime>> SearchAnimeAsync(string query)
        {
            try
            {
                string url = $"https://api.jikan.moe/v4/anime?q={query}";
                HttpResponseMessage response = await httpClient.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                AnimeDTO animeList = JsonConvert.DeserializeObject<AnimeDTO>(json);

                return animeList.Data.Select(entry => new Anime
                {
                    Title = entry.Title,
                    Synopsis = entry.Synopsis,
                    Images = entry.Images,
                    Score = entry.Score,
                    Genres = entry.Genres
                }).ToList();
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching anime results: {ex.Message}");
                return null;
            }
        }

    }
}
