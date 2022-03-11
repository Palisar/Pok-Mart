using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMart.Core.Models
{
    public class AddressModel
    {
        public class AddressDetails
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string AddressLine1 { get; set; }

            public string AddressLine2 { get; set; }
            public string AddressLine3 { get; set; }
            [Required]
            public string Country { get; set; }

            public string State { get; set; }

            public string County { get; set; }
            [Required]
            public string PostCode { get; set; }

            [Required]
            public ContactDetails ContactDetails { get; set; }
        }
    }
}
