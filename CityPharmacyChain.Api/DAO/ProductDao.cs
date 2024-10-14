using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.DAO;

public class ProductDao : IDao<Product>
{
    public List<Product> Values { get; set; } = [];

    public ProductDao()
    {
        Values =
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

    public Product GetById(int id)
    {
        var selection = Values.Where(x => x.ProductId == id).ToList();
        if (selection.Count is 0)
            throw new Exception($"There is no record with the id {id} in the data.");
        return selection[0];
    }

    public void Create(Product obj)
    {
        var id = 1;
        if (Values.Count != 0)
            id = Values.Max(x => x.ProductId) + 1;
        obj.ProductId = id;
        Values.Add(obj);
    }

    public void Update(Product obj)
    {
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i].ProductId == obj.ProductId)
            {
                Values[i] = obj;
                return;
            }
        }
        throw new Exception($"There is no record with the id {obj.ProductId} in the data.");
    }

    public void Delete(int id)
    {
        var index = -1;
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i].ProductId == id)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
            Values.RemoveAt(index);
        else
            throw new Exception($"There is no record with the id {id} in the data.");
    }
}