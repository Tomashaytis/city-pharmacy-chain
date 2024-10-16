namespace CityPharmacyChain.Api.Dto;

public class PharmacyProductDto(int productId = 0, int pharmacyId = 0, int count = 0, double price = 0)
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
    public int Count { get; set; } = count;

    /// <summary>
    /// Цена препарата
    /// </summary>
    public double Price { get; set; } = price;
}
