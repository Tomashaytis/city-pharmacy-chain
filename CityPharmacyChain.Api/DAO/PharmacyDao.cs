using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.DAO;

public class PharmacyDao : IDao<Pharmacy>
{
    public List<Pharmacy> Values { get; set; } = [];

    public PharmacyDao()
    {
        Values =
        [
            new Pharmacy(1, 100, "VITA", 89456372837, "Samara, Novo-Sadovaya st., 36", "Ivanov Ivan Ivanovich"),
            new Pharmacy(2, 201, "April", 86748356473, "Samara, Lenin ave., 6", "Sergeev Gennady Vasilievich"),
            new Pharmacy(3, 103, "BE HEALTHY!", 87443856936, "Samara, Lenin ave., 14", "Andreeva Nadezhda Ivanovna"),
            new Pharmacy(4, 432, "Implosion", 89975362563, "Samara, Lenin ave., 6", "Petrov Petr Sergeevich"),
        ];
    }

    public Pharmacy GetById(int id)
    {
        var selection =  Values.Where(x => x.PharmacyId == id).ToList();
        if (selection.Count is 0)
            throw new Exception($"There is no record with the id {id} in the data.");
        return selection[0];
    }

    public void Create(Pharmacy obj)
    {
        var id = 1;
        if (Values.Count != 0)
            id = Values.Max(x => x.PharmacyId) + 1;
        obj.PharmacyId = id;
        Values.Add(obj);
    }

    public void Update(Pharmacy obj)
    {
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i].PharmacyId == obj.PharmacyId)
            {
                Values[i] = obj;
                return;
            }
        }
        throw new Exception($"There is no record with the id {obj.PharmacyId} in the data.");
    }

    public void Delete(int id)
    {
        var index = -1;
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i].PharmacyId == id)
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
