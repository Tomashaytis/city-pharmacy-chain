using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.DAO;

public class PharmaceuticalGroupDao : IDao<PharmaceuticalGroup>
{
    public List<PharmaceuticalGroup> Values { get; set; } = [];

    public PharmaceuticalGroupDao()
    {
        Values =
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

    public PharmaceuticalGroup GetById(int id)
    {
        var selection = Values.Where(x => x.PharmaceuticalGroupId == id).ToList();
        if (selection.Count is 0)
            throw new Exception($"There is no record with the id {id} in the data.");
        return selection[0];
    }

    public void Create(PharmaceuticalGroup obj)
    {
        var id = 1;
        if (Values.Count != 0)
            id = Values.Max(x => x.PharmaceuticalGroupId) + 1;
        obj.PharmaceuticalGroupId = id;
        Values.Add(obj);
    }

    public void Update(PharmaceuticalGroup obj)
    {
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i].PharmaceuticalGroupId == obj.PharmaceuticalGroupId)
            {
                Values[i] = obj;
                return;
            }
        }
        throw new Exception($"There is no record with the id {obj.PharmaceuticalGroupId} in the data.");
    }

    public void Delete(int id)
    {
        var index = -1;
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i].PharmaceuticalGroupId == id)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
            Values.RemoveAt(index);
        else
            throw new Exception($"There is no record with the id {id} in the data.");
    }
}
