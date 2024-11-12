using System.ComponentModel.DataAnnotations;

namespace CityPharmacyChain.Api.Host.Dto;

/// <summary>
/// Класс DTO для сущности класса аптека
/// </summary>
/// <param name="pharmacyNumber">Номер аптеки</param>
/// <param name="name">Название аптеки</param>
/// <param name="phoneNumber">Телефон аптеки</param>
/// <param name="address">Адрес аптеки</param>
/// <param name="directorFullName">Полное имя директора аптеки</param>
public class PharmacyDto(int? pharmacyNumber = null, string? name = null, long? phoneNumber = null, string? address = null, string? directorFullName = null)
{
    /// <summary>
    /// Номер аптеки
    /// </summary>
    [Range(0, 10000, ErrorMessage = "Pharmacy number must be between 0 and 10000.")]
    public int? PharmacyNumber { get; set; } = pharmacyNumber;

    /// <summary>
    /// Название аптеки
    /// </summary>
    [StringLength(50, ErrorMessage = "Pharmacy name too long.")]
    public string? Name { get; set; } = name;

    /// <summary>
    /// Телефон аптеки
    /// </summary>
    [RegularExpression(@"^(?!0+$)(\+\d{1,3}[- ]?)?(?!0+$)\d{10,15}$", ErrorMessage = "Phone number should be valid.")]
    public long? PhoneNumber { get; set; } = phoneNumber;

    /// <summary>
    /// Адрес аптеки
    /// </summary>
    [StringLength(100, ErrorMessage = "Pharmacy address too long.")]
    public string? Address { get; set; } = address;

    /// <summary>
    /// Полное имя директора аптеки
    /// </summary>
    [StringLength(50, ErrorMessage = "Director name too long.")]
    public string? DirectorFullName { get; set; } = directorFullName;
}
