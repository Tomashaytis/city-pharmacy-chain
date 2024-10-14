namespace CityPharmacyChain.Api.DTO;

public class ProductDto(int productCode, string name, string productGroup)
{
    public int ProductCode { get; set; } = productCode;
    public string Name { get; set; } = name;
    public string ProductGroup { get; set; } = productGroup;
}
