using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PriceListEntryRepository(DataBase dataBase) : IRepository<PriceListEntry>
{
    public IEnumerable<PriceListEntry> GetAll()
    {
        return dataBase.Prices;
    }

    public PriceListEntry? GetById(int id)
    {
        return dataBase.Prices.Find(x => x.PriceListEntryId == id);
    }

    public void Post(PriceListEntry entity)
    {
        dataBase.Prices.Add(entity);
    }

    public bool Put(PriceListEntry entity)
    {
        var value = GetById(entity.PriceListEntryId);
        if (value is null)
            return false;
        value.ProductId = entity.ProductId;
        value.PharmacyId = entity.PharmacyId;
        value.Manufacturer = entity.Manufacturer;
        value.SaleDate = entity.SaleDate;;
        value.PaymentType = entity.PaymentType;
        value.SoldCount = entity.SoldCount;
        return true;
    }

    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        dataBase.Prices.Remove(value);
        return true;
    }

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
