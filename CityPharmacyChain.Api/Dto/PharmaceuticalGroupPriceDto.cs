namespace CityPharmacyChain.Api.Dto;

public class PharmaceuticalGroupPriceDto(string name = "", double price = 0)
{
    public string PharmacyName { get; set; } = name;
    public string PharmaceuticalGroupName { get; set; } = name;
    public double Price { get; set; } = price;
}
