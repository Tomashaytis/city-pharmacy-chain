using AutoMapper;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Api.Dto;

namespace CityPharmacyChain.Api;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Pharmacy, PharmacyDto>().ReverseMap();
        CreateMap<PharmaceuticalGroup, PharmaceuticalGroupDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<PriceListEntry, PriceListEntryDto>().ReverseMap();
        CreateMap<PharmacyProduct, PharmacyProductDto>().ReverseMap();
    }
}
