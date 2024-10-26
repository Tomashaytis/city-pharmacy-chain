using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Tests;

public class PharmacyChainFixture
{
    public List<PriceListEntry> PriceList { get; set; }
    public List<Pharmacy> PharmacyList { get; set; }
    public List<Product> ProductList { get; set; }
    public List<PharmaceuticalGroup> PharmaceuticalGroupList { get; set; }
    public List<PharmacyProduct> PharmacyProductList { get; set; }

    public PharmacyChainFixture()
    {
        PharmacyList =
        [
            new Pharmacy(1, 1, "VITA", 89456372837, "Samara, Novo-Sadovaya st., 36", "Ivanov Ivan Ivanovich"),
            new Pharmacy(2, 2, "April", 86748356473, "Samara, Lenin ave., 6", "Sergeev Gennady Vasilievich"),
            new Pharmacy(3, 3, "BE HEALTHY!", 87443856936, "Samara, Lenin ave., 14", "Andreeva Nadezhda Ivanovna"),
            new Pharmacy(4, 4, "Implosion", 89975362563, "Samara, Lenin ave., 6", "Petrov Petr Sergeevich"),
        ];

        PriceList =
        [
            new PriceListEntry(1, 1, 1, 1, "JSC Nizhpharm", PaymentType.Cashless, DateTime.Parse("2024-08-01")),
            new PriceListEntry(2, 2, 1, 2,  "JSC Nizhpharm", PaymentType.Cash, DateTime.Parse("2024-09-12")),
            new PriceListEntry(3, 5, 1, 3, "Pharmstandard-medicines", PaymentType.Cashless, DateTime.Parse("2024-07-24")),
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

        PharmaceuticalGroupList =
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

        ProductList =
        [
            new Product(1, 1, "Heparin ointment", "Ointment for external use"),
            new Product(2, 2, "Levomekol", "Ointment for external use"),
            new Product(3, 3, "Vishnevsky ointment", "Ointment for external use"),
            new Product(4, 4, "Nurofen", "Pills"),
            new Product(5, 5, "Rinostop", "Nasal spray"),
            new Product(6, 6, "Streptocide", "Powder for external use"),
            new Product(7, 7, "Sodium sulfacyl", "Капли глазные"),
            new Product(8, 8, "Pentalgin", "Gel for external use"),
            new Product(9, 9, "Trombo", "Pills"),
        ];

        PharmacyProductList =
        [
            new PharmacyProduct(1, 1, 1, 15, 146),
            new PharmacyProduct(2, 2, 1, 10, 190),
            new PharmacyProduct(3, 3, 1, 20, 220),
            new PharmacyProduct(4, 4, 1, 12, 172),
            new PharmacyProduct(5, 5, 1, 5, 200),
            new PharmacyProduct(6, 6, 1, 8, 302),
            new PharmacyProduct(7, 7, 1, 17, 100),
            new PharmacyProduct(8, 8, 1, 10, 235),
            new PharmacyProduct(9, 9, 1, 15, 300),

            new PharmacyProduct(10, 1, 2, 10, 110),
            new PharmacyProduct(11, 2, 2, 19, 117),
            new PharmacyProduct(12, 4, 2, 6, 190),
            new PharmacyProduct(13, 5, 2, 17, 200),
            new PharmacyProduct(14, 6, 2, 3, 310),
            new PharmacyProduct(15, 8, 2, 2, 100),
            new PharmacyProduct(16, 9, 2, 12, 290),

            new PharmacyProduct(17, 1, 3, 10, 110),
            new PharmacyProduct(18, 5, 3, 4, 200),
            new PharmacyProduct(19, 6, 3, 7, 328),
            new PharmacyProduct(20, 7, 3, 17, 100),
            new PharmacyProduct(21, 8, 3, 14, 150),
            new PharmacyProduct(22, 9, 3, 5, 300),

            new PharmacyProduct(23, 1, 4, 1, 200),
            new PharmacyProduct(24, 2, 4, 3, 210),
            new PharmacyProduct(25, 3, 4, 20, 170),
            new PharmacyProduct(26, 4, 4, 12, 217),
            new PharmacyProduct(27, 5, 4, 16, 150),
            new PharmacyProduct(28, 6, 4, 10, 280),
            new PharmacyProduct(29, 7, 4, 11, 230),
        ];
    }
}
