namespace PokéMart.API.DataAccess.ProductAccess
{
    public class ProductCommands
    {
        public record AddNewProductCommand(Product product) : IRequest<string>;
    }
}
