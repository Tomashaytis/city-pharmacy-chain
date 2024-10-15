using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmaceuticalGroupRepository : IRepository<PharmaceuticalGroup>
{
    private List<PharmaceuticalGroup> _values;

    public PharmaceuticalGroupRepository()
    {
        _values =
        [
            new PharmaceuticalGroup(1, 1, "Anticoagulant"),
            new PharmaceuticalGroup(2, 2, "Antibacterial agent"),
            new PharmaceuticalGroup(3, 2, "Desinfectant"),
            new PharmaceuticalGroup(4, 3, "Liniment"),
            new PharmaceuticalGroup(5, 4, "Nonsteroidal anti-inflammatory drug"),
            new PharmaceuticalGroup(6, 5, "Vasoconstrictor drug"),
            new PharmaceuticalGroup(7, 6, "Antibacterial agent"),
            new PharmaceuticalGroup(8, 7, "Antibacterial agent"),
            new PharmaceuticalGroup(9, 8, "Analgesic agent"),
            new PharmaceuticalGroup(10, 8, "Nonsteroidal anti-inflammatory drug"),
            new PharmaceuticalGroup(11, 8, "Psychostimulant"),
            new PharmaceuticalGroup(12, 9, "Nonsteroidal anti-inflammatory drug"),
        ];
    }

    public IEnumerable<PharmaceuticalGroup> GetAll()
    {
        return _values;
    }

    public PharmaceuticalGroup? GetById(int id)
    {
        return _values.Find(x => x.PharmaceuticalGroupId == id);
    }

    public void Post(PharmaceuticalGroup entity)
    {
        _values.Add(entity);
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
        _values.Remove(value);
        return true;
    }

    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach(var value in _values)
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
