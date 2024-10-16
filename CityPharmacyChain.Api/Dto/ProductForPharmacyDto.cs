namespace CityPharmacyChain.Api.Dto;

public class ProductForPharmacyDto(int count = 0, double price = 0, int productCode = 0, string name = "", string productGroup = "")
{
    /// <summary>
    /// Количество препарата на складе аптеки
    /// </summary>
    public int Count { get; set; } = count;

    /// <summary>
    /// Цена препарата
    /// </summary>
    public double Price { get; set; } = price;

    /// <summary>
    /// Код препарата
    /// </summary>
    public int ProductCode { get; set; } = productCode;

    /// <summary>
    /// Название препарата
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Товарная группа препарата
    /// </summary>
    public string ProductGroup { get; set; } = productGroup;
}
