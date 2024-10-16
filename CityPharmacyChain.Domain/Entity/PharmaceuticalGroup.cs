namespace CityPharmacyChain.Domain.Entity;

public class PharmaceuticalGroup(int pharmaceuticalGroupId = 0, int productId = 0, string name = "")
{
    /// <summary>
    /// Идентификатор фармацевтической группы препарата
    /// </summary>
    public int PharmaceuticalGroupId { get; set; } = pharmaceuticalGroupId;

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Название фармацевтической группы препарата
    /// </summary>
    public string Name { get; set; } = name;
}