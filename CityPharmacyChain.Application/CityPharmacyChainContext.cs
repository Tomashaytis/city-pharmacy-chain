using CityPharmacyChain.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CityPharmacyChain.Application;

/// <summary>
/// Контекст для связи с базой данных
/// </summary>
/// <param name="options">Параметры для контекста</param>
public class CityPharmacyChainContext(DbContextOptions<CityPharmacyChainContext> options) : DbContext(options)
{
    /// <summary>
    /// Таблица для фармацевтических групп
    /// </summary>
    public DbSet<PharmaceuticalGroup> PharmaceuticalGroups { get; set; }

    /// <summary>
    /// Таблица для аптек
    /// </summary>
    public DbSet<Pharmacy> Pharmacies { get; set; }

    /// <summary>
    /// Таблица для связей препарат-аптека
    /// </summary>
    public DbSet<PharmacyProduct> PharmacyProducts { get; set; }

    /// <summary>
    /// Таблица для записей в прайс-листе
    /// </summary>
    public DbSet<PriceListEntry> Prices { get; set; }

    /// <summary>
    /// Таблица для препаратов
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Переопределение метода OnModelCreating для установки связей между таблицами
    /// </summary>
    /// <param name="modelBuilder">API для работы с базой данных</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PharmaceuticalGroup>()
            .HasOne(p => p.Product)
            .WithMany(p => p.PharmaceuticalGroups)
            .HasForeignKey(e => e.ProductId);

        modelBuilder.Entity<PharmacyProduct>()
            .HasOne(p => p.Product)
            .WithMany(p => p.PharmacyProducts)
            .HasForeignKey(e => e.ProductId);

        modelBuilder.Entity<PharmacyProduct>()
            .HasOne(p => p.Pharmacy)
            .WithMany(p => p.PharmacyProducts)
            .HasForeignKey(e => e.PharmacyId);

        modelBuilder.Entity<PriceListEntry>()
            .HasOne(p => p.Product)
            .WithMany(p => p.PriceListEntries)
            .HasForeignKey(e => e.ProductId);

        modelBuilder.Entity<PriceListEntry>()
            .HasOne(p => p.Pharmacy)
            .WithMany(p => p.PriceListEntries)
            .HasForeignKey(e => e.PharmacyId);

        modelBuilder.Entity<PriceListEntry>()
            .Property(p => p.PaymentType)
            .HasConversion(type => type.ToString(), type => (PaymentType)Enum.Parse(typeof(PaymentType), type));
    }
}