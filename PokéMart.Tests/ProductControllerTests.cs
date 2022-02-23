namespace PokéMart.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void AddProduct_Then_ReturnOK200()
        {
            var mock = new Mock<Product>();
            mock.Setup(prod => prod.Id).Returns("daw4e543");
            mock.Setup(prod => prod.Name).Returns("Thing");
            mock.Setup(prod => prod.Description).Returns("Does stuff");
            mock.Setup(prod => prod.Price).Returns(100);
        }
    }
}
