namespace CityPharmacyChain.Api.DTO;

public class PharmacyProductDto(int count, double price)
{
    public int Count { get; set; } = count;
    public double Price { get; set; } = price;
}
