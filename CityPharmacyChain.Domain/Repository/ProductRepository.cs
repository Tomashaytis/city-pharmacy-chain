using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class ProductRepository(DataBase dataBase) : IRepository<Product>
{
    public IEnumerable<Product> GetAll()
    {
        return dataBase.Products;
    }

    public Product? GetById(int id)
    {
        return dataBase.Products.Find(x => x.ProductId == id);
    }

    public void Post(Product entity)
    {
        dataBase.Products.Add(entity);
    }

    public bool Put(Product entity)
    {
        var value = GetById(entity.ProductId);
        if (value is null)
            return false;
        value.ProductGroup = entity.ProductGroup;
        value.ProductCode = entity.ProductCode;
        value.Name = entity.Name;
        return true;
    }

    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        dataBase.Products.Remove(value);
        return true;
    }

    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach (var value in dataBase.Products)
        {
            ids.Add(value.ProductId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }
}