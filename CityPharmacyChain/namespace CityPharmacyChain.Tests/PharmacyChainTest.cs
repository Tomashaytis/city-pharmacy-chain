using CityPharmacyChain.Domain;

namespace CityPharmacyChain.Tests
{
    public class PharmacyChainTest(PharmacyChainFixture fixture): IClassFixture<PharmacyChainFixture>
    {
        private PharmacyChainFixture _fixture = fixture;

        [Fact]
        public void TestSelectAllProductsForPharmacy()
        {
            var allProductsForPharmacy =
                (from pharmacy in _fixture.PharmacyList
                 join product in _fixture.ProductList on pharmacy.PharmacyNumber equals product.PharmacyNumber
                 orderby product.Name
                 where pharmacy.Name is "������"
                 select new
                 {
                     product.ProductCode,
                     product.Name,
                     product.Count,
                     product.ProductGroup,
                 });
            Assert.Equal(allProductsForPharmacy,
                [
                    new { ProductCode = 1, Name = "����������� ����", Count = 10, ProductGroup = "���� ��� ��������� ����������" },
                    new { ProductCode = 2, Name = "����������", Count = 19, ProductGroup = "���� ��� ��������� ����������" },
                    new { ProductCode = 4, Name = "������� ��������", Count = 5, ProductGroup = "��������, �������� ���������" },
                    new { ProductCode = 8, Name = "��������� ������ ����", Count = 2, ProductGroup = "���� ��� ��������� ����������" },
                    new { ProductCode = 5, Name = "�������� �����", Count = 17, ProductGroup = "����� ���������" },
                    new { ProductCode = 6, Name = "���������� �������", Count = 3, ProductGroup = "������� ��� ��������� ����������" },
                    new { ProductCode = 9, Name = "������ ��� ��������", Count = 12, ProductGroup = "��������, �������� ���������" },
                ]);
        }

        [Fact]
        public void TestSelectProductCount()
        {
            var productCount =
                from pharmacy in _fixture.PharmacyList
                join product in _fixture.ProductList on pharmacy.PharmacyNumber equals product.PharmacyNumber
                orderby product.Name
                where product.Name is "����������"
                select new
                {
                    pharmacy.Name,
                    product.Count,
                };
            Assert.Equal(productCount, 
                [
                    new { Name = "����", Count = 10 }, 
                    new { Name = "������", Count = 19 }, 
                    new { Name = "��������", Count = 3 },
                ]);
        }

        [Fact]
        public void TestSelectAvgProductPriceForEachPharmacy()
        {
            var avgProductPriceForEachPharmacy =
                from pharmaceuticalGroup in _fixture.PharmaceuticalGroups
                join product in _fixture.ProductList on pharmaceuticalGroup.ProductCode equals product.ProductCode
                join pharmacy in _fixture.PharmacyList on product.PharmacyNumber equals pharmacy.PharmacyNumber
                join priceListEntry in _fixture.PriceList on product.ProductCode equals priceListEntry.ProductCode
                group priceListEntry by new { PharmacyName = pharmacy.Name, pharmaceuticalGroup.Name, priceListEntry.Price } into result
                select new
                {
                    result.Key.PharmacyName,
                    result.Key.Name,
                    AveragePrice = result.Average(p => p.Price)
                };
            Assert.Equal("����", avgProductPriceForEachPharmacy.First().Name);
            Assert.Equal("�������������", avgProductPriceForEachPharmacy.First().Name);
            Assert.True(145.9 < avgProductPriceForEachPharmacy.First().AveragePrice && avgProductPriceForEachPharmacy.First().AveragePrice < 146.1);
        }

        [Fact]
        public void TestSelectMaxProductSales()
        {
            var maxProductSales =
                from pharmacy in _fixture.PharmacyList
                join priceListEntry in _fixture.PriceList on pharmacy.PharmacyNumber equals priceListEntry.PharmacyNumber
                join product in _fixture.ProductList on priceListEntry.PharmacyNumber equals product.PharmacyNumber
                where product.Name == "����������" && (priceListEntry.SaleDate > DateTime.Parse("2024-08-15") && priceListEntry.SaleDate < DateTime.Parse("2024-09-20"))
                group product by new { pharmacy.Name, product.Count } into result
                select new
                {
                    result.Key.Name,
                    SaleCount = result.Count(),
                    SaleVolume = result.Sum(p => p.Count),
                };
            maxProductSales = 
                (from maxProductSale in maxProductSales
                orderby maxProductSale.SaleCount, maxProductSale.SaleVolume descending
                select maxProductSale).Take(5);
            Assert.Equal(maxProductSales,
                [
                    new { Name = "������", SaleCount = 1, SaleVolume = 19 },
                    new { Name = "����", SaleCount = 1, SaleVolume = 10 },
                    new { Name = "��������", SaleCount = 2, SaleVolume = 6 },
                ]);
        }
    }
}