namespace CityPharmacyChain.Api.Dto;

public class ProductSoldVolumeDto(string pharmacyName = "", int soldCount = 0, int soldVolume = 0)
{
    public string PharmacyName { get; set; } = pharmacyName;
    public int SoldCount { get; set; } = soldCount;
    public int SoldVolume { get; set; } = soldVolume;
}
