using PokéMart.Tests.IntegrationTests;
using System.Threading.Tasks;

namespace PokeMart.Tests.IntegrationsTests
{
    public class ProductControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAllProducts_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/product");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetProductById_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/product/6214cd9ff357c214a3f3e0b6");
            response.EnsureSuccessStatusCode();
        }

        //[Fact]
        //public async Task AddProductEndpoiont_Then_ReturnsStatusCodeOk()
        //{

        //}
    }
}
