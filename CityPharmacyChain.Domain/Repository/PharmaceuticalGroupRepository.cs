using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmaceuticalGroupRepository(DataBase dataBase) : IRepository<PharmaceuticalGroup>
{
    public IEnumerable<PharmaceuticalGroup> GetAll()
    {
        return dataBase.PharmaceuticalGroups;
    }

    public PharmaceuticalGroup? GetById(int id)
    {
        return dataBase.PharmaceuticalGroups.Find(x => x.PharmaceuticalGroupId == id);
    }

    public void Post(PharmaceuticalGroup entity)
    {
        dataBase.PharmaceuticalGroups.Add(entity);
    }

    public bool Put(PharmaceuticalGroup entity)
    {
        var value = GetById(entity.PharmaceuticalGroupId);
        if (value is null)
            return false;
        value.ProductId = entity.ProductId;
        value.Name = entity.Name;
        return true;
    }

    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        dataBase.PharmaceuticalGroups.Remove(value);
        return true;
    }

    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach(var value in dataBase.PharmaceuticalGroups)
        {
            ids.Add(value.PharmaceuticalGroupId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }
}
