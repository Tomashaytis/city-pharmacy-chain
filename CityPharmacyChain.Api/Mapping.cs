using AutoMapper;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Api.Dto;

namespace CityPharmacyChain.Api;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Pharmacy, PharmacyDtoGet>().ReverseMap();
        CreateMap<PharmaceuticalGroup, PharmaceuticalGroupDtoGet>().ReverseMap();
        CreateMap<Product, ProductDtoGet>().ReverseMap();
        CreateMap<PriceListEntry, PriceListEntryDtoGet>().ReverseMap();
        CreateMap<PharmacyProduct, PharmacyProductDtoGet>().ReverseMap();
    }
}
