using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class ProductRepository
{
    public List<Product> ProductList { get; set; } = [];

    public ProductRepository()
    {
        ProductList =
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
        var selection = ProductList.Where(x => x.ProductId == id).ToList();
        if (selection.Count is 0)
            throw new Exception($"There is no record with the id {id} in the data.");
        return selection[0];
    }

    public void Create(Product product)
    {
        var id = 1;
        if (ProductList.Count != 0)
            id = ProductList.Max(x => x.ProductId) + 1;
        product.ProductId = id;
        ProductList.Add(product);
    }

    public void Update(Product product)
    {
        for (var i = 0; i < ProductList.Count; i++)
        {
            if (ProductList[i].ProductId == product.ProductId)
            {
                ProductList[i] = product;
                return;
            }
        }
        throw new Exception($"There is no record with the id {product.ProductId} in the data.");
    }

    public void Delete(int id)
    {
        var index = -1;
        for (var i = 0; i < ProductList.Count; i++)
        {
            if (ProductList[i].ProductId == id)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
            ProductList.RemoveAt(index);
        else
            throw new Exception($"There is no record with the id {id} in the data.");
    }
}