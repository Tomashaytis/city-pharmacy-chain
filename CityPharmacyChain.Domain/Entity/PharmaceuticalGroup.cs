namespace CityPharmacyChain.Domain.Entity;

public class PharmaceuticalGroup(int pharmaceuticalGroupId, int productId, string name)
{
    public int PharmaceuticalGroupId { get; set; } = pharmaceuticalGroupId;
    public int ProductId { get; set; } = productId;
    public string Name { get; set; } = name;
}