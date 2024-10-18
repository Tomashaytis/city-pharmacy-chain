namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Класс Entity для сущности класса запись в прайс-листе
/// </summary>
/// <param name="priceListEntryId">Идентификатор записи в прайс-листе</param>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="pharmacyId">Идентификатор аптеки</param>
/// <param name="soldCount">Количество проданных препаратов</param>
/// <param name="manufacturer">Производитель препарата</param>
/// <param name="paymentType">Тип оплаты (наличные/картой)</param>
/// <param name="saleDate">Дата и время продажи препарата</param>
public class PriceListEntry(int priceListEntryId = 0, int productId = 0, int pharmacyId = 0, int? soldCount = null, string? manufacturer = null, string? paymentType = null, DateTime? saleDate = null)
{
    /// <summary>
    /// Идентификатор записи в прайс-листе
    /// </summary>
    public required int PriceListEntryId { get; set; } = priceListEntryId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public required int ProductId { get; set; } = productId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public required int PharmacyId { get; set; } = pharmacyId;
    
    /// <summary>
    /// Количество проданных препаратов
    /// </summary>
    public int? SoldCount { get; set; } = soldCount;
    
    /// <summary>
    /// Производитель препарата
    /// </summary>
    public string? Manufacturer { get; set; } = manufacturer;
    
    /// <summary>
    /// Тип оплаты (наличные/картой)
    /// </summary>
    public string? PaymentType { get; set; } = paymentType;

    /// <summary>
    /// Дата и время продажи препарата
    /// </summary>
    public DateTime? SaleDate { get; set; } = saleDate;
}
