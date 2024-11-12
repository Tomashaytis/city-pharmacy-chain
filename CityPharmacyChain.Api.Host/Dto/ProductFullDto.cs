using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Host.Dto;

/// <summary>
/// Класс DTO для сущности класса препарат, содержащий её идентификатор
/// </summary>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="productCode">Код препарата</param>
/// <param name="name">Название препарата</param>
/// <param name="productGroup">Товарная группа препарата</param>
public class ProductFullDto(int productId = 0, int? productCode = null, string? name = null, string? productGroup = null)
{
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int ProductId { get; set; } = productId;

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