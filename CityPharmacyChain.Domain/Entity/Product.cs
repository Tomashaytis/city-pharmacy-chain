using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Класс Entity для сущности класса препарат
/// </summary>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="productCode">Код препарата</param>
/// <param name="name">Название препарата</param>
/// <param name="productGroup">Товарная группа препарата</param>
public class Product(int productId = 0, int? productCode = null, string? name = null, string? productGroup = null)
{
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Код препарата
    /// </summary>
    [Column("product_code")]
    public int? ProductCode { get; set; } = productCode;

    /// <summary>
    /// Название препарата
    /// </summary>
    [Column("name")]
    public string? Name { get; set; } = name;

    /// <summary>
    /// Товарная группа препарата
    /// </summary>
    [Column("product_group")]
    public string? ProductGroup { get; set; } = productGroup;

    /// <summary>
    /// Записи в прайс-листе для препарата
    /// </summary>
    public List<PriceListEntry> PriceListEntries { get; set; } = [];

    /// <summary>
    /// Связи препарат-аптека для препарата
    /// </summary>
    public List<PharmacyProduct> PharmacyProducts { get; set; } = [];

    /// <summary>
    /// Список фармацевтических групп для препарата
    /// </summary>
    public List<PharmaceuticalGroup> PharmaceuticalGroups { get; set; } = [];
}
