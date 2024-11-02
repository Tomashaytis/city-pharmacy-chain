using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

/// <summary>
/// Репозиторий для работы с сущностями класса связь препарат-аптека
/// </summary>
/// <param name="context">Контекст базы данных</param>
public class PharmacyProductRepository(CityPharmacyChainContext context) : IRepository<PharmacyProduct>
{
    /// <summary>
    /// Свободный идентификатор в базе данных для объектов класса связь препарат-аптека
    /// </summary>
    public int FreeId { get; private set; } = context.PharmacyProducts.Any() ? context.PharmacyProducts.Max(x => x.PharmacyProductId) + 1 : 1;

    /// <summary>
    /// Метод возвращает все объекты класса связь препарат-аптека из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса связь препарат-аптека</returns>
    public IEnumerable<PharmacyProduct> GetAll()
    {
        return [.. context.PharmacyProducts];
    }

    /// <summary>
    /// Метод возвращает объект класса связь препарат-аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <returns>Объект класса связь препарат-аптека</returns>
    public PharmacyProduct? GetById(int id)
    {
        return context.PharmacyProducts.FirstOrDefault(x => x.PharmacyProductId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса связь препарат-аптека в базу данных 
    /// </summary>
    /// <param name="pharmacyProduct">Объект класса связь препарат-аптека</param>
    /// <returns>Успешность операции добавления</returns>
    public bool Post(PharmacyProduct pharmacyProduct)
    {
        if (context.Products.FirstOrDefault(x => x.ProductId == pharmacyProduct.ProductId) is null)
            return false;
        if (context.Pharmacies.FirstOrDefault(x => x.PharmacyId == pharmacyProduct.PharmacyId) is null)
            return false;
        context.PharmacyProducts.Add(pharmacyProduct);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса связь препарат-аптека в базе данных
    /// </summary>
    /// <param name="pharmacyProduct">Объект класса связь препарат-аптека</param>
    /// <returns>Успешность операции модификации</returns>
    public bool Put(PharmacyProduct pharmacyProduct)
    {
        var value = GetById(pharmacyProduct.PharmacyProductId);
        if (value is null)
            return false;
        context.Entry(value).CurrentValues.SetValues(pharmacyProduct);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса связь препарат-аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        context.PharmacyProducts.Remove(value);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод возвращает свободный идентификатор в базе данных для объектов класса связь препарат-аптека
    /// </summary>
    /// <returns>Свободный идентификатор</returns>
    public int GetFreeId()
    {
        return FreeId++;
    }

    /// <summary>
    /// Метод возвращает список из топ 5 аптек по количеству и объёму продаж препарата с названием productName во временном интервале от start до end
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <param name="start">Начало временного интервала</param>
    /// <param name="end">Конец временного интервала</param>
    /// <returns>Список из топ 5 аптек по количеству и объёму продаж препарата с названием productName во временном интервале от start до end</returns>
    public List<Tuple<string?, int?, int?>> GetTopFivePharmaciesBySoldVolume(string productName, DateTime start, DateTime end)
    {
        var tmpMaxProductSoldVolumes = 
            (from pharmacy in context.Pharmacies
            join priceListEntry in context.Prices on pharmacy.PharmacyId equals priceListEntry.PharmacyId
            join product in context.Products on priceListEntry.ProductId equals product.ProductId
            where product.Name == productName && (priceListEntry.SaleDate > start && priceListEntry.SaleDate < end)
            group priceListEntry by priceListEntry.PharmacyId into groups
            select new
            {
                PharmacyId = groups.Key,
                SoldCount = groups.Count(),
                SoldVolume = groups.Sum(p => p.SoldCount),
            }).ToList();
        return [.. (from maxProductSoldVolume in tmpMaxProductSoldVolumes
                join pharmacy in context.Pharmacies on maxProductSoldVolume.PharmacyId equals pharmacy.PharmacyId
                orderby maxProductSoldVolume.SoldCount descending, maxProductSoldVolume.SoldVolume descending
                select new Tuple<string?, int?, int?>
                (
                    pharmacy.Name,
                    maxProductSoldVolume.SoldCount,
                    maxProductSoldVolume.SoldVolume
                )).Take(5)];
    }
}
