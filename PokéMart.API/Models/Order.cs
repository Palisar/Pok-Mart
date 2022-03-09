using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using PokeMart.Contracts.Responses;

namespace PokéMart.API.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid OrderId { get; init; } = Guid.NewGuid();
        [Required]
        public AddressDetails ShippingAddress { get; set; }
        [Required]
        public AddressDetails BillingAddress { get; set; }
        [Required]
        public IEnumerable<ProductResponse> Products { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
