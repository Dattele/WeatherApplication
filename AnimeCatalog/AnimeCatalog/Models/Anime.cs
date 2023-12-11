
using Newtonsoft.Json;
using SQLite;

namespace AnimeCatalog.Models
{
    public class Anime
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("images")]
        public AnimeImages Images { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
    }
    public class AnimeImages
    {
        [JsonProperty("jpg")]
        public JpgImage Jpg { get; set; }
    }

    public class JpgImage
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
    public class Genre
    {
        [JsonProperty("name")]
        public string GenreName { get; set; }
    }
}
