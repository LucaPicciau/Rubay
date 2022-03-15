using Microsoft.OpenApi.Models;
using Rubay.Sql.DataProvider.Database;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICartDataProvider, CartDataProvider>(_ => new CartDataProvider(builder.Configuration.GetConnectionString("AccountDbContextConnection")));
builder.Services.AddSingleton<ICartRepository, CartRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rubay.Cart.Api", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
