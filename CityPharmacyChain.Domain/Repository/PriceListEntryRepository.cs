using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PriceListEntryRepository
{
    public List<PriceListEntry> PriceList { get; set; } = [];

    public PriceListEntryRepository()
    {
        PriceList =
        [
            new PriceListEntry(1, 1, 1, 1, "JSC Nizhpharm", PaymentType.Cashless, DateTime.Parse("2024-08-01")),
            new PriceListEntry(2, 2, 1, 2,  "JSC Nizhpharm", PaymentType.Cash, DateTime.Parse("2024-09-12")),
            new PriceListEntry(3, 5, 1, 3, "Pharmstandard-medicines", PaymentType.Cash, DateTime.Parse("2024-07-24")),
            new PriceListEntry(4, 1, 1, 2, "JSC Nizhpharm", PaymentType.Cashless, DateTime.Parse("2024-08-01")),
            new PriceListEntry(5, 2, 1, 3, "JSC Nizhpharm", PaymentType.Cash, DateTime.Parse("2024-09-12")),
            new PriceListEntry(6, 5, 1, 1, "Pharmstandard-medicines", PaymentType.Cash, DateTime.Parse("2024-07-24")),

            new PriceListEntry(7, 3, 2, 1, "JSC Tula Pharmaceutical Factory", PaymentType.Cashless, DateTime.Parse("2024-09-05")),
            new PriceListEntry(8, 4, 2, 2, "JSC Reckitt Benckiser", PaymentType.Cashless, DateTime.Parse("2024-08-11")),
            new PriceListEntry(9, 3, 2, 3, "JSC Tula Pharmaceutical Factory", PaymentType.Cashless, DateTime.Parse("2024-09-05")),
            new PriceListEntry(10, 4, 2, 2, "JSC Reckitt Benckiser", PaymentType.Cashless, DateTime.Parse("2024-08-11")),

            new PriceListEntry(11, 2, 3, 3, "JSC Nizhpharm", PaymentType.Cash, DateTime.Parse("2024-09-12")),
            new PriceListEntry(12, 6, 3, 4, "JSC Doctor", PaymentType.Cashless, DateTime.Parse("2024-09-01")),
            new PriceListEntry(13, 8, 3, 2, "JSC Lecco", PaymentType.Cash, DateTime.Parse("2024-08-30")),
            new PriceListEntry(14, 6, 3, 3, "JSC Doctor", PaymentType.Cashless, DateTime.Parse("2024-09-01")),
            new PriceListEntry(15, 8, 3, 1, "JSC Lekko", PaymentType.Cash, DateTime.Parse("2024-08-30")),

            new PriceListEntry(16, 2, 4, 4, "JSC Nizhpharm", PaymentType.Cash, DateTime.Parse("2024-09-12")),
            new PriceListEntry(17, 2, 4, 3, "JSC Nizhpharm", PaymentType.Cashless, DateTime.Parse("2024-09-14")),
            new PriceListEntry(18, 9, 4, 4, "Jelfa S A", PaymentType.Cash, DateTime.Parse("2024-08-30")),
            new PriceListEntry(19, 9, 4, 5, "Jelfa S A", PaymentType.Cash, DateTime.Parse("2024-08-30")),
            new PriceListEntry(20, 7, 4, 1, "JSC Lekko", PaymentType.Cash, DateTime.Parse("2024-09-03")),
            new PriceListEntry(21, 7, 4, 1, "JSC Lekko", PaymentType.Cash, DateTime.Parse("2024-09-03")),
        ];
    }

    public PriceListEntry GetById(int id)
    {
        var selection = PriceList.Where(x => x.PriceListEntryId == id).ToList();
        if (selection.Count is 0)
            throw new Exception($"There is no record with the id {id} in the data.");
        return selection[0];
    }

    public void Create(PriceListEntry priceListEntry)
    {
        var id = 1;
        if (PriceList.Count != 0)
            id = PriceList.Max(x => x.PriceListEntryId) + 1;
        priceListEntry.PriceListEntryId = id;
        PriceList.Add(priceListEntry);
    }

    public void Update(PriceListEntry priceListEntry)
    {
        for (var i = 0; i < PriceList.Count; i++)
        {
            if (PriceList[i].PriceListEntryId == priceListEntry.PriceListEntryId)
            {
                PriceList[i] = priceListEntry;
                return;
            }
        }
        throw new Exception($"There is no record with the id {priceListEntry.PriceListEntryId} in the data.");
    }

    public void Delete(int id)
    {
        var index = -1;
        for (var i = 0; i < PriceList.Count; i++)
        {
            if (PriceList[i].PriceListEntryId == id)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
            PriceList.RemoveAt(index);
        else
            throw new Exception($"There is no record with the id {id} in the data.");
    }
}
