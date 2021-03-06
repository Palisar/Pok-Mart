using MongoDB.Bson.Serialization.Attributes;
using PokeMart.Contracts.Responses;
using System.ComponentModel.DataAnnotations;
using PokeMart.Core.Models;

namespace PokéMart.API.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid OrderId { get; init; } = Guid.NewGuid();
        [Required]
        public DateTimeOffset OrderDateTime { get; init; }
        [Required]
        public AddressModel ShippingAddress { get; set; }
        [Required]
        public AddressModel BillingAddress { get; set; }
        [Required]
        public IEnumerable<ProductResponse> Products { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
