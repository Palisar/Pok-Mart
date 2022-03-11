using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokeMart.Core.Models;

namespace PokeMart.Contracts.Responses
{
    public class OrderResponse
    {
        public Guid OrderId { get; init; } = Guid.NewGuid();
        
        public DateTimeOffset OrderDateTime { get; init; }
        
        public AddressModel ShippingAddress { get; set; }
      
        public AddressModel BillingAddress { get; set; }
        
        public IEnumerable<ProductResponse> Products { get; set; }
        
        public decimal TotalPrice { get; set; }
    }
}
