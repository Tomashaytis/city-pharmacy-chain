namespace CityPharmacyChain.Domain.Entity;

public class PriceListEntry(int priceListEntryId, int productId, int pharmacyId, int soldCount, string manufacturer, string paymentType, DateTime saleDate)
{
    public int PriceListEntryId { get; set; } = priceListEntryId;
    public int ProductId { get; set; } = productId;
    public int PharmacyId { get; set; } = pharmacyId;
    public int SoldCount { get; set; } = soldCount;
    public string Manufacturer { get; set; } = manufacturer;
    public string PaymentType { get; set; } = paymentType;
    public DateTime SaleDate { get; set; } = saleDate;
}
