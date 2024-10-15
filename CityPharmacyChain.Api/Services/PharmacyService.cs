using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

public class PharmacyService(IRepository<Pharmacy> repository, IMapper mapper) : IService<Pharmacy, PharmacyDto>
{
    public IEnumerable<Pharmacy> GetAll()
    {
        return mapper.Map<IEnumerable<Pharmacy>>(repository.GetAll());
    }

    public PharmacyDto GetById(int id)
    {
        return mapper.Map<PharmacyDto>(repository.GetById(id));
    }

    public Pharmacy? Put(int id, PharmacyDto dto)
    {
        var entity = mapper.Map<Pharmacy>(dto);
        entity.PharmacyId = id;
        if (repository.Put(entity))
            return entity;
        return null;
    }

    public Pharmacy Post(PharmacyDto dto)
    {
        var entity = mapper.Map<Pharmacy>(dto);
        entity.PharmacyId = repository.GetFreeId();
        repository.Post(entity);
        return entity;
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}