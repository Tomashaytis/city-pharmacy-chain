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
public class ProductForPharmacyDto(string? pharmacyName = null, int? count = null, double? price = null, int? productCode = null, string? name = null, string? productGroup = null)
{
    /// <summary>
    /// Название аптеки
    /// </summary>
    public string? PharmacyName { get; set; } = pharmacyName;

    /// <summary>
    /// Количество препарата на складе аптеки
    /// </summary>
    public int? Count { get; set; } = count;

    /// <summary>
    /// Цена препарата
    /// </summary>
    public double? Price { get; set; } = price;

    /// <summary>
    /// Код препарата
    /// </summary>
    public int? ProductCode { get; set; } = productCode;

    /// <summary>
    /// Название препарата
    /// </summary>
    public string? Name { get; set; } = name;

    /// <summary>
    /// Товарная группа препарата
    /// </summary>
    public string? ProductGroup { get; set; } = productGroup;
}
