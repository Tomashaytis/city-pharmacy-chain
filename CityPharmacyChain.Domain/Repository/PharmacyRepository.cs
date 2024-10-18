using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

/// <summary>
/// Репозиторий для работы с сущностями класса аптека
/// </summary>
/// <param name="dataBase">Объект базы данных</param>
public class PharmacyRepository(DataBase dataBase) : IRepository<Pharmacy>
{
    /// <summary>
    /// Метод возвращает все объекты класса аптека из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса аптека</returns>
    public IEnumerable<Pharmacy> GetAll()
    {
        return dataBase.Pharmacies;
    }

    /// <summary>
    /// Метод возвращает объект класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <returns>Объект класса аптека</returns>
    public Pharmacy? GetById(int id)
    {
        return dataBase.Pharmacies.Find(x => x.PharmacyId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса аптека в базу данных 
    /// </summary>
    /// <param name="pharmacy">Объект класса аптека</param>
    public void Post(Pharmacy pharmacy)
    {
        dataBase.Pharmacies.Add(pharmacy);
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
        value.PharmacyNumber = pharmacy.PharmacyNumber;
        value.DirectorFullName = pharmacy.DirectorFullName;
        value.PhoneNumber = pharmacy.PhoneNumber;
        value.Name = pharmacy.Name;
        value.Address = pharmacy.Address;
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
        dataBase.Pharmacies.Remove(value);
        return true;
    }

    /// <summary>
    /// Метод возвращает минимальный незанятый идентификатор в базе данных для объектов класса аптека
    /// </summary>
    /// <returns>Минимальный незанятый идентификатор</returns>
    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach (var value in dataBase.Pharmacies)
        {
            ids.Add(value.PharmacyId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }

    /// <summary>
    /// Метод возвращает список с характеристиками препаратов в аптеке с названием pharmacyName, упорядоченный по названию препарата
    /// </summary>
    /// <param name="pharmacyName">Название аптеки</param>
    /// <returns>Список с характеристиками препаратов в аптеке с названием pharmacyName, упорядоченный по названию препарата</returns>
    public List<Tuple<int?, string?, int?, string?, double?>> GetProductsForPharmacies(string pharmacyName)
    {
        return (from pharmacy in dataBase.Pharmacies
               join pharmacyProduct in dataBase.PharmacyProducts on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
               join product in dataBase.Products on pharmacyProduct.ProductId equals product.ProductId
               orderby product.Name
               where pharmacy.Name == pharmacyName
               select new Tuple<int?, string?, int?, string?, double?>
               (
                   product.ProductCode,
                   product.Name,
                   pharmacyProduct.Count,
                   product.ProductGroup,
                   pharmacyProduct.Price
               )).ToList();
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
                (from pharmacy in dataBase.Pharmacies
                 join priceListEntry in dataBase.Prices on pharmacy.PharmacyId equals priceListEntry.PharmacyId
                 join product in dataBase.Products on priceListEntry.ProductId equals product.ProductId
                 where pharmacy.Address is not null && pharmacy.Address.Contains(district) && product.Name == productName
                 group priceListEntry by priceListEntry.PharmacyId into result
                 select new
                 {
                     PharmacyId = result.Key,
                     SoldVolume = result.Sum(p => p.SoldCount),
                 }).ToList();
         return (from entry in tmpPharmaciesWithBigProductSoldVolumes
                join pharmacy in dataBase.Pharmacies on entry.PharmacyId equals pharmacy.PharmacyId
                where entry.SoldVolume > volume
                select pharmacy.Name).ToList();
    }

    /// <summary>
    /// Метод возвращает список из названий аптек, в которых препарат с названием productName продаётся с минимальной ценой
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Список из названий аптек, в которых препарат с названием productName продаётся с минимальной ценой</returns>
    public List<string> GetPharmaciesWithMinProductPrice(string productName)
    {
        var tmpPharmaciesWithMinProductPrice =
            (from pharmacy in dataBase.Pharmacies
             join pharmacyProduct in dataBase.PharmacyProducts on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
             join product in dataBase.Products on pharmacyProduct.ProductId equals product.ProductCode
             where product.Name == productName
             group pharmacyProduct by pharmacy.PharmacyNumber into result
             select new
             {
                 PharmacyId = result.Key,
                 SoldVolume = result.Min(p => p.Price),
             }).ToList();
        return (from entry in tmpPharmaciesWithMinProductPrice
                join pharmacy in dataBase.Pharmacies on entry.PharmacyId equals pharmacy.PharmacyId
                let min = tmpPharmaciesWithMinProductPrice.Min(p => p.SoldVolume)
                where entry.SoldVolume < min + 0.01 && entry.SoldVolume > min - 0.01
                select pharmacy.Name).ToList();
    }
}
