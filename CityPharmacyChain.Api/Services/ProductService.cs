using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;
using System.Collections;

namespace CityPharmacyChain.Api.Services;

public class ProductService(ProductRepository repository, IMapper mapper) : IService<Product, ProductDto>
{
    public IEnumerable<Product> GetAll()
    {
        return mapper.Map<IEnumerable<Product>>(repository.GetAll());
    }

    public ProductDto GetById(int id)
    {
        return mapper.Map<ProductDto>(repository.GetById(id));
    }

    public Product? Put(int id, ProductDto dto)
    {
        var entity = mapper.Map<Product>(dto);
        entity.ProductId = id;
        if (repository.Put(entity))
            return entity;
        return null;
    }

    public Product Post(ProductDto dto)
    {
        var entity = mapper.Map<Product>(dto);
        entity.ProductId = repository.GetFreeId();
        repository.Post(entity);
        return entity;
    }

    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    public IEnumerable<ProductCountDto> GetProductCountForEachPharmacy(string productName)
    {
        return from productCount in repository.GetProductCountForEachPharmacy(productName)
               select new ProductCountDto
               {
                   ProductName = productCount.Item1,
                   Count = productCount.Item2,
               };
    }
}