using CityPharmacyChain.Domain;

namespace CityPharmacyChain.Tests
{
    public class PharmacyChainTest(PharmacyChainFixture fixture): IClassFixture<PharmacyChainFixture>
    {
        private readonly PharmacyChainFixture _fixture = fixture;
        
        [Fact]
        public void TestSelectAllProductsForPharmacy()
        {
            var allProductsForPharmacy =
                (from pharmacy in _fixture.PharmacyList
                join pharmacyProduct in _fixture.PharmacyProductList on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
                join product in _fixture.ProductList on pharmacyProduct.ProductId equals product.ProductId
                orderby product.Name
                where pharmacy.Name is "April"
                select new
                {
                    product.ProductCode,
                    product.Name,
                    pharmacyProduct.Count,
                    product.ProductGroup,
                }).ToList();
            
            Assert.Equal(allProductsForPharmacy,
                [
                    new { ProductCode = 1, Name = "Heparin ointment", Count = 10, ProductGroup = "Ointment for external use" },
                    new { ProductCode = 2, Name = "Levomekol", Count = 19, ProductGroup = "Ointment for external use" },
                    new { ProductCode = 4, Name = "Nurofen", Count = 6, ProductGroup = "Pills" },
                    new { ProductCode = 8, Name = "Pentalgin", Count = 2, ProductGroup = "Gel for external use" },
                    new { ProductCode = 5, Name = "Rinostop", Count = 17, ProductGroup = "Nasal spray" },
                    new { ProductCode = 6, Name = "Streptocide", Count = 3, ProductGroup = "Powder for external use" },
                    new { ProductCode = 9, Name = "Trombo", Count = 12, ProductGroup = "Pills" },
                ]);
        }

        [Fact]
        public void TestSelectProductCount()
        {
            var productCount =
                (from pharmacy in _fixture.PharmacyList
                join pharmacyProduct in _fixture.PharmacyProductList on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
                join product in _fixture.ProductList on pharmacyProduct.ProductId equals product.ProductId
                orderby product.Name
                where product.Name is "Levomekol"
                select new
                {
                    pharmacy.Name,
                    pharmacyProduct.Count,
                }).ToList();
            Assert.Equal(productCount, 
                [
                    new { Name = "VITA", Count = 10 }, 
                    new { Name = "April", Count = 19 }, 
                    new { Name = "Implosion", Count = 3 },
                ]);
        }

        [Fact]
        public void TestSelectAvgProductPriceForPharmacy()
        {
            var pharmaceuticalGroupPriceForPharmacy =
                (from pharmaceuticalGroup in _fixture.PharmaceuticalGroupList
                join product in _fixture.ProductList on pharmaceuticalGroup.ProductId equals product.ProductId
                join pharmacyProduct in _fixture.PharmacyProductList on product.ProductId equals pharmacyProduct.ProductId
                join pharmacy in _fixture.PharmacyList on pharmacyProduct.PharmacyId equals pharmacy.PharmacyId
                join priceListEntry in _fixture.PriceList on product.ProductId equals priceListEntry.ProductId
                select new
                {
                    pharmaceuticalGroup.Name,
                    PharmacyName = pharmacy.Name,
                    pharmacyProduct.Price,
                }).ToList();
            var avgPharmaceuticalGroupPriceForPharmacy =
                (from entry in pharmaceuticalGroupPriceForPharmacy
                where entry.PharmacyName == "VITA"
                group entry by entry.Name into result
                select new
                {
                    Name = result.Key,
                    Price = result.Average(p => p.Price),
                }).First();
            Assert.Equal("Anticoagulant", avgPharmaceuticalGroupPriceForPharmacy.Name);
            Assert.True(Math.Abs(avgPharmaceuticalGroupPriceForPharmacy.Price - 146) < 0.01);
        }

