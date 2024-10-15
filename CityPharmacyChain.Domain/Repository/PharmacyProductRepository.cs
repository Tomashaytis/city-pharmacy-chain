using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmacyProductRepository : IRepository<PharmacyProduct>
{
    private List<PharmacyProduct> _values { get; set; } = [];

    public PharmacyProductRepository()
    {
        _values =
        [
            new PharmacyProduct(1, 1, 1, 15, 146),
            new PharmacyProduct(2, 2, 1, 10, 190),
            new PharmacyProduct(3, 3, 1, 20, 220),
            new PharmacyProduct(4, 4, 1, 12, 172),
            new PharmacyProduct(5, 5, 1, 5, 200),
            new PharmacyProduct(6, 6, 1, 8, 302),
            new PharmacyProduct(7, 7, 1, 17, 100),
            new PharmacyProduct(8, 8, 1, 10, 235),
            new PharmacyProduct(9, 9, 1, 15, 300),

            new PharmacyProduct(10, 1, 2, 10, 110),
            new PharmacyProduct(11, 2, 2, 19, 117),
            new PharmacyProduct(12, 4, 2, 6, 190),
            new PharmacyProduct(13, 5, 2, 17, 200),
            new PharmacyProduct(14, 6, 2, 3, 310),
            new PharmacyProduct(15, 8, 2, 2, 100),
            new PharmacyProduct(16, 9, 2, 12, 290),

            new PharmacyProduct(17, 1, 3, 10, 110),
            new PharmacyProduct(18, 5, 3, 4, 200),
            new PharmacyProduct(19, 6, 3, 7, 328),
            new PharmacyProduct(20, 7, 3, 17, 100),
            new PharmacyProduct(21, 8, 3, 14, 150),
            new PharmacyProduct(22, 9, 3, 5, 300),

            new PharmacyProduct(23, 1, 4, 1, 200),
            new PharmacyProduct(24, 2, 4, 3, 210),
            new PharmacyProduct(25, 3, 4, 20, 170),
            new PharmacyProduct(26, 4, 4, 12, 217),
            new PharmacyProduct(27, 5, 4, 16, 150),
            new PharmacyProduct(28, 6, 4, 10, 280),
            new PharmacyProduct(29, 7, 4, 11, 230),
        ];
    }

    public IEnumerable<PharmacyProduct> GetAll()
    {
        return _values;
    }

    public PharmacyProduct? GetById(int id)
    {
        return _values.Find(x => x.PharmacyProductId == id);
    }

    public bool Post(PharmacyProduct entity)
    {
        var value = GetById(entity.PharmacyProductId);
        if (value is not null)
            return false;
        _values.Add(entity);
        return true;
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
        _values.Remove(value);
        return true;
    }
}
