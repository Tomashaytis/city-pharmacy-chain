using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;
namespace CityPharmacyChain.Api.Services;

public interface IService<T, D>
{
    public IEnumerable<T> GetAll();

    public D GetById(int id);

    public T? Put(int id, D dto);

    public T Post(D dto);

    public bool Delete(int id);
}
