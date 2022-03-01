namespace PokeMart.Contracts.Responses
{
    public class ProductResponse
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}

//TODO : Add Mapster for object mapping