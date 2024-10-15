using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

public class PriceListEntryService(IRepository<PriceListEntry> repository, IMapper mapper) : IService<PriceListEntry, PriceListEntryDto>
{
    public IEnumerable<PriceListEntry> GetAll()
    {
        return mapper.Map<IEnumerable<PriceListEntry>>(repository.GetAll());
    }

    public PriceListEntryDto GetById(int id)
    {
        return mapper.Map<PriceListEntryDto>(repository.GetById(id));
    }

    public PriceListEntry? Put(int id, PriceListEntryDto dto)
    {
        var entity = mapper.Map<PriceListEntry>(dto);
        entity.PriceListEntryId = id;
        if (repository.Put(entity))
            return entity;
        return null;
    }

    public PriceListEntry Post(PriceListEntryDto dto)
    {
        var entity = mapper.Map<PriceListEntry>(dto);
        entity.PriceListEntryId = repository.GetFreeId();
        repository.Post(entity);
        return entity;
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}