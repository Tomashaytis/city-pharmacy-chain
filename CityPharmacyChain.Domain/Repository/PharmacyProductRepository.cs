using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmacyProductRepository
{
    public List<PharmacyProduct> PharmacyProductList { get; set; } = [];

    public PharmacyProductRepository()
    {
        PharmacyProductList =
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

    public PharmacyProduct GetById(int id)
    {
        var selection = PharmacyProductList.Where(x => x.ProductId == id).ToList();
        if (selection.Count is 0)
            throw new Exception($"There is no record with the id {id} in the data.");
        return selection[0];
    }

    public void Create(PharmacyProduct pharmacyProduct)
    {
        var id = 1;
        if (PharmacyProductList.Count != 0)
            id = PharmacyProductList.Max(x => x.PharmacyProductId) + 1;
        pharmacyProduct.PharmacyProductId = id;
        PharmacyProductList.Add(pharmacyProduct);
    }

    public void Update(PharmacyProduct pharmacyProduct)
    {
        for (var i = 0; i < PharmacyProductList.Count; i++)
        {
            if (PharmacyProductList[i].PharmacyProductId == pharmacyProduct.PharmacyProductId)
            {
                PharmacyProductList[i] = pharmacyProduct;
                return;
            }
        }
        throw new Exception($"There is no record with the id {pharmacyProduct.PharmacyProductId} in the data.");
    }

    public void Delete(int id)
    {
        var index = -1;
        for (var i = 0; i < PharmacyProductList.Count; i++)
        {
            if (PharmacyProductList[i].PharmacyProductId == id)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
            PharmacyProductList.RemoveAt(index);
        else
            throw new Exception($"There is no record with the id {id} in the data.");
    }
}
