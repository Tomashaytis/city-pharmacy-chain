using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmacyRepository : IRepository<Pharmacy>
{
    private List<Pharmacy> _values { get; set; } = [];

    public PharmacyRepository()
    {
        _values =
        [
            new Pharmacy(1, 100, "VITA", 89456372837, "Samara, Novo-Sadovaya st., 36", "Ivanov Ivan Ivanovich"),
            new Pharmacy(2, 201, "April", 86748356473, "Samara, Lenin ave., 6", "Sergeev Gennady Vasilievich"),
            new Pharmacy(3, 103, "BE HEALTHY!", 87443856936, "Samara, Lenin ave., 14", "Andreeva Nadezhda Ivanovna"),
            new Pharmacy(4, 432, "Implosion", 89975362563, "Samara, Lenin ave., 6", "Petrov Petr Sergeevich"),
        ];
    }

    public IEnumerable<Pharmacy> GetAll()
    {
        return _values;
    }

    public Pharmacy? GetById(int id)
    {
        return _values.Find(x => x.PharmacyId == id);
    }

    public bool Post(Pharmacy entity)
    {
        var value = GetById(entity.PharmacyId);
        if (value is not null)
            return false;
        _values.Add(entity);
        return true;
    }

    public bool Put(Pharmacy entity)
    {
        var value = GetById(entity.PharmacyId);
        if (value is null)
            return false;
        value.PharmacyNumber = entity.PharmacyNumber;
        value.DirectorFullName = entity.DirectorFullName;
        value.PhoneNumber = entity.PhoneNumber;
        value.Name = entity.Name;
        value.Address = entity.Address;
        return true;
    }

    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        _values.Remove(value);
        return true;
    }
}
