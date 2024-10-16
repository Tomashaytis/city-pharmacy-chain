using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmacyProductRepository(DataBase dataBase) : IRepository<PharmacyProduct>
{
    public IEnumerable<PharmacyProduct> GetAll()
    {
        return dataBase.PharmacyProducts;
    }

    public PharmacyProduct? GetById(int id)
    {
        return dataBase.PharmacyProducts.Find(x => x.PharmacyProductId == id);
    }

    public void Post(PharmacyProduct entity)
    {
        dataBase.PharmacyProducts.Add(entity);
    }

    public bool Put(PharmacyProduct entity)
    {
        var value = GetById(entity.PharmacyProductId);
        if (value is null)
            return false;
        value.ProductId = entity.ProductId;
        value.PharmacyId = entity.PharmacyId;
        value.Price = entity.Price;
        value.Count = entity.Count;
        return true;
    }

    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        dataBase.PharmacyProducts.Remove(value);
        return true;
    }

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
