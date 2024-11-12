using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Host.Dto;

/// <summary>
/// Класс DTO для сущности класса фармацевтическая группа
/// </summary>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="name">Название фармацевтической группы</param>
public class PharmaceuticalGroupDto(int productId = 0, string? name = null)
{
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