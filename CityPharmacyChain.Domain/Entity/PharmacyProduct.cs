namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Класс Entity для сущности класса связь препарат-аптека
/// </summary>
/// <param name="pharmacyProductId">Идентификатор связи препарат-аптека</param>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="pharmacyId">Идентификатор аптеки</param>
/// <param name="count">Количество препарата на складе аптеки</param>
/// <param name="price">Цена препарата в аптеке</param>
public class PharmacyProduct(int pharmacyProductId = 0, int? productId = null, int? pharmacyId = null, int? count = null, double? price = null)
{
    /// <summary>
    /// Идентификатор связи препарат-аптека
    /// </summary>
    public int PharmacyProductId { get; set; } = pharmacyProductId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int? ProductId { get; set; } = productId;

    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public int? PharmacyId { get; set; } = pharmacyId;

    /// <summary>
    /// Количество препарата на складе аптеки
    /// </summary>
    public int? Count { get; set; } = count;

    /// <summary>
    /// Цена препарата в аптеке
    /// </summary>
    public double? Price { get; set; } = price;
}
