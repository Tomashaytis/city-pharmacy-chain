using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса количество препаратов на складе аптеки
/// </summary>
/// <param name="productName">Название препарата</param>
/// <param name="pharmacyName">Название препарата</param>
/// <param name="count">Количество препарата на складе аптеки</param>
public class ProductCountDto(string? productName = null, string? pharmacyName = null, int? count = null)
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
    /// Количество препарата на складе аптеки
    /// </summary>
    [Range(0, 1000, ErrorMessage = "Product count must be between 0 and 1000.")]
    public int? Count { get; set; } = count;
}
