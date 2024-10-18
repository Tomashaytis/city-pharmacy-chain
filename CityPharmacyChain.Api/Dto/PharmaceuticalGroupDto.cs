namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса фармацевтическая группа
/// </summary>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="name">Название фармацевтической группы</param>
public class PharmaceuticalGroupDto(int? productId = null, string? name = null)
{
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int? ProductId { get; set; } = productId;

    /// <summary>
    /// Название фармацевтической группы
    /// </summary>
    public string? Name { get; set; } = name;
}