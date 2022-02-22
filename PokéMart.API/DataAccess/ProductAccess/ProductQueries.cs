namespace PokéMart.API.DataAccess.ProductAccess
{
    public record GetProductListQuery : IRequest<IEnumerable<Product>>;

    public record GetProductByIdQuery(string id) : IRequest<Product>;
}
