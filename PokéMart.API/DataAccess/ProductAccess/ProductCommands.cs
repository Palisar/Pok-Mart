namespace PokéMart.API.DataAccess.ProductAccess;

public record AddNewProductCommand(Product product) : IRequest<string>;
