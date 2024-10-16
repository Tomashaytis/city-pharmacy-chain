namespace CityPharmacyChain.Domain.Entity;

public class Product(int productId = 0, int productCode = 0, string name = "", string productGroup = "")
{
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int ProductId { get; set; } = productId;

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
