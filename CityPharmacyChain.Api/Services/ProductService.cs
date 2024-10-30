using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

/// <summary>
/// Сервис для работы с сущностями класса препарат
/// </summary>
/// <param name="repository">Репозиторий для работы с сущностями класса препарат</param>
/// <param name="mapper">Средство для составления отображения между сущностями класса DTO и Entity</param>
public class ProductService(ProductRepository repository, IMapper mapper) : IService<ProductFullDto, ProductDto>
{
    /// <summary>
    /// Метод возвращает все объекты класса препарат из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса препарат</returns>
    public IEnumerable<ProductFullDto> GetAll()
    {
        return mapper.Map<IEnumerable<ProductFullDto>>(repository.GetAll());
    }

    /// <summary>
    /// Метод возвращает объект класса препарат из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <returns>Объект класса препарат</returns>
    public ProductDto? GetById(int id)
    {
        return mapper.Map<ProductDto>(repository.GetById(id));
    }

    /// <summary>
    /// Метод добавляет новый объект класса препарат в базу данных 
    /// </summary>
    /// <param name="productDto">Объект класса препарат</param>
    /// <return>Добавленный объект класса препарат</return>
    public ProductFullDto Post(ProductDto productDto)
    {
        var entity = mapper.Map<Product>(productDto);
        entity.ProductId = repository.GetFreeId();
        repository.Post(entity);
        return mapper.Map<ProductFullDto>(productDto);
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса препарат в базе данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <param name="productDto">Объект класса препарат</param>
    /// <returns>Изменённый объект класса препарат или null при отсутствии объекта в базе данных</returns>
    public ProductFullDto? Put(int id, ProductDto productDto)
    {
        var entity = mapper.Map<Product>(productDto);
        entity.ProductId = id;
        if (repository.Put(entity))
            return mapper.Map<ProductFullDto>(productDto);
        return null;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса препарат из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Метод возвращает коллекцию объектов с информацией о всех аптеках, у которых есть в наличии препарат с названием productName, с указанием количества данного препарата в них
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Коллекция объектов с информацией о всех аптеках, у которых есть в наличии препарат с названием productName, с указанием количества данного препарата в них</returns>
    public IEnumerable<ProductCountDto> GetProductCountForEachPharmacy(string productName)
    {
        return from productCount in repository.GetProductCountForEachPharmacy(productName)
               select new ProductCountDto
               {
                   ProductName = productName,
                   PharmacyName = productCount.Item1,
                   Count = productCount.Item2,
               };
    }
}