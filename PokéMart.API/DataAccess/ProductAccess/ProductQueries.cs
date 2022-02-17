namespace PokéMart.API.DataAccess.ProductAccess
{
    public record GetProductListQuery : IRequest<IEnumerable<Product>>;
}
