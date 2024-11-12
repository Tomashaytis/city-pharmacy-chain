using CityPharmacyChain.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Host.Dto;

/// <summary>
/// Класс DTO для сущности класса запись в прайс-листе, содержащий её идентификатор
/// </summary>
/// <param name="priceListEntryId">Идентификатор записи в прайс-листе</param>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="pharmacyId">Идентификатор аптеки</param>
/// <param name="soldCount">Количество проданных препаратов</param>
/// <param name="manufacturer">Производитель препарата</param>
/// <param name="paymentType">Способ оплаты (наличные/картой)</param>
/// <param name="saleDate">Дата продажи препарата</param>
public record PriceListEntryFullDto(int priceListEntryId = 0, int productId = 0, int pharmacyId = 0, int? soldCount = null, string? manufacturer = null, string? paymentType = null, DateTime? saleDate = null)
{
    /// <summary>
    /// Идентификатор записи в прайс-листе
    /// </summary>
    public int PriceListEntryId { get; set; } = priceListEntryId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public int PharmacyId { get; set; } = pharmacyId;

    /// <summary>
    /// Количество проданных препаратов
    /// </summary>
    [Range(0, 1000, ErrorMessage = "Sold count must be between 0 and 1000.")]
    public int? SoldCount { get; set; } = soldCount;

    /// <summary>
    /// Производитель препарата
    /// </summary>
    [StringLength(50, ErrorMessage = "Manufacturer name too long.")]
    public string? Manufacturer { get; set; } = manufacturer;

    /// <summary>
    /// Способ оплаты (наличные/картой)
    /// </summary>
    [EnumDataType(typeof(PaymentType), ErrorMessage = "Unknown payment type.")]
    public string? PaymentType { get; set; } = paymentType;

    /// <summary>
    /// Дата продажи препарата
    /// </summary>
    public DateTime? SaleDate { get; set; } = saleDate;
}
