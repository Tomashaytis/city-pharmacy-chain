namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Класс Entity для сущности класса фармацевтическая группа
/// </summary>
/// <param name="pharmaceuticalGroupId">Идентификатор фармацевтической группы препарата</param>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="name">Название фармацевтической группы препарата</param>
public class PharmaceuticalGroup(int pharmaceuticalGroupId = 0, int productId = 0, string? name = null)
{
    /// <summary>
    /// Идентификатор фармацевтической группы препарата
    /// </summary>
    public required int PharmaceuticalGroupId { get; set; } = pharmaceuticalGroupId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public required int ProductId { get; set; } = productId;

    /// <summary>
    /// Название фармацевтической группы препарата
    /// </summary>
    public string? Name { get; set; } = name;
}