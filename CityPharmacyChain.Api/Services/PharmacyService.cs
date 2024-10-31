using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

/// <summary>
/// Сервис для работы с сущностями класса аптека
/// </summary>
/// <param name="repository">Репозиторий для работы с сущностями класса аптека</param>
/// <param name="mapper">Средство для составления отображения между сущностями класса DTO и Entity</param>
public class PharmacyService(PharmacyRepository repository, IMapper mapper) : IService<PharmacyFullDto, PharmacyDto>
{
    /// <summary>
    /// Метод возвращает все объекты класса аптека из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса аптека</returns>
    public IEnumerable<PharmacyFullDto> GetAll()
    {
        return mapper.Map<IEnumerable<PharmacyFullDto>>(repository.GetAll());
    }

    /// <summary>
    /// Метод возвращает объект класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <returns>Объект класса аптека</returns>
    public PharmacyDto? GetById(int id)
    {
        return mapper.Map<PharmacyDto>(repository.GetById(id));
    }

    /// <summary>
    /// Метод добавляет новый объект класса аптека в базу данных 
    /// </summary>
    /// <param name="pharmacyDto">Объект класса аптека</param>
    /// <return>Добавленный объект класса аптека</return>
    public PharmacyFullDto? Post(PharmacyDto pharmacyDto)
    {
        var entity = mapper.Map<Pharmacy>(pharmacyDto);
        entity.PharmacyId = repository.GetFreeId();
        if (!repository.Post(entity))
            return null;
        return mapper.Map<PharmacyFullDto>(entity);
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса аптека в базе данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <param name="pharmacyDto">Объект класса аптека</param>
    /// <returns>Изменённый объект класса аптека или null при отсутствии объекта в базе данных</returns>
    public PharmacyFullDto? Put(int id, PharmacyDto pharmacyDto)
    {
        var entity = mapper.Map<Pharmacy>(pharmacyDto);
        entity.PharmacyId = id;
        if (repository.Put(entity))
            return mapper.Map<PharmacyFullDto>(entity); ;
        return null;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Метод возвращает коллекцию объектов с информацией о характеристиках препаратов в аптеке с названием pharmacyName, упорядоченной по названию препарата
    /// </summary>
    /// <param name="pharmacyName">Название аптеки</param>
    /// <returns>Коллекция объектов с информацией о характеристиках препаратов в аптеке с названием pharmacyName, упорядоченной по названию препарата</returns>
    public IEnumerable<ProductForPharmacyDto> GetProductsForPharmacy(string pharmacyName)
    {
        var products = repository.GetProductsForPharmacies(pharmacyName);
        return from product in products
                select new ProductForPharmacyDto
                {
                    PharmacyName = pharmacyName,
                    ProductCode = product.Item1,
                    Name = product.Item2,
                    Count = product.Item3,
                    ProductGroup = product.Item4,
                    Price = product.Item5,
                };
    }

    /// <summary>
    /// Метод возвращает коллекцию с названиями аптек в районе district, продавших препарат с названием productName в большем объёме, чем объём volume
    /// </summary>
    /// <param name="district">Район аптеки</param>
    /// <param name="productName">Название препарата</param>
    /// <param name="volume">Объём продажи</param>
    /// <returns>Коллекция с названиями аптек в районе district, продавших препарат с названием productName в большем объёме, чем объём volume</returns>
    public IEnumerable<string> GetPharmaciesWithLargeProductSoldVolume(string district, string productName, int volume)
    {
        return repository.GetPharmaciesWithLargeProductSoldVolume(district, productName, volume);
    }

    /// <summary>
    /// Метод возвращает коллекцию с названиями аптек, в которых препарат с названием productName продаётся с минимальной ценой
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Коллекция с названиями аптек, в которых препарат с названием productName продаётся с минимальной ценой</returns>
    public IEnumerable<string> GetPharmaciesWithMinProductPrice(string productName)
    {
        return repository.GetPharmaciesWithMinProductPrice(productName);
    }
}