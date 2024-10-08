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
                join pharmacyProduct in _fixture.PharmacyProductList on pharmacy.PharmacyNumber equals pharmacyProduct.PharmacyNumber
                join product in _fixture.ProductList on pharmacyProduct.ProductCode equals product.ProductCode
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
                join pharmacyProduct in _fixture.PharmacyProductList on pharmacy.PharmacyNumber equals pharmacyProduct.PharmacyNumber
                join product in _fixture.ProductList on pharmacyProduct.ProductCode equals product.ProductCode
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
                (from pharmaceuticalGroup in _fixture.PharmaceuticalGroups
                join product in _fixture.ProductList on pharmaceuticalGroup.ProductCode equals product.ProductCode
                join pharmacyProduct in _fixture.PharmacyProductList on product.ProductCode equals pharmacyProduct.ProductCode
                join pharmacy in _fixture.PharmacyList on pharmacyProduct.PharmacyNumber equals pharmacy.PharmacyNumber
                join priceListEntry in _fixture.PriceList on product.ProductCode equals priceListEntry.ProductCode
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
                join priceListEntry in _fixture.PriceList on pharmacy.PharmacyNumber equals priceListEntry.PharmacyNumber
                join product in _fixture.ProductList on priceListEntry.ProductCode equals product.ProductCode
                where product.Name == "Levomekol" && (priceListEntry.SaleDate > DateTime.Parse("2024-08-15") && priceListEntry.SaleDate < DateTime.Parse("2024-09-20"))
                group priceListEntry by priceListEntry.PharmacyNumber into results
                select new
                {
                    PharmacyNumber = results.Key,
                    SoldCount = results.Count(),
                    SoldVolume = results.Sum(p => p.SoldCount),
                }).ToList();
            var maxProductSoldVolumes =
                (from maxProductSoldVolume in tmpMaxProductSoldVolumes
                 join pharmacy in _fixture.PharmacyList on maxProductSoldVolume.PharmacyNumber equals pharmacy.PharmacyNumber
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
        public void TestSelectPharmaciesWithBigProductSoldVolume()
        {
            var tmpPharmaciesWithBigProductSoldVolumes =
                (from pharmacy in _fixture.PharmacyList
                join priceListEntry in _fixture.PriceList on pharmacy.PharmacyNumber equals priceListEntry.PharmacyNumber
                join product in _fixture.ProductList on priceListEntry.ProductCode equals product.ProductCode
                where pharmacy.Address.Contains("Lenin ave.") && product.Name == "Levomekol"
                group priceListEntry by priceListEntry.PharmacyNumber into result
                select new
                {
                    PharmacyNumber = result.Key,
                    SoldVolume = result.Sum(p => p.SoldCount),
                }).ToList();
            var pharmaciesWithBigProductSoldVolumes =
                 (from entry in tmpPharmaciesWithBigProductSoldVolumes
                 join pharmacy in _fixture.PharmacyList on entry.PharmacyNumber equals pharmacy.PharmacyNumber
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
                join pharmacyProduct in _fixture.PharmacyProductList on pharmacy.PharmacyNumber equals pharmacyProduct.PharmacyNumber
                join product in _fixture.ProductList on pharmacyProduct.ProductCode equals product.ProductCode
                where product.Name == "Levomekol"
                group pharmacyProduct by pharmacy.PharmacyNumber into result
                select new
                {
                    PharmacyNumber = result.Key,
                    SoldVolume = result.Min(p => p.Price),
                }).ToList();
            var pharmaciesWithMinProductPrice =
                 (from entry in tmpPharmaciesWithMinProductPrice
                 join pharmacy in _fixture.PharmacyList on entry.PharmacyNumber equals pharmacy.PharmacyNumber
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