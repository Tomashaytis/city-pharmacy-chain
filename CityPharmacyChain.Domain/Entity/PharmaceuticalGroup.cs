namespace CityPharmacyChain.Domain.Entity;

public class PharmaceuticalGroup(int pharmaceuticalGroupId = 0, int productId = 0, string name = "")
{
    public int PharmaceuticalGroupId { get; set; } = pharmaceuticalGroupId;
    public int ProductId { get; set; } = productId;
    public string Name { get; set; } = name;
}