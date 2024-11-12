using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Host.Dto;

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
    [StringLength(50, ErrorMessage = "Product name too long.")]
    public string? ProductName { get; set; } = productName;

    /// <summary>
    /// Название аптеки
    /// </summary>
    [StringLength(50, ErrorMessage = "Pharmacy name too long.")]
    public string? PharmacyName { get; set; } = pharmacyName;

    /// <summary>
    /// Количество продаж препарата
    /// </summary>
    [Range(0, 1000, ErrorMessage = "Sold count must be between 0 and 1000.")]
    public int? SoldCount { get; set; } = soldCount;

    /// <summary>
    /// Цена препарата, помноженная на количество проданных препаратов этого типа
    /// </summary>
    [Range(0, 1000000, ErrorMessage = "Sold volume must be between 0 and 1000000.")]
    public int? SoldVolume { get; set; } = soldVolume;
}
