namespace CityPharmacyChain.Domain.Entity;

public class PharmacyProduct(int pharmacyProductId = 0, int productId = 0, int pharmacyId = 0, int count = 0, double price = 0)
{
    /// <summary>
    /// Идентификатор связи препарат-аптека
    /// </summary>
    public int PharmacyProductId { get; set; } = pharmacyProductId;

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
    /// Цена препарата в аптеке
    /// </summary>
    public double Price { get; set; } = price;
}
