namespace PokéMart.API.DataAccess.ProductAccess;

public record AddNewProductCommand(Product product) : IRequest<Product>;

public record UpdateProductCommand(string id, Product product) : IRequest<bool>;

public  record DeleteProductCommand(string id) : IRequest<bool>;
