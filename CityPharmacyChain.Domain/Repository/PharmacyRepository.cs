using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

/// <summary>
/// Репозиторий для работы с сущностями класса аптека
/// </summary>
/// <param name="context">Контекст базы данных</param>
public class PharmacyRepository(CityPharmacyChainContext context) : IRepository<Pharmacy>
{
    /// <summary>
    /// Свободный идентификатор в базе данных для объектов класса аптека
    /// </summary>
    public int FreeId { get; private set; } = context.Pharmacies.Any() ? context.Pharmacies.Max(x => x.PharmacyId) + 1 : 1;

    /// <summary>
    /// Метод возвращает все объекты класса аптека из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса аптека</returns>
    public IEnumerable<Pharmacy> GetAll()
    {
        return [.. context.Pharmacies];
    }

    /// <summary>
    /// Метод возвращает объект класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <returns>Объект класса аптека</returns>
    public Pharmacy? GetById(int id)
    {
        return context.Pharmacies.FirstOrDefault(x => x.PharmacyId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса аптека в базу данных 
    /// </summary>
    /// <param name="pharmacy">Объект класса аптека</param>
    /// <returns>Успешность операции добавления</returns>
    public bool Post(Pharmacy pharmacy)
    {
        context.Pharmacies.Add(pharmacy);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса аптека в базе данных
    /// </summary>
    /// <param name="pharmacy">Объект класса аптека</param>
    /// <returns>Успешность операции модификации</returns>
    public bool Put(Pharmacy pharmacy)
    {
        var value = GetById(pharmacy.PharmacyId);
        if (value is null)
            return false;
        context.Entry(value).CurrentValues.SetValues(pharmacy);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        context.Pharmacies.Remove(value);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод возвращает свободный идентификатор в базе данных для объектов класса аптека
    /// </summary>
    /// <returns>Свободный идентификатор</returns>
    public int GetFreeId()
    {
        return FreeId++;
    }

    /// <summary>
    /// Метод возвращает список с характеристиками препаратов в аптеке с названием pharmacyName, упорядоченный по названию препарата
    /// </summary>
    /// <param name="pharmacyName">Название аптеки</param>
    /// <returns>Список с характеристиками препаратов в аптеке с названием pharmacyName, упорядоченный по названию препарата</returns>
    public List<Tuple<int?, string?, int?, string?, decimal?>> GetProductsForPharmacies(string pharmacyName)
    {
        return [.. (from pharmacy in context.Pharmacies
               join pharmacyProduct in context.PharmacyProducts on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
               join product in context.Products on pharmacyProduct.ProductId equals product.ProductId
               orderby product.Name
               where pharmacy.Name == pharmacyName
               select new Tuple<int?, string?, int?, string?, decimal?>
               (
                   product.ProductCode,
                   product.Name,
                   pharmacyProduct.Count,
                   product.ProductGroup,
                   pharmacyProduct.Price
               ))];
    }

    /// <summary>
    /// Метод возвращает список из названий аптек в районе district, продавших препарат с названием productName в большем объёме, чем объём volume
    /// </summary>
    /// <param name="district">Район аптеки</param>
    /// <param name="productName">Название препарата</param>
    /// <param name="volume">Объём продажи</param>
    /// <returns>Список из названий аптек в районе district, продавших препарат с названием productName в большем объёме, чем объём volume</returns>
    public List<string> GetPharmaciesWithLargeProductSoldVolume(string district, string productName, int volume)
    {
        var tmpPharmaciesWithBigProductSoldVolumes =
                (from pharmacy in context.Pharmacies
                 join priceListEntry in context.Prices on pharmacy.PharmacyId equals priceListEntry.PharmacyId
                 join product in context.Products on priceListEntry.ProductId equals product.ProductId
                 where pharmacy.Address != null && pharmacy.Address.Contains(district) && product.Name == productName
                 group priceListEntry by priceListEntry.PharmacyId into result
                 select new
                 {
                     PharmacyId = result.Key,
                     SoldVolume = result.Sum(p => p.SoldCount),
                 }).ToList();
         return [.. (from entry in tmpPharmaciesWithBigProductSoldVolumes
                join pharmacy in context.Pharmacies on entry.PharmacyId equals pharmacy.PharmacyId
                where entry.SoldVolume > volume
                select pharmacy.Name)];
    }

    /// <summary>
    /// Метод возвращает список из названий аптек, в которых препарат с названием productName продаётся с минимальной ценой
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Список из названий аптек, в которых препарат с названием productName продаётся с минимальной ценой</returns>
    public List<string> GetPharmaciesWithMinProductPrice(string productName)
    {
        var tmpPharmaciesWithMinProductPrice =
            (from pharmacy in context.Pharmacies
             join pharmacyProduct in context.PharmacyProducts on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
             join product in context.Products on pharmacyProduct.ProductId equals product.ProductCode
             where product.Name == productName
             group pharmacyProduct by pharmacy.PharmacyNumber into result
             select new
             {
                 PharmacyId = result.Key,
                 SoldVolume = result.Min(p => p.Price),
             }).ToList();
        return [.. (from entry in tmpPharmaciesWithMinProductPrice
                join pharmacy in context.Pharmacies on entry.PharmacyId equals pharmacy.PharmacyId
                let min = tmpPharmaciesWithMinProductPrice.Min(p => p.SoldVolume)
                where entry.SoldVolume < min + 0.01m && entry.SoldVolume > min - 0.01m
                select pharmacy.Name)];
    }
}
