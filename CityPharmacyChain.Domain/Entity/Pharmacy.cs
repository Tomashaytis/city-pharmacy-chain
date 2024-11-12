using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Класс Entity для сущности класса аптека
/// </summary>
/// <param name="pharmacyId">Идентификатор аптеки</param>
/// <param name="pharmacyNumber">Номер аптеки</param>
/// <param name="name">Название аптеки</param>
/// <param name="phoneNumber">Телефон аптеки</param>
/// <param name="address">Адрес аптеки</param>
/// <param name="directorFullName">Полное имя директора аптеки</param>
[Table("pharmacy")]
public class Pharmacy(int pharmacyId = 0, int? pharmacyNumber = null, string? name = null, long? phoneNumber = null, string? address = null, string? directorFullName = null)
{
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    [Key]
    [Column("pharmacy_id")]
    public int PharmacyId { get; set; } = pharmacyId;

    /// <summary>
    /// Номер аптеки
    /// </summary>
    [Column("pharmacy_number")]
    public int? PharmacyNumber { get; set; } = pharmacyNumber;

    /// <summary>
    /// Название аптеки
    /// </summary>
    [Column("name")]
    public string? Name { get; set; } = name;

    /// <summary>
    /// Телефон аптеки
    /// </summary>
    [Column("phone_number")]
    public long? PhoneNumber { get; set; } = phoneNumber;

    /// <summary>
    /// Адрес аптеки
    /// </summary>
    [Column("address")]
    public string? Address { get; set; } = address;

    /// <summary>
    /// Полное имя директора аптеки
    /// </summary>
    [Column("director_full_name")]
    public string? DirectorFullName { get; set; } = directorFullName;

    /// <summary>
    /// Записи в прайс-листе для аптеки
    /// </summary>
    public virtual List<PriceListEntry> PriceListEntries { get; set; } = [];

    /// <summary>
    /// Связи препарат-аптека для аптеки
    /// </summary>
    public virtual List<PharmacyProduct> PharmacyProducts { get; set; } = [];
}
