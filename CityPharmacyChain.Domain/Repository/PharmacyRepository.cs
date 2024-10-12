using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmacyRepository
{
    public List<Pharmacy> PharmacyList { get; set; } = [];

    public PharmacyRepository()
    {
        PharmacyList =
        [
            new Pharmacy(1, 100, "VITA", 89456372837, "Samara, Novo-Sadovaya st., 36", "Ivanov Ivan Ivanovich"),
            new Pharmacy(2, 201, "April", 86748356473, "Samara, Lenin ave., 6", "Sergeev Gennady Vasilievich"),
            new Pharmacy(3, 103, "BE HEALTHY!", 87443856936, "Samara, Lenin ave., 14", "Andreeva Nadezhda Ivanovna"),
            new Pharmacy(4, 432, "Implosion", 89975362563, "Samara, Lenin ave., 6", "Petrov Petr Sergeevich"),
        ];
    }

    public Pharmacy GetById(int id)
    {
        var selection =  PharmacyList.Where(x => x.PharmacyId == id).ToList();
        if (selection.Count is 0)
            throw new Exception($"There is no record with the id {id} in the data.");
        return selection[0];
    }

    public void Create(Pharmacy pharmacy)
    {
        var id = 1;
        if (PharmacyList.Count != 0)
            id = PharmacyList.Max(x => x.PharmacyId) + 1;
        pharmacy.PharmacyId = id;
        PharmacyList.Add(pharmacy);
    }

    public void Update(Pharmacy pharmacy)
    {
        for (var i = 0; i < PharmacyList.Count; i++)
        {
            if (PharmacyList[i].PharmacyId == pharmacy.PharmacyId)
            {
                PharmacyList[i] = pharmacy;
                return;
            }
        }
        throw new Exception($"There is no record with the id {pharmacy.PharmacyId} in the data.");
    }

    public void Delete(int id)
    {
        var index = -1;
        for (var i = 0; i < PharmacyList.Count; i++)
        {
            if (PharmacyList[i].PharmacyId == id)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
            PharmacyList.RemoveAt(index);
        else
            throw new Exception($"There is no record with the id {id} in the data.");
    }
}
