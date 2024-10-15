namespace CityPharmacyChain.Api.Dto;

public class PharmacyProductDtoGet(int count, double price)
{
    public int Count { get; set; } = count;
    public double Price { get; set; } = price;
}
