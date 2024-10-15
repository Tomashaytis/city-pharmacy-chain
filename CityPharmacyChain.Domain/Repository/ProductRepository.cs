using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class ProductRepository : IRepository<Product>
{
    private List<Product> _values { get; set; } = [];

    public ProductRepository()
    {
        _values =
        [
            new Product(1, 1, "Heparin ointment", "Ointment for external use"),
            new Product(2, 2, "Levomekol", "Ointment for external use"),
            new Product(3, 3, "Vishnevsky ointment", "Ointment for external use"),
            new Product(4, 4, "Nurofen", "Pills"),
            new Product(5, 5, "Rinostop", "Nasal spray"),
            new Product(6, 6, "Streptocide", "Powder for external use"),
            new Product(7, 7, "Sodium sulfacyl", "Капли глазные"),
            new Product(8, 8, "Pentalgin", "Gel for external use"),
            new Product(9, 9, "Trombo", "Pills"),
        ];
    }

    public IEnumerable<Product> GetAll()
    {
        return _values;
    }

    public Product? GetById(int id)
    {
        return _values.Find(x => x.ProductId == id);
    }

    public bool Post(Product entity)
    {
        var value = GetById(entity.ProductId);
        if (value is not null)
            return false;
        _values.Add(entity);
        return true;
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
        _values.Remove(value);
        return true;
    }
}