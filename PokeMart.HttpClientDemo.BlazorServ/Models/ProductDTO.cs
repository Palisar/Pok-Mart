using System.ComponentModel.DataAnnotations;

namespace PokeMart.HttpClientDemo.BlazorServ.Models
{
    public class ProductDTO
    {
        public string Id { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
