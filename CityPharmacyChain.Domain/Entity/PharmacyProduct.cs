namespace CityPharmacyChain.Domain.Entity;

public class PharmacyProduct(int pharmacyProductId, int productId, int pharmacyId, int count, double price)
{
    public int PharmacyProductId { get; set; } = pharmacyProductId;
    public int ProductId { get; set; } = productId;
    public int PharmacyId { get; set; } = pharmacyId;
    public int Count { get; set; } = count;
    public double Price { get; set; } = price;
}
