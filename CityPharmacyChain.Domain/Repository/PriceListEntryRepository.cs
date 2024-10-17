using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

/// <summary>
/// Репозиторий для работы с сущностями класса запись в прайс-листе
/// </summary>
/// <param name="dataBase">Объект базы данных</param>
public class PriceListEntryRepository(DataBase dataBase) : IRepository<PriceListEntry>
{
    /// <summary>
    /// Метод возвращает все объекты класса запись в прайс-листе из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса запись в прайс-листе</returns>
    public IEnumerable<PriceListEntry> GetAll()
    {
        return dataBase.Prices;
    }

    /// <summary>
    /// Метод возвращает объект класса запись в прайс-листе из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи в прайс-листе</param>
    /// <returns>Объект класса запись в прайс-листе</returns>
    public PriceListEntry? GetById(int id)
    {
        return dataBase.Prices.Find(x => x.PriceListEntryId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса запись в прайс-листе в базу данных 
    /// </summary>
    /// <param name="priceListEntry">Объект класса запись в прайс-листе</param>
    public void Post(PriceListEntry priceListEntry)
    {
        dataBase.Prices.Add(priceListEntry);
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса запись в прайс-листе в базе данных
    /// </summary>
    /// <param name="priceListEntry">Объект класса запись в прайс-листе</param>
    /// <returns>Успешность операции модификации</returns>
    public bool Put(PriceListEntry priceListEntry)
    {
        var value = GetById(priceListEntry.PriceListEntryId);
        if (value is null)
            return false;
        value.ProductId = priceListEntry.ProductId;
        value.PharmacyId = priceListEntry.PharmacyId;
        value.Manufacturer = priceListEntry.Manufacturer;
        value.SaleDate = priceListEntry.SaleDate;;
        value.PaymentType = priceListEntry.PaymentType;
        value.SoldCount = priceListEntry.SoldCount;
        return true;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса запись в прайс-листе из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи в прайс-листе</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        dataBase.Prices.Remove(value);
        return true;
    }

    /// <summary>
    /// Метод возвращает минимальный незанятый идентификатор в базе данных для объектов класса запись в прайс-листе
    /// </summary>
    /// <returns>Минимальный незанятый идентификатор</returns>
    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach (var value in dataBase.Prices)
        {
            ids.Add(value.PriceListEntryId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }
}
