using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Api.Services;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<PharmacyService>();
            builder.Services.AddSingleton<ProductService>();
            builder.Services.AddSingleton<PharmaceuticalGroupService>();
            builder.Services.AddSingleton<PriceListEntryService>();
            builder.Services.AddSingleton<PharmacyProductService>();

            builder.Services.AddSingleton<IRepository<Pharmacy>, PharmacyRepository>();
            builder.Services.AddSingleton<IRepository<Product>, ProductRepository>();
            builder.Services.AddSingleton<IRepository<PharmaceuticalGroup>, PharmaceuticalGroupRepository>();
            builder.Services.AddSingleton<IRepository<PriceListEntry>, PriceListEntryRepository>();
            builder.Services.AddSingleton<IRepository<PharmacyProduct>, PharmacyProductRepository>();

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
