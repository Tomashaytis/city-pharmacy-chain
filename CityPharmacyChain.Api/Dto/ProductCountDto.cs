namespace CityPharmacyChain.Api.Dto;

public class ProductCountDto(string productName = "", int count = 0)
{
    public string ProductName { get; set; } = productName;
    public int Count { get; set; } = count;
}
