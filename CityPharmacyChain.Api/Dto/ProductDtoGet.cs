namespace CityPharmacyChain.Api.Dto;

public class ProductDtoGet(int productCode, string name, string productGroup)
{
    public int ProductCode { get; set; } = productCode;
    public string Name { get; set; } = name;
    public string ProductGroup { get; set; } = productGroup;
}
