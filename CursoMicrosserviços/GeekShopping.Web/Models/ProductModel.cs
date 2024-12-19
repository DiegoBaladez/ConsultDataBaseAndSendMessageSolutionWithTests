using System.Text.Json.Serialization;

namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
