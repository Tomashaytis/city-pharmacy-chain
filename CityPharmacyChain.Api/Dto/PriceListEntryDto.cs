using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.Dto;

public class PriceListEntryDto(int productId = 0, int pharmacyId = 0, int soldCount = 0, string manufacturer = "", string paymentType = "", DateTime? saleDate = null)
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
    /// Количество проданных препаратов
    /// </summary>
    public int SoldCount { get; set; } = soldCount;

    /// <summary>
    /// Производитель препарата
    /// </summary>
    public string Manufacturer { get; set; } = manufacturer;

    /// <summary>
    /// Способ оплаты (наличные/картой)
    /// </summary>
    public string PaymentType { get; set; } = paymentType;

    /// <summary>
    /// Дата продажи препарата
    /// </summary>
    public DateTime? SaleDate { get; set; } = saleDate;
}
