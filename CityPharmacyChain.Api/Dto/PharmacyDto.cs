namespace CityPharmacyChain.Api.Dto;

public class PharmacyDto(int pharmacyNumber = 0, string name = "", long phoneNumber = 0, string address = "", string directorFullName = "")
{
    public int PharmacyNumber { get; set; } = pharmacyNumber;
    public string Name { get; set; } = name;
    public long PhoneNumber { get; set; } = phoneNumber;
    public string Address { get; set; } = address;
    public string DirectorFullName { get; set; } = directorFullName;
}
