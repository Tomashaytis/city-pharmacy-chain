namespace CityPharmacyChain.Api.Dto;

public class ProductForPharmacyDto(int count = 0, double price = 0, int productCode = 0, string name = "", string productGroup = "")
{
    public int Count { get; set; } = count;
    public double Price { get; set; } = price;
    public int ProductCode { get; set; } = productCode;
    public string Name { get; set; } = name;
    public string ProductGroup { get; set; } = productGroup;
}
