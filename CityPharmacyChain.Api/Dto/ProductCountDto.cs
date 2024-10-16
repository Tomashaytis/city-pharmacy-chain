namespace CityPharmacyChain.Api.Dto;

public class ProductCountDto(string productName = "", int count = 0)
{
    /// <summary>
    /// Название препарата
    /// </summary>
    public string ProductName { get; set; } = productName;

    /// <summary>
    /// Количество препарата на складе аптеки
    /// </summary>
    public int Count { get; set; } = count;
}