        [Fact]
        public void TestSelectMaxProductSoldVolumes()
        {
            var tmpMaxProductSoldVolumes =
                (from pharmacy in _fixture.PharmacyList
                join priceListEntry in _fixture.PriceList on pharmacy.PharmacyId equals priceListEntry.PharmacyId
                join product in _fixture.ProductList on priceListEntry.ProductId equals product.ProductId
                where product.Name == "Levomekol" && (priceListEntry.SaleDate > DateTime.Parse("2024-08-15") && priceListEntry.SaleDate < DateTime.Parse("2024-09-20"))
                group priceListEntry by priceListEntry.PharmacyId into results
                select new
                {
                    PharmacyId = results.Key,
                    SoldCount = results.Count(),
                    SoldVolume = results.Sum(p => p.SoldCount),
                }).ToList();
            var maxProductSoldVolumes =
                (from maxProductSoldVolume in tmpMaxProductSoldVolumes
                 join pharmacy in _fixture.PharmacyList on maxProductSoldVolume.PharmacyId equals pharmacy.PharmacyId
                 orderby maxProductSoldVolume.SoldCount descending, maxProductSoldVolume.SoldVolume descending
                 select new
                 {
                     pharmacy.Name,
                     maxProductSoldVolume.SoldCount,
                     maxProductSoldVolume.SoldVolume
                 }).Take(5).ToList();
            Assert.Equal(maxProductSoldVolumes,
                [
                    new { Name = "Implosion", SoldCount = 2, SoldVolume = 7 },
                    new { Name = "VITA", SoldCount = 2, SoldVolume = 5 },
                    new { Name = "BE HEALTHY!", SoldCount = 1, SoldVolume = 3 },
                ]);
        }

        [Fact]
        public void TestSelectPharmaciesWithLargeProductSoldVolume()
        {
            var tmpPharmaciesWithBigProductSoldVolumes =
                (from pharmacy in _fixture.PharmacyList
                join priceListEntry in _fixture.PriceList on pharmacy.PharmacyId equals priceListEntry.PharmacyId
                join product in _fixture.ProductList on priceListEntry.ProductId equals product.ProductId
                where pharmacy.Address.Contains("Lenin ave.") && product.Name == "Levomekol"
                group priceListEntry by priceListEntry.PharmacyId into result
                select new
                {
                    PharmacyId = result.Key,
                    SoldVolume = result.Sum(p => p.SoldCount),
                }).ToList();
            var pharmaciesWithBigProductSoldVolumes =
                 (from entry in tmpPharmaciesWithBigProductSoldVolumes
                 join pharmacy in _fixture.PharmacyList on entry.PharmacyId equals pharmacy.PharmacyId
                 where entry.SoldVolume > 2
                 select new
                 {
                     pharmacy.Name,
                 }).ToList();
            Assert.Equal(pharmaciesWithBigProductSoldVolumes,
                [
                    new { Name = "BE HEALTHY!" },
                    new { Name = "Implosion" }
                ]);
        }

        [Fact]
        public void TestSelectPharmaciesWithMinProductPrice()
        {
            var tmpPharmaciesWithMinProductPrice =
                (from pharmacy in _fixture.PharmacyList
                join pharmacyProduct in _fixture.PharmacyProductList on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
                join product in _fixture.ProductList on pharmacyProduct.ProductId equals product.ProductCode
                where product.Name == "Levomekol"
                group pharmacyProduct by pharmacy.PharmacyNumber into result
                select new
                {
                    PharmacyId = result.Key,
                    SoldVolume = result.Min(p => p.Price),
                }).ToList();
            var pharmaciesWithMinProductPrice =
                 (from entry in tmpPharmaciesWithMinProductPrice
                 join pharmacy in _fixture.PharmacyList on entry.PharmacyId equals pharmacy.PharmacyId
                 let min = tmpPharmaciesWithMinProductPrice.Min(p => p.SoldVolume)
                 where entry.SoldVolume < min + 0.01 && entry.SoldVolume > min - 0.01
                 select new
                 {
                     pharmacy.Name,
                 }).ToList();
            Assert.Equal(pharmaciesWithMinProductPrice,
                [
                    new { Name = "April" },
                ]);
        }
    }
}