using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса характеристики препаратов в определённой аптеке
/// </summary>
/// <param name="pharmacyName">Количество препарата на складе аптеки</param>
/// <param name="count">Количество препарата на складе аптеки</param>
/// <param name="price">Цена препарата</param>
/// <param name="productCode">Код препарата</param>
/// <param name="name">Название препарата</param>
/// <param name="productGroup">Товарная группа препарата</param>
public class ProductForPharmacyDto(string? pharmacyName = null, int? count = null, decimal? price = null, int? productCode = null, string? name = null, string? productGroup = null)
{
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

    /// <summary>
    /// Цена препарата
    /// </summary>
    [Range(0, 100000, ErrorMessage = "Product price must be between 0₽ and 100000₽.")]
    public decimal? Price { get; set; } = price;

    /// <summary>
    /// Код препарата
    /// </summary>
    [Range(0, 1000000, ErrorMessage = "Product code must be between 0 and 1000000.")]
    public int? ProductCode { get; set; } = productCode;

    /// <summary>
    /// Название препарата
    /// </summary>
    [StringLength(50, ErrorMessage = "Product name too long.")]
    public string? Name { get; set; } = name;

    /// <summary>
    /// Товарная группа препарата
    /// </summary>
    [StringLength(50, ErrorMessage = "Product group name too long.")]
    public string? ProductGroup { get; set; } = productGroup;
}
