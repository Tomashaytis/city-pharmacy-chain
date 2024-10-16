using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

public class PharmacyProductService(PharmacyProductRepository repository, IMapper mapper) : IService<PharmacyProduct, PharmacyProductDto>
{
    public IEnumerable<PharmacyProduct> GetAll()
    {
        return mapper.Map<IEnumerable<PharmacyProduct>>(repository.GetAll());
    }

    public PharmacyProductDto GetById(int id)
    {
        return mapper.Map<PharmacyProductDto>(repository.GetById(id));
    }

    public PharmacyProduct? Put(int id, PharmacyProductDto dto)
    {
        var entity = mapper.Map<PharmacyProduct>(dto);
        entity.PharmacyProductId = id;
        if (repository.Put(entity))
            return entity;
        return null;
    }

    public PharmacyProduct Post(PharmacyProductDto dto)
    {
        var entity = mapper.Map<PharmacyProduct>(dto);
        entity.PharmacyProductId = repository.GetFreeId();
        repository.Post(entity);
        return entity;
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    public IEnumerable<ProductSoldVolumeDto> GetTopFivePharmaciesBySoldVolume(string productName, DateTime start, DateTime end)
    {
        return from data in repository.GetTopFivePharmaciesBySoldVolume(productName, start, end)
               select new ProductSoldVolumeDto
               {
                   PharmacyName = data.Item1,
                   SoldCount = data.Item2,
                   SoldVolume = data.Item3,
               };
    }
}