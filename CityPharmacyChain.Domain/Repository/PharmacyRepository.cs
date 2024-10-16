using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmacyRepository(DataBase dataBase) : IRepository<Pharmacy>
{
    public IEnumerable<Pharmacy> GetAll()
    {
        return dataBase.Pharmacies;
    }

    public Pharmacy? GetById(int id)
    {
        return dataBase.Pharmacies.Find(x => x.PharmacyId == id);
    }

    public void Post(Pharmacy entity)
    {
        dataBase.Pharmacies.Add(entity);
    }

    public bool Put(Pharmacy entity)
    {
        var value = GetById(entity.PharmacyId);
        if (value is null)
            return false;
        value.PharmacyNumber = entity.PharmacyNumber;
        value.DirectorFullName = entity.DirectorFullName;
        value.PhoneNumber = entity.PhoneNumber;
        value.Name = entity.Name;
        value.Address = entity.Address;
        return true;
    }

    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        dataBase.Pharmacies.Remove(value);
        return true;
    }

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

    public List<Tuple<int, string, int, string, double>> GetProductsForPharmacies(string pharmacyName)
    {
        return (from pharmacy in dataBase.Pharmacies
               join pharmacyProduct in dataBase.PharmacyProducts on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
               join product in dataBase.Products on pharmacyProduct.ProductId equals product.ProductId
               orderby product.Name
               where pharmacy.Name == pharmacyName
               select new Tuple<int, string, int, string, double>
               (
                   product.ProductCode,
                   product.Name,
                   pharmacyProduct.Count,
                   product.ProductGroup,
                   pharmacyProduct.Price
               )).ToList();
    }

    public List<string> GetPharmaciesWithLargeProductSoldVolume(string district, string productName)
    {
        var tmpPharmaciesWithBigProductSoldVolumes =
                (from pharmacy in dataBase.Pharmacies
                 join priceListEntry in dataBase.Prices on pharmacy.PharmacyId equals priceListEntry.PharmacyId
                 join product in dataBase.Products on priceListEntry.ProductId equals product.ProductId
                 where pharmacy.Address.Contains(district) && product.Name == productName
                 group priceListEntry by priceListEntry.PharmacyId into result
                 select new
                 {
                     PharmacyId = result.Key,
                     SoldVolume = result.Sum(p => p.SoldCount),
                 }).ToList();
         return (from entry in tmpPharmaciesWithBigProductSoldVolumes
                join pharmacy in dataBase.Pharmacies on entry.PharmacyId equals pharmacy.PharmacyId
                where entry.SoldVolume > 2
                select pharmacy.Name).ToList();
    }

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
