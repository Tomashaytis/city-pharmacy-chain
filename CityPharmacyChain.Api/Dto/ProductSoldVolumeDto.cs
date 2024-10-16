namespace CityPharmacyChain.Api.Dto;

public class ProductSoldVolumeDto(string pharmacyName = "", int soldCount = 0, int soldVolume = 0)
{
    /// <summary>
    /// Название аптеки
    /// </summary>
    public string PharmacyName { get; set; } = pharmacyName;

    /// <summary>
    /// Количество продаж препарата
    /// </summary>
    public int SoldCount { get; set; } = soldCount;

    /// <summary>
    /// Цена препарата, помноженная на количество проданных препаратов этого типа
    /// </summary>
    public int SoldVolume { get; set; } = soldVolume;
}
