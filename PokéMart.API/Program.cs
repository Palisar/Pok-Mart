using PokéMart.API.Models.MongoAccessConfigurations;
using PokéMart.API.Services;
using PokéMart.API.Services.OrderService;
using PokéMart.API.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

//add Mongo Configurations from User Secrets
builder.Services.Configure<ProductMongoDB>(
    builder.Configuration.GetSection("ProductMongoDB"));
builder.Services.Configure<OrderMongoDB>(
    builder.Configuration.GetSection("OrderMongoDB"));

//add logging
builder.Logging.AddDebug();
builder.Logging.AddConsole();

// Add services to the container
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }