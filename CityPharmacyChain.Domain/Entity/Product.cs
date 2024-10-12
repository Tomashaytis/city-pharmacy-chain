namespace CityPharmacyChain.Domain.Entity;

public class Product(int productId, int productCode, string name, string productGroup)
{
    public int ProductId { get; set; } = productId;
    public int ProductCode { get; set; } = productCode;
    public string Name { get; set; } = name;
    public string ProductGroup { get; set; } = productGroup;
}
