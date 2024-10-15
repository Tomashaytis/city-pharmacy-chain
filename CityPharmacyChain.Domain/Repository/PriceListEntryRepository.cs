using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PriceListEntryRepository : IRepository<PriceListEntry>
{
    private List<PriceListEntry> _values;

    public PriceListEntryRepository()
    {
        _values =
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

    public IEnumerable<PriceListEntry> GetAll()
    {
        return _values;
    }

    public PriceListEntry? GetById(int id)
    {
        return _values.Find(x => x.PriceListEntryId == id);
    }

    public void Post(PriceListEntry entity)
    {
        _values.Add(entity);
    }

    public bool Put(PriceListEntry entity)
    {
        var value = GetById(entity.PriceListEntryId);
        if (value is null)
            return false;
        value.ProductId = entity.ProductId;
        value.PharmacyId = entity.PharmacyId;
        value.Manufacturer = entity.Manufacturer;
        value.SaleDate = entity.SaleDate;;
        value.PaymentType = entity.PaymentType;
        value.SoldCount = entity.SoldCount;
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
        foreach (var value in _values)
        {
            ids.Add(value.PriceListEntryId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }
}
