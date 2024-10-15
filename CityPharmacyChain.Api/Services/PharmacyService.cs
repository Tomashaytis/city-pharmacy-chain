using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

public class PharmacyService(IRepository<Pharmacy> repository, IMapper mapper)
{
    public void Post(Pharmacy entity)
    {
        repository.Post(entity);
    }

    public void Delete(int id)
    {
        repository.Delete(id);
    }

    public IEnumerable<PharmacyDtoGet> GetAll()
    {
        return mapper.Map<IEnumerable<PharmacyDtoGet>>(repository.GetAll());
    }

    public PharmacyDtoGet GetById(int id)
    {
        return mapper.Map<PharmacyDtoGet>(repository.GetById(id));
    }

    public void Put(Pharmacy entity)
    {
        repository.Put(entity);
    }
}