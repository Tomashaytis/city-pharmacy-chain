namespace CityPharmacyChain.Api.Dto;

public class PharmacyDtoGet(int pharmacyNumber, string name, long phoneNumber, string address, string directorFullName)
{
    public int PharmacyNumber { get; set; } = pharmacyNumber;
    public string Name { get; set; } = name;
    public long PhoneNumber { get; set; } = phoneNumber;
    public string Address { get; set; } = address;
    public string DirectorFullName { get; set; } = directorFullName;
}
