using Newtonsoft.Json;

namespace AnimeCatalog.Models
{
    public class AnimeDTO
    {
        [JsonProperty("data")]
        public List<Anime> Data { get; set; }
    }
}
