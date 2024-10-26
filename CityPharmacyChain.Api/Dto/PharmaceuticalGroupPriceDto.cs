using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Dto;

/// <summary>
/// Класс DTO для сущности класса цена препарата с определённой фармацевтической группой в определённой аптеке
/// </summary>
/// <param name="pharmacyName">Название аптеки</param>
/// <param name="pharmaceuticalGroupName">Название фармацевтической группы</param>
/// <param name="price">Цена препарата</param>
public class PharmaceuticalGroupPriceDto(string? pharmacyName = null, string? pharmaceuticalGroupName = null, decimal? price = null)
{
    /// <summary>
    /// Название аптеки
    /// </summary>
    public string? PharmacyName { get; set; } = pharmacyName;

    /// <summary>
    /// Название фармацевтической группы
    /// </summary>
    [StringLength(50, ErrorMessage = "Pharmaceutical group name too long.")]
    public string? PharmaceuticalGroupName { get; set; } = pharmaceuticalGroupName;

    /// <summary>
    /// Цена препарата
    /// </summary>
    [Range(0, 100000, ErrorMessage = "Product price must be between 0₽ and 100000₽.")]
    public decimal? Price { get; set; } = price;
}
