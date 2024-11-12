using AutoMapper;
using CityPharmacyChain.Api.Host.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Application.Repository;

namespace CityPharmacyChain.Api.Host.Services;

/// <summary>
/// Сервис для работы с сущностями класса запись в прайс-листе
/// </summary>
/// <param name="repository">Репозиторий для работы с сущностями класса запись в прайс-листе</param>
/// <param name="mapper">Средство для составления отображения между сущностями класса DTO и Entity</param>
public class PriceListEntryService(PriceListEntryRepository repository, IMapper mapper) : IService<PriceListEntryFullDto, PriceListEntryDto>
{
    /// <summary>
    /// Метод возвращает все объекты класса запись в прайс-листе из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса запись в прайс-листе</returns>
    public IEnumerable<PriceListEntryFullDto> GetAll()
    {
        return mapper.Map<IEnumerable<PriceListEntryFullDto>>(repository.GetAll());
    }

    /// <summary>
    /// Метод возвращает объект класса запись в прайс-листе из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи в прайс-листе</param>
    /// <returns>Объект класса запись в прайс-листе</returns>
    public PriceListEntryDto? GetById(int id)
    {
        return mapper.Map<PriceListEntryDto>(repository.GetById(id));
    }

    /// <summary>
    /// Метод добавляет новый объект класса запись в прайс-листе в базу данных 
    /// </summary>
    /// <param name="priceListEntryDto">Объект класса запись в прайс-листе</param>
    /// <return>Добавленный объект класса запись в прайс-листе</return>
    public PriceListEntryFullDto? Post(PriceListEntryDto priceListEntryDto)
    {
        var entity = mapper.Map<PriceListEntry>(priceListEntryDto);
        entity.PriceListEntryId = repository.GetFreeId();
        if (!repository.Post(entity))
            return null;
        return mapper.Map<PriceListEntryFullDto>(entity);
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса запись в прайс-листе в базе данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи в прайс-листе</param>
    /// <param name="priceListEntryDto">Объект класса запись в прайс-листе</param>
    /// <returns>Изменённый объект класса запись в прайс-листе или null при отсутствии объекта в базе данных</returns>
    public PriceListEntryFullDto? Put(int id, PriceListEntryDto priceListEntryDto)
    {
        var entity = mapper.Map<PriceListEntry>(priceListEntryDto);
        entity.PriceListEntryId = id;
        if (repository.Put(entity))
            return mapper.Map<PriceListEntryFullDto>(entity);
        return null;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса запись в прайс-листе из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи в прайс-листе</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }
}