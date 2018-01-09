using Newtonsoft.Json;

namespace BookCatalog.Core.Models
{
    public class Catalog
    {
        [JsonProperty("book")]
        public Book[] Books { get; set; }
    }
}
