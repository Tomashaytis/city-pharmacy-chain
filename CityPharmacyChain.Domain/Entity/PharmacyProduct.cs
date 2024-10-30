using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Класс Entity для сущности класса связь препарат-аптека
/// </summary>
/// <param name="pharmacyProductId">Идентификатор связи препарат-аптека</param>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="pharmacyId">Идентификатор аптеки</param>
/// <param name="count">Количество препарата на складе аптеки</param>
/// <param name="price">Цена препарата в аптеке</param>
[Table("pharmacy_product")]
public class PharmacyProduct(int pharmacyProductId = 0, int productId = 0, int pharmacyId = 0, int? count = null, decimal? price = null)
{
    /// <summary>
    /// Идентификатор связи препарат-аптека
    /// </summary>
    [Key]
    [Column("pharmacy_product_id")]
    public int PharmacyProductId { get; set; } = pharmacyProductId;

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
    /// Количество препарата на складе аптеки
    /// </summary>
    [Column("count")]
    public int? Count { get; set; } = count;

    /// <summary>
    /// Цена препарата в аптеке
    /// </summary>
    [Column("price")]
    public decimal? Price { get; set; } = price;

    /// <summary>
    /// Препарат, к которому относится связь препарат-аптека
    /// </summary>
    public Product? Product { get; set; } = null;

    /// <summary>
    /// Аптека, к которой относится связь препарат-аптека
    /// </summary>
    public Pharmacy? Pharmacy { get; set; } = null;
}
