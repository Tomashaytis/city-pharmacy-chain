namespace CityPharmacyChain.Api.Dto;

public class PharmaceuticalGroupDto(int productId = 0, string name = "")
{
    public int ProductId { get; set; } = productId;
    public string Name { get; set; } = name;
}