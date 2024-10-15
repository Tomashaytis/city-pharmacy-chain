namespace CityPharmacyChain.Domain.Entity;

public class PharmacyProduct(int pharmacyProductId = 0, int productId = 0, int pharmacyId = 0, int count = 0, double price = 0)
{
    public int PharmacyProductId { get; set; } = pharmacyProductId;
    public int ProductId { get; set; } = productId;
    public int PharmacyId { get; set; } = pharmacyId;
    public int Count { get; set; } = count;
    public double Price { get; set; } = price;
}
