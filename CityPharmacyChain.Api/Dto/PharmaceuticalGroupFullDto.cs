using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса фармацевтическая группа, содержащий её идентификатор
/// </summary>
/// <param name="pharmaceuticalGroupId">Идентификатор фармацевтической группы</param>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="name">Название фармацевтической группы</param>
public class PharmaceuticalGroupFullDto(int pharmaceuticalGroupId = 0,  int productId = 0, string? name = null)
{
    /// <summary>
    /// Идентификатор фармацевтической группы
    /// </summary>
    public int PharmaceuticalGroupId { get; set; } = pharmaceuticalGroupId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Название фармацевтической группы
    /// </summary>
    [StringLength(50, ErrorMessage = "Pharmaceutical group name too long.")]
    public string? Name { get; set; } = name;
}