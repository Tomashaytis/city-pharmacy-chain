using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmacyRepository(DataBase dataBase) : IRepository<Pharmacy>
{
    public IEnumerable<Pharmacy> GetAll()
    {
        return dataBase.Pharmacies;
    }

    public Pharmacy? GetById(int id)
    {
        return dataBase.Pharmacies.Find(x => x.PharmacyId == id);
    }

    public void Post(Pharmacy entity)
    {
        dataBase.Pharmacies.Add(entity);
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
        dataBase.Pharmacies.Remove(value);
        return true;
    }

    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach (var value in dataBase.Pharmacies)
        {
            ids.Add(value.PharmacyId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }
}
