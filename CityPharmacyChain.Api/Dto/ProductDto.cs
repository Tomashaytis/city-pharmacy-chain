namespace CityPharmacyChain.Api.Dto;

public class ProductDto(int productCode = 0, string name = "", string productGroup = "")
{
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
