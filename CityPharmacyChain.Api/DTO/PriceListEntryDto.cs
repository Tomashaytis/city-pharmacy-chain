namespace CityPharmacyChain.Api.DTO;

public class PriceListEntryDto(int soldCount, string manufacturer, string paymentType, DateTime saleDate)
{
    public int SoldCount { get; set; } = soldCount;
    public string Manufacturer { get; set; } = manufacturer;
    public string PaymentType { get; set; } = paymentType;
    public DateTime SaleDate { get; set; } = saleDate;
}
