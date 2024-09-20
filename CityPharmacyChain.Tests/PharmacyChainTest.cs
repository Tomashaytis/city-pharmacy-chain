namespace CityPharmacyChain.Tests
{
    public class PharmacyChainTest(PharmacyChainFixture fixture): IClassFixture<PharmacyChainFixture>
    {
        private readonly PharmacyChainFixture _fixture = fixture;
        
        [Fact]
        public void TestSelectAllProductsForPharmacy()
        {
            var allProductsForPharmacy =
                from pharmacy in _fixture.PharmacyList
                join pharmacyProduct in _fixture.PharmacyProductList on pharmacy.PharmacyNumber equals pharmacyProduct.PharmacyNumber
                join product in _fixture.ProductList on pharmacyProduct.ProductCode equals product.ProductCode
                orderby product.Name
                where pharmacy.Name is "������"
                select new
                {
                    product.ProductCode,
                    product.Name,
                    pharmacyProduct.Count,
                    product.ProductGroup,
                };
            
            Assert.Equal(allProductsForPharmacy.ToArray(),
                ([
                    new { ProductCode = 1, Name = "����������� ����", Count = 10, ProductGroup = "���� ��� ��������� ����������" },
                    new { ProductCode = 2, Name = "����������", Count = 19, ProductGroup = "���� ��� ��������� ����������" },
                    new { ProductCode = 4, Name = "������� ��������", Count = 6, ProductGroup = "��������, �������� ���������" },
                    new { ProductCode = 8, Name = "��������� ������ ����", Count = 2, ProductGroup = "���� ��� ��������� ����������" },
                    new { ProductCode = 5, Name = "�������� �����", Count = 17, ProductGroup = "����� ���������" },
                    new { ProductCode = 6, Name = "���������� �������", Count = 3, ProductGroup = "������� ��� ��������� ����������" },
                    new { ProductCode = 9, Name = "������ ��� ��������", Count = 12, ProductGroup = "��������, �������� ���������" },
                ]));
        }

        [Fact]
        public void TestSelectProductCount()
        {
            var productCount =
                from pharmacy in _fixture.PharmacyList
                join pharmacyProduct in _fixture.PharmacyProductList on pharmacy.PharmacyNumber equals pharmacyProduct.PharmacyNumber
                join product in _fixture.ProductList on pharmacyProduct.ProductCode equals product.ProductCode
                orderby product.Name
                where product.Name is "����������"
                select new
                {
                    pharmacy.Name,
                    pharmacyProduct.Count,
                };
            Assert.Equal(productCount.ToArray(), 
                [
                    new { Name = "����", Count = 10 }, 
                    new { Name = "������", Count = 19 }, 
                    new { Name = "��������", Count = 3 },
                ]);
        }

        [Fact]
        public void TestSelectAvgProductPriceForPharmacy()
        {
            var pharmaceuticalGroupPriceForPharmacy =
                from pharmaceuticalGroup in _fixture.PharmaceuticalGroups
                join product in _fixture.ProductList on pharmaceuticalGroup.ProductCode equals product.ProductCode
                join pharmacyProduct in _fixture.PharmacyProductList on product.ProductCode equals pharmacyProduct.ProductCode
                join pharmacy in _fixture.PharmacyList on pharmacyProduct.PharmacyNumber equals pharmacy.PharmacyNumber
                join priceListEntry in _fixture.PriceList on product.ProductCode equals priceListEntry.ProductCode
                select new
                {
                    pharmaceuticalGroup.Name,
                    PharmacyName = pharmacy.Name,
                    priceListEntry.Price,
                };
            var avgPharmaceuticalGroupPriceForPharmacy =
                from entry in pharmaceuticalGroupPriceForPharmacy
                where entry.PharmacyName == "����"
                group entry by entry.Name into result
                select new
                {
                    Name = result.Key,
                    Price = result.Average(p => p.Price),
                };
            Assert.Equal("�������������", avgPharmaceuticalGroupPriceForPharmacy.First().Name);
            Assert.True(145.9 < avgPharmaceuticalGroupPriceForPharmacy.First().Price && avgPharmaceuticalGroupPriceForPharmacy.First().Price < 146.1);
        }

        [Fact]
        public void TestSelectMaxProductSoldVolumes()
        {
            var tmpMaxProductSoldVolumes =
                from pharmacy in _fixture.PharmacyList
                join priceListEntry in _fixture.PriceList on pharmacy.PharmacyNumber equals priceListEntry.PharmacyNumber
                join product in _fixture.ProductList on priceListEntry.ProductCode equals product.ProductCode
                where product.Name == "����������" && (priceListEntry.SaleDate > DateTime.Parse("2024-08-15") && priceListEntry.SaleDate < DateTime.Parse("2024-09-20"))
                group priceListEntry by priceListEntry.PharmacyNumber into results
                select new
                {
                    PharmacyNumber = results.Key,
                    SoldCount = results.Count(),
                    SoldVolume = results.Sum(p => p.SoldCount),
                };
            var maxProductSoldVolumes =
                (from maxProductSoldVolume in tmpMaxProductSoldVolumes
                 join pharmacy in _fixture.PharmacyList on maxProductSoldVolume.PharmacyNumber equals pharmacy.PharmacyNumber
                 orderby maxProductSoldVolume.SoldCount descending
                 orderby maxProductSoldVolume.SoldVolume descending
                 select new
                 {
                     pharmacy.Name,
                     maxProductSoldVolume.SoldCount,
                     maxProductSoldVolume.SoldVolume
                 }).Take(5);
            Assert.Equal(maxProductSoldVolumes.ToArray(),
                [
                    new { Name = "��������", SoldCount = 2, SoldVolume = 7 },
                    new { Name = "����", SoldCount = 2, SoldVolume = 5 },
                    new { Name = "���� ������!", SoldCount = 1, SoldVolume = 3 },
                ]);
        }

        [Fact]
        public void TestSelectPharmaciesWithBigProductSoldVolume()
        {
            var tmpPharmaciesWithBigProductSoldVolumes =
                from pharmacy in _fixture.PharmacyList
                join priceListEntry in _fixture.PriceList on pharmacy.PharmacyNumber equals priceListEntry.PharmacyNumber
                join product in _fixture.ProductList on priceListEntry.ProductCode equals product.ProductCode
                where pharmacy.Address.Contains("��-�. ������") && product.Name == "����������"
                group priceListEntry by priceListEntry.PharmacyNumber into result
                select new
                {
                    PharmacyNumber = result.Key,
                    SoldVolume = result.Sum(p => p.SoldCount),
                };
            var pharmaciesWithBigProductSoldVolumes =
                 from entry in tmpPharmaciesWithBigProductSoldVolumes
                 join pharmacy in _fixture.PharmacyList on entry.PharmacyNumber equals pharmacy.PharmacyNumber
                 where entry.SoldVolume > 2
                 select new
                 {
                     pharmacy.Name,
                 };
            Assert.Equal(pharmaciesWithBigProductSoldVolumes,
                [
                    new { Name = "���� ������!" },
                    new { Name = "��������" }
                ]);
        }

        [Fact]
        public void TestSelectPharmaciesWithMinProductPrice()
        {
            var tmpPharmaciesWithMinProductPrice =
                from pharmacy in _fixture.PharmacyList
                join priceListEntry in _fixture.PriceList on pharmacy.PharmacyNumber equals priceListEntry.PharmacyNumber
                join product in _fixture.ProductList on priceListEntry.ProductCode equals product.ProductCode
                where product.Name == "����������"
                group priceListEntry by priceListEntry.PharmacyNumber into result
                select new
                {
                    PharmacyNumber = result.Key,
                    SoldVolume = result.Min(p => p.Price),
                };
            var pharmaciesWithMinProductPrice =
                 from entry in tmpPharmaciesWithMinProductPrice
                 join pharmacy in _fixture.PharmacyList on entry.PharmacyNumber equals pharmacy.PharmacyNumber
                 let min = tmpPharmaciesWithMinProductPrice.Min(p => p.SoldVolume)
                 where entry.SoldVolume < min + 0.01 && entry.SoldVolume > min - 0.01
                 select new
                 {
                     pharmacy.Name,
                 };
            Assert.Equal(pharmaciesWithMinProductPrice,
                [
                    new { Name = "���� ������!" },
                    new { Name = "��������" }
                ]);
        }
    }
}