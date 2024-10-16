namespace CityPharmacyChain.Api.Dto;

public class PharmaceuticalGroupDto(int productId = 0, string name = "")
{
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public int ProductId { get; set; } = productId;

    /// <summary>
    /// Название фармацевтической группы
    /// </summary>
    public string Name { get; set; } = name;
}