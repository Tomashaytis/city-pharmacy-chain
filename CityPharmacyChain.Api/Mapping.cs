using AutoMapper;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Api.Dto;

namespace CityPharmacyChain.Api;

/// <summary>
/// Средство для составления отображения между сущностями класса DTO и Entity
/// </summary>
public class Mapping : Profile
{
    /// <summary>
    /// Конструктор, создающий отображения между сущностями класса DTO и Entity
    /// </summary>
    public Mapping()
    {
        CreateMap<Pharmacy, PharmacyDto>().ReverseMap();
        CreateMap<PharmaceuticalGroup, PharmaceuticalGroupDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<PriceListEntry, PriceListEntryDto>().ReverseMap();
        CreateMap<PharmacyProduct, PharmacyProductDto>().ReverseMap();
    }
}
