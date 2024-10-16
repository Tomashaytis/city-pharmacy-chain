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
}
