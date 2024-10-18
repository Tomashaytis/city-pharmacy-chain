namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса цена препарата с определённой фармацевтической группой в определённой аптеке
/// </summary>
/// <param name="pharmacyName">Название аптеки</param>
/// <param name="pharmaceuticalGroupName">Название фармацевтической группы</param>
/// <param name="price">Цена препарата</param>
public class PharmaceuticalGroupPriceDto(string? pharmacyName = null, string? pharmaceuticalGroupName = null, double? price = null)
{
    /// <summary>
    /// Название аптеки
    /// </summary>
    public string? PharmacyName { get; set; } = pharmacyName;

    /// <summary>
    /// Название фармацевтической группы
    /// </summary>
    public string? PharmaceuticalGroupName { get; set; } = pharmaceuticalGroupName;

    /// <summary>
    /// Цена препарата
    /// </summary>
    public double? Price { get; set; } = price;
}
