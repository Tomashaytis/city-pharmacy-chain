using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Api.DAO;

public class PriceListEntryDao : IDao<PriceListEntry>
{
    public List<PriceListEntry> Values { get; set; } = [];

    public PriceListEntryDao()
    {
        Values =
        [
            new PriceListEntry(1, 1, 1, 1, "JSC Nizhpharm", "cashless", DateTime.Parse("2024-08-01")),
            new PriceListEntry(2, 2, 1, 2,  "JSC Nizhpharm", "cash", DateTime.Parse("2024-09-12")),
            new PriceListEntry(3, 5, 1, 3, "Pharmstandard-medicines", "cashless", DateTime.Parse("2024-07-24")),
            new PriceListEntry(4, 1, 1, 2, "JSC Nizhpharm", "cashless", DateTime.Parse("2024-08-01")),
            new PriceListEntry(5, 2, 1, 3, "JSC Nizhpharm", "cash", DateTime.Parse("2024-09-12")),
            new PriceListEntry(6, 5, 1, 1, "Pharmstandard-medicines", "cash", DateTime.Parse("2024-07-24")),

            new PriceListEntry(7, 3, 2, 1, "JSC Tula Pharmaceutical Factory", "cashless", DateTime.Parse("2024-09-05")),
            new PriceListEntry(8, 4, 2, 2, "JSC Reckitt Benckiser", "cashless", DateTime.Parse("2024-08-11")),
            new PriceListEntry(9, 3, 2, 3, "JSC Tula Pharmaceutical Factory", "cashless", DateTime.Parse("2024-09-05")),
            new PriceListEntry(10, 4, 2, 2, "JSC Reckitt Benckiser", "cashless", DateTime.Parse("2024-08-11")),

            new PriceListEntry(11, 2, 3, 3, "JSC Nizhpharm", "cash", DateTime.Parse("2024-09-12")),
            new PriceListEntry(12, 6, 3, 4, "JSC Doctor", "cashless", DateTime.Parse("2024-09-01")),
            new PriceListEntry(13, 8, 3, 2, "JSC Lecco", "cash", DateTime.Parse("2024-08-30")),
            new PriceListEntry(14, 6, 3, 3, "JSC Doctor", "cashless", DateTime.Parse("2024-09-01")),
            new PriceListEntry(15, 8, 3, 1, "JSC Lekko", "cash", DateTime.Parse("2024-08-30")),

            new PriceListEntry(16, 2, 4, 4, "JSC Nizhpharm", "cash", DateTime.Parse("2024-09-12")),
            new PriceListEntry(17, 2, 4, 3, "JSC Nizhpharm", "cashless", DateTime.Parse("2024-09-14")),
            new PriceListEntry(18, 9, 4, 4, "Jelfa S A", "cash", DateTime.Parse("2024-08-30")),
            new PriceListEntry(19, 9, 4, 5, "Jelfa S A", "cash", DateTime.Parse("2024-08-30")),
            new PriceListEntry(20, 7, 4, 1, "JSC Lekko", "cash", DateTime.Parse("2024-09-03")),
            new PriceListEntry(21, 7, 4, 1, "JSC Lekko", "cash", DateTime.Parse("2024-09-03")),
        ];
    }

    public PriceListEntry GetById(int id)
    {
        var selection = Values.Where(x => x.PriceListEntryId == id).ToList();
        if (selection.Count is 0)
            throw new Exception($"There is no record with the id {id} in the data.");
        return selection[0];
    }

    public void Create(PriceListEntry obj)
    {
        var id = 1;
        if (Values.Count != 0)
            id = Values.Max(x => x.PriceListEntryId) + 1;
        obj.PriceListEntryId = id;
        Values.Add(obj);
    }

    public void Update(PriceListEntry obj)
    {
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i].PriceListEntryId == obj.PriceListEntryId)
            {
                Values[i] = obj;
                return;
            }
        }
        throw new Exception($"There is no record with the id {obj.PriceListEntryId} in the data.");
    }

    public void Delete(int id)
    {
        var index = -1;
        for (var i = 0; i < Values.Count; i++)
        {
            if (Values[i].PriceListEntryId == id)
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
