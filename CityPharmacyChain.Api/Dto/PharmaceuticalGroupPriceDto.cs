namespace CityPharmacyChain.Api.Dto;

public class PharmaceuticalGroupPriceDto(string name = "", double price = 0)
{
    /// <summary>
    /// Название аптеки
    /// </summary>
    public string PharmacyName { get; set; } = name;

    /// <summary>
    /// Название фармацевтической группы
    /// </summary>
    public string PharmaceuticalGroupName { get; set; } = name;

    /// <summary>
    /// Цена препарата
    /// </summary>
    public double Price { get; set; } = price;
}
