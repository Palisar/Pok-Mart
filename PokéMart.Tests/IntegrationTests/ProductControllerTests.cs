using PokéMart.Tests.IntegrationTests;
using System.Threading.Tasks;

namespace PokeMart.Tests.IntegrationsTests
{
    public class ProductControllerTests : IntegrationTest
    {
        [Theory]
        [InlineData("/api/product")]
        public async Task GetAllProducts_ReturnsOk(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
        }
    }
}
