using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

public class PharmacyService(PharmacyRepository repository, IMapper mapper) : IService<Pharmacy, PharmacyDto>
{
    /// <summary>
    /// Метод возвращает все объекты класса аптека из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса аптека</returns>
    public IEnumerable<Pharmacy> GetAll()
    {
        return mapper.Map<IEnumerable<Pharmacy>>(repository.GetAll());
    }

    /// <summary>
    /// Метод возвращает объект класса аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <returns>Объект класса аптека</returns>
    public PharmacyDto GetById(int id)
    {
        return mapper.Map<PharmacyDto>(repository.GetById(id));
    }

    /// <summary>
    /// Метод добавляет новый объект класса аптека в базу данных 
    /// </summary>
    /// <param name="pharmacyDto">Объект класса аптека</param>
    /// <return>Добавленный объект класса аптека</return>
    public Pharmacy Post(PharmacyDto pharmacyDto)
    {
        var entity = mapper.Map<Pharmacy>(pharmacyDto);
        entity.PharmacyId = repository.GetFreeId();
        repository.Post(entity);
        return entity;
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса аптека в базе данных
    /// </summary>
    /// <param name="id">Идентификатор аптеки</param>
    /// <param name="pharmacyDto">Объект класса аптека</param>
    /// <returns>Изменённый объект класса аптека или null при отсутствии объекта в базе данных</returns>
    public Pharmacy? Put(int id, PharmacyDto pharmacyDto)
    {
        var entity = mapper.Map<Pharmacy>(pharmacyDto);
        entity.PharmacyId = id;
        if (repository.Put(entity))
            return entity;
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
    /// Метод возвращает коллекцию объектов с информацией о характеристиках препаратов для аптеке с названием pharmacyName, упорядоченный по названию препарата
    /// </summary>
    /// <param name="pharmacyName">Название аптеки</param>
    /// <returns>Коллекция объектов с информацией о характеристиках препаратов для аптеки с именем pharmacyName, упорядоченный по названию препарата</returns>
    public IEnumerable<ProductForPharmacyDto> GetProductsForPharmacy(string pharmacyName)
    {
        var products = repository.GetProductsForPharmacies(pharmacyName);
        return from product in products
                select new ProductForPharmacyDto
                {
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