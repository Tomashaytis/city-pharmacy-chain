using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CityPharmacyChain.Api
{
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
                var solutionName = "CityPharmacyChain.Domain";
                xmlFilename = $"{solutionName}.xml";
                options.IncludeXmlComments(Path.Combine("..", solutionName, "obj", "Debug", "net8.0", xmlFilename));
            });

            builder.Services.AddSingleton<PharmacyService>();
            builder.Services.AddSingleton<ProductService>();
            builder.Services.AddSingleton<PharmaceuticalGroupService>();
            builder.Services.AddSingleton<PriceListEntryService>();
            builder.Services.AddSingleton<PharmacyProductService>();

            builder.Services.AddSingleton<PharmacyRepository>();
            builder.Services.AddSingleton<ProductRepository>();
            builder.Services.AddSingleton<PharmaceuticalGroupRepository>();
            builder.Services.AddSingleton<PriceListEntryRepository>();
            builder.Services.AddSingleton<PharmacyProductRepository>();

            builder.Services.AddSingleton<DataBase>();

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
}
