using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PokéMart.API.Services;
using System.Net.Http;

namespace PokéMart.Tests.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient _client;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(InMemoryProductService));
                        services.AddTransient<IProductService, InMemoryProductService>();
                    });
                });
            _client = appFactory.CreateClient();
        }

        //protected async Task AuthenticateAsync()
        //{
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", GetJwtAsync());
        //}

        //private async Task<string> GetJwtAsync()
        //{
        //}
    }
}
