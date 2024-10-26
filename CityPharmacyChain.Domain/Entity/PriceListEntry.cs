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
public class PriceListEntry(int priceListEntryId = 0, int? productId = null, int? pharmacyId = null, int? soldCount = null, string? manufacturer = null, PaymentType? paymentType = null, DateTime? saleDate = null)
{
    /// <summary>
    /// Идентификатор записи в прайс-листе
    /// </summary>
    public int PriceListEntryId { get; set; } = priceListEntryId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int? ProductId { get; set; } = productId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public int? PharmacyId { get; set; } = pharmacyId;
    
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
    public PaymentType? PaymentType { get; set; } = paymentType;

    /// <summary>
    /// Дата и время продажи препарата
    /// </summary>
    public DateTime? SaleDate { get; set; } = saleDate;
}
