using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
[Table("price_list")]
public class PriceListEntry(int priceListEntryId = 0, int productId = 0, int pharmacyId = 0, int? soldCount = null, string? manufacturer = null, PaymentType paymentType = PaymentType.Null, DateTime? saleDate = null)
{
    /// <summary>
    /// Идентификатор записи в прайс-листе
    /// </summary>
    [Key]
    [Column("price_list_entry_id")]
    public int PriceListEntryId { get; set; } = priceListEntryId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    [ForeignKey("product_id")]
    [Column("product_id")]
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    [ForeignKey("pharmacy_id")]
    [Column("pharmacy_id")]
    public int PharmacyId { get; set; } = pharmacyId;

    /// <summary>
    /// Количество проданных препаратов
    /// </summary>
    [Column("sold_count")]
    public int? SoldCount { get; set; } = soldCount;

    /// <summary>
    /// Производитель препарата
    /// </summary>
    [Column("manufacturer")]
    public string? Manufacturer { get; set; } = manufacturer;

    /// <summary>
    /// Тип оплаты (наличные/картой)
    /// </summary>
    [Column("payment_type")]
    public PaymentType PaymentType { get; set; } = paymentType;

    /// <summary>
    /// Дата и время продажи препарата
    /// </summary>
    [Column("sale_date")]
    public DateTime? SaleDate { get; set; } = saleDate;

    /// <summary>
    /// Препарат, к которому относится запись в прайс-листе
    /// </summary>
    public virtual Product? Product { get; set; } = null;

    /// <summary>
    /// Аптека, к которой относится запись в прайс-листе
    /// </summary>
    public virtual Pharmacy? Pharmacy { get; set; } = null;
}
