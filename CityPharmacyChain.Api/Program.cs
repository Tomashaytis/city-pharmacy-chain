using CityPharmacyChain.Api.Host.Services;
using CityPharmacyChain.Application;
using CityPharmacyChain.Application.Repository;
using CityPharmacyChain.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CityPharmacyChain.Api.Host;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            xmlFilename = $"{typeof(Pharmacy).Assembly.GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        builder.Services.AddDbContext<CityPharmacyChainContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion(new Version(8, 0, 39))));

        builder.Services.AddScoped<PharmacyService>();
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<PharmaceuticalGroupService>();
        builder.Services.AddScoped<PriceListEntryService>();
        builder.Services.AddScoped<PharmacyProductService>();

        builder.Services.AddScoped<PharmacyRepository>();
        builder.Services.AddScoped<ProductRepository>();
        builder.Services.AddScoped<PharmaceuticalGroupRepository>();
        builder.Services.AddScoped<PriceListEntryRepository>();
        builder.Services.AddScoped<PharmacyProductRepository>();

        builder.Services.AddAutoMapper(typeof(Mapping));

        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
