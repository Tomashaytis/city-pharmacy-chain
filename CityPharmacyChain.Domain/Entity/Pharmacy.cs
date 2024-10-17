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
public class Pharmacy(int pharmacyId = 0, int pharmacyNumber = 0, string name = "", long phoneNumber = 0, string address = "", string directorFullName = "")
{
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public int PharmacyId { get; set; } = pharmacyId;

    /// <summary>
    /// Номер аптеки
    /// </summary>
    public int PharmacyNumber { get; set; } = pharmacyNumber;

    /// <summary>
    /// Название аптеки
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Телефон аптеки
    /// </summary>
    public long PhoneNumber { get; set; } = phoneNumber;

    /// <summary>
    /// Адрес аптеки
    /// </summary>
    public string Address { get; set; } = address;

    /// <summary>
    /// Полное имя директора аптеки
    /// </summary>
    public string DirectorFullName { get; set; } = directorFullName;
}
