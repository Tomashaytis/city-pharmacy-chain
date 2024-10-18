namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса количество и объём продаж определённого товара в определённой аптеке
/// </summary>
/// <param name="productName">Название препарата</param>
/// <param name="pharmacyName">Название аптеки</param>
/// <param name="soldCount">Количество продаж препарата</param>
/// <param name="soldVolume">Цена препарата, помноженная на количество проданных препаратов этого типа</param>
public class ProductSoldVolumeDto(string? productName = null, string? pharmacyName = null, int? soldCount = null, int? soldVolume = null)
{
    /// <summary>
    /// Название препарата
    /// </summary>
    public string? ProductName { get; set; } = productName;

    /// <summary>
    /// Название аптеки
    /// </summary>
    public string? PharmacyName { get; set; } = pharmacyName;

    /// <summary>
    /// Количество продаж препарата
    /// </summary>
    public int? SoldCount { get; set; } = soldCount;

    /// <summary>
    /// Цена препарата, помноженная на количество проданных препаратов этого типа
    /// </summary>
    public int? SoldVolume { get; set; } = soldVolume;
}
