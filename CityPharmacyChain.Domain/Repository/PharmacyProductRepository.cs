using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

/// <summary>
/// Репозиторий для работы с сущностями класса связь препарат-аптека
/// </summary>
/// <param name="dataBase">Объект базы данных</param>
public class PharmacyProductRepository(DataBase dataBase) : IRepository<PharmacyProduct>
{
    /// <summary>
    /// Метод возвращает все объекты класса связь препарат-аптека из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса связь препарат-аптека</returns>
    public IEnumerable<PharmacyProduct> GetAll()
    {
        return dataBase.PharmacyProducts;
    }

    /// <summary>
    /// Метод возвращает объект класса связь препарат-аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <returns>Объект класса связь препарат-аптека</returns>
    public PharmacyProduct? GetById(int id)
    {
        return dataBase.PharmacyProducts.Find(x => x.PharmacyProductId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса связь препарат-аптека в базу данных 
    /// </summary>
    /// <param name="pharmacyProduct">Объект класса связь препарат-аптека</param>
    public void Post(PharmacyProduct pharmacyProduct)
    {
        dataBase.PharmacyProducts.Add(pharmacyProduct);
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
        value.ProductId = pharmacyProduct.ProductId;
        value.PharmacyId = pharmacyProduct.PharmacyId;
        value.Price = pharmacyProduct.Price;
        value.Count = pharmacyProduct.Count;
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
        dataBase.PharmacyProducts.Remove(value);
        return true;
    }

    /// <summary>
    /// Метод возвращает минимальный незанятый идентификатор в базе данных для объектов класса связь препарат-аптека
    /// </summary>
    /// <returns>Минимальный незанятый идентификатор</returns>
    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach (var value in dataBase.PharmacyProducts)
        {
            ids.Add(value.PharmacyProductId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }

    /// <summary>
    /// Метод возвращает список из топ 5 аптек по количеству и объёму продаж препарата с названием productName во временном интервале от start до end
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <param name="start">Начало временного интервала</param>
    /// <param name="end">Конец временного интервала</param>
    /// <returns>Список из топ 5 аптек по количеству и объёму продаж препарата с названием productName во временном интервале от start до end</returns>
    public List<Tuple<string, int, int>> GetTopFivePharmaciesBySoldVolume(string productName, DateTime start, DateTime end)
    {
        var tmpMaxProductSoldVolumes = 
            (from pharmacy in dataBase.Pharmacies
            join priceListEntry in dataBase.Prices on pharmacy.PharmacyId equals priceListEntry.PharmacyId
            join product in dataBase.Products on priceListEntry.ProductId equals product.ProductId
            where product.Name == productName && (priceListEntry.SaleDate > start && priceListEntry.SaleDate < end)
            group priceListEntry by priceListEntry.PharmacyId into groups
            select new
            {
                PharmacyId = groups.Key,
                SoldCount = groups.Count(),
                SoldVolume = groups.Sum(p => p.SoldCount),
            }).ToList();
        return (from maxProductSoldVolume in tmpMaxProductSoldVolumes
                join pharmacy in dataBase.Pharmacies on maxProductSoldVolume.PharmacyId equals pharmacy.PharmacyId
                orderby maxProductSoldVolume.SoldCount descending, maxProductSoldVolume.SoldVolume descending
                select new Tuple<string, int, int>
                (
                    pharmacy.Name,
                    maxProductSoldVolume.SoldCount,
                    maxProductSoldVolume.SoldVolume
                )).Take(5).ToList();
    }
}
