using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmaceuticalGroupRepository(DataBase dataBase) : IRepository<PharmaceuticalGroup>
{
    public IEnumerable<PharmaceuticalGroup> GetAll()
    {
        return dataBase.PharmaceuticalGroups;
    }

    public PharmaceuticalGroup? GetById(int id)
    {
        return dataBase.PharmaceuticalGroups.Find(x => x.PharmaceuticalGroupId == id);
    }

    public void Post(PharmaceuticalGroup entity)
    {
        dataBase.PharmaceuticalGroups.Add(entity);
    }

    public bool Put(PharmaceuticalGroup entity)
    {
        var value = GetById(entity.PharmaceuticalGroupId);
        if (value is null)
            return false;
        value.ProductId = entity.ProductId;
        value.Name = entity.Name;
        return true;
    }

    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        dataBase.PharmaceuticalGroups.Remove(value);
        return true;
    }

    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach(var value in dataBase.PharmaceuticalGroups)
        {
            ids.Add(value.PharmaceuticalGroupId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }

    public List<Tuple<string, string, double>> GetPharmaceuticalGroupPriceForEachPharmacy()
    {
        var result = new List<Tuple<string, string, double>>();
        foreach (var item in dataBase.Pharmacies)
        {
            var pharmaceuticalGroupPriceForPharmacy =
                    (from pharmaceuticalGroup in dataBase.PharmaceuticalGroups
                     join product in dataBase.Products on pharmaceuticalGroup.ProductId equals product.ProductId
                     join pharmacyProduct in dataBase.PharmacyProducts on product.ProductId equals pharmacyProduct.ProductId
                     join pharmacy in dataBase.Pharmacies on pharmacyProduct.PharmacyId equals pharmacy.PharmacyId
                     join priceListEntry in dataBase.Prices on product.ProductId equals priceListEntry.ProductId
                     select new
                     {
                         pharmaceuticalGroup.Name,
                         PharmacyName = pharmacy.Name,
                         pharmacyProduct.Price,
                     }).ToList();
            var avgPharmaceuticalGroupPriceForPharmacy =
                (from entry in pharmaceuticalGroupPriceForPharmacy
                 where entry.PharmacyName == item.Name
                 group entry by entry.Name into groups
                 select new Tuple<string, string, double>
                 (
                     item.Name,
                     groups.Key,
                     groups.Average(p => p.Price)
                 )).ToList();
            result = [.. result, .. avgPharmaceuticalGroupPriceForPharmacy];
        }
        return result;
    }
}
