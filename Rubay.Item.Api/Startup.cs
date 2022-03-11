using Microsoft.OpenApi.Models;
using Rubay.Sql.DataProvider.Database;
using Rubay.Sql.DataProvider.Interfaces;
using Rubay.Sql.DataProvider.Repositories;

namespace Rubay.Item.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rubay.Item.Api", Version = "v1" });
        });

        services.AddSingleton<IProductDataProvider, ProductDataProvider>(_ => new ProductDataProvider(Configuration.GetConnectionString("AccountDbContextConnection")));
        services.AddSingleton<IProductRepository, ProductRepository>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rubay.Item.Api v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}