using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

public class PharmaceuticalGroupService(IRepository<PharmaceuticalGroup> repository, IMapper mapper) : IService<PharmaceuticalGroup, PharmaceuticalGroupDto>
{
    public IEnumerable<PharmaceuticalGroup> GetAll()
    {
        return mapper.Map<IEnumerable<PharmaceuticalGroup>>(repository.GetAll());
    }

    public PharmaceuticalGroupDto GetById(int id)
    {
        return mapper.Map<PharmaceuticalGroupDto>(repository.GetById(id));
    }

    public PharmaceuticalGroup? Put(int id, PharmaceuticalGroupDto dto)
    {
        var entity = mapper.Map<PharmaceuticalGroup>(dto);
        entity.PharmaceuticalGroupId = id;
        if (repository.Put(entity))
            return entity;
        return null;
    }

    public PharmaceuticalGroup Post(PharmaceuticalGroupDto dto)
    {
        var entity = mapper.Map<PharmaceuticalGroup>(dto);
        entity.PharmaceuticalGroupId = repository.GetFreeId();
        repository.Post(entity);
        return entity;
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}