namespace CityPharmacyChain.Domain.Entity;

public class PriceListEntry(int priceListEntryId = 0, int productId = 0, int pharmacyId = 0, int soldCount = 0, string manufacturer = "", string paymentType = "", DateTime? saleDate = null)
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
    public int SoldCount { get; set; } = soldCount;
    
    /// <summary>
    /// Производитель препарата
    /// </summary>
    public string Manufacturer { get; set; } = manufacturer;
    
    /// <summary>
    /// Тип оплаты (наличные/картой)
    /// </summary>
    public string PaymentType { get; set; } = paymentType;

    /// <summary>
    /// Дата и время продажи препарата
    /// </summary>
    public DateTime? SaleDate { get; set; } = saleDate;
}
