namespace PokéMart.API.Models;

public class AddressDetails
{
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string County { get; set; }
    public string PostCode { get; set; }
    public ContactDetails ContactDetails { get; set; }
}
