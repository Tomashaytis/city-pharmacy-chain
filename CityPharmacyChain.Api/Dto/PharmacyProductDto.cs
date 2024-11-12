using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Host.Dto;

/// <summary>
/// Класс DTO для сущности класса связь препарат-аптека
/// </summary>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="pharmacyId">Идентификатор аптеки</param>
/// <param name="count">Количество препарата на складе аптеки</param>
/// <param name="price">Цена препарата</param>
public record PharmacyProductDto(int productId = 0, int pharmacyId = 0, int? count = null, decimal? price = null)
{
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public int PharmacyId { get; set; } = pharmacyId;

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
}
