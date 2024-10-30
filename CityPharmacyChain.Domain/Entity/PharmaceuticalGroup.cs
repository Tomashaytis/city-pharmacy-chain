using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Класс Entity для сущности класса фармацевтическая группа
/// </summary>
/// <param name="pharmaceuticalGroupId">Идентификатор фармацевтической группы препарата</param>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="name">Название фармацевтической группы препарата</param>
[Table("pharmaceutical_group")]
public class PharmaceuticalGroup(int pharmaceuticalGroupId = 0, int productId = 0, string? name = null)
{
    /// <summary>
    /// Идентификатор фармацевтической группы препарата
    /// </summary>
    [Key]
    [Column("pharmaceutical_group_id")]
    public int PharmaceuticalGroupId { get; set; } = pharmaceuticalGroupId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    [ForeignKey("product_id")]
    [Column("product_id")]
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Название фармацевтической группы препарата
    /// </summary>
    [Column("name")]
    public string? Name { get; set; } = name;

    /// <summary>
    /// Препараты, к которому относится фармацевтическая группа
    /// </summary>
    public Product? Product { get; set; } = null;
}