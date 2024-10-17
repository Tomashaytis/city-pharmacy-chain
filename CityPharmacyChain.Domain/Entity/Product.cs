namespace CityPharmacyChain.Domain.Entity;

/// <summary>
/// Класс Entity для сущности класса препарат
/// </summary>
/// <param name="productId">Идентификатор препарата</param>
/// <param name="productCode">Код препарата</param>
/// <param name="name">Название препарата</param>
/// <param name="productGroup">Товарная группа препарата</param>
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
