using AutoMapper;
using CityPharmacyChain.Api.Host.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Application.Repository;

namespace CityPharmacyChain.Api.Host.Services;

/// <summary>
/// Сервис для работы с сущностями класса фармацевтическая группа
/// </summary>
/// <param name="repository">Репозиторий для работы с сущностями класса фармацевтическая группа</param>
/// <param name="mapper">Средство для составления отображения между сущностями класса DTO и Entity</param>
public class PharmaceuticalGroupService(PharmaceuticalGroupRepository repository, IMapper mapper) : IService<PharmaceuticalGroupFullDto, PharmaceuticalGroupDto>
{
    /// <summary>
    /// Метод возвращает все объекты класса фармацевтическая группа из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса фармацевтическая группа</returns>
    public IEnumerable<PharmaceuticalGroupFullDto> GetAll()
    {
        return mapper.Map<IEnumerable<PharmaceuticalGroupFullDto>>(repository.GetAll());
    }

    /// <summary>
    /// Метод возвращает объект класса фармацевтическая группа из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <returns>Объект класса фармацевтическая группа</returns>
    public PharmaceuticalGroupDto? GetById(int id)
    {
        return mapper.Map<PharmaceuticalGroupDto>(repository.GetById(id));
    }

    /// <summary>
    /// Метод добавляет новый объект класса фармацевтическая группа в базу данных 
    /// </summary>
    /// <param name="pharmaceuticalGroupDto">Объект класса фармацевтическая группа</param>
    /// <return>Добавленный объект класса фармацевтическая группа</return>
    public PharmaceuticalGroupFullDto? Post(PharmaceuticalGroupDto pharmaceuticalGroupDto)
    {
        var entity = mapper.Map<PharmaceuticalGroup>(pharmaceuticalGroupDto);
        entity.PharmaceuticalGroupId = repository.GetFreeId();
        if (!repository.Post(entity))
            return null;
        return mapper.Map<PharmaceuticalGroupFullDto>(entity);
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса фармацевтическая группа в базе данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <param name="pharmaceuticalGroupDto">Данные для объекта класса фармацевтическая группа</param>
    /// <returns>Изменённый объект класса фармацевтическая группа или null при отсутствии объекта в базе данных</returns>
    public PharmaceuticalGroupFullDto? Put(int id, PharmaceuticalGroupDto pharmaceuticalGroupDto)
    {
        var entity = mapper.Map<PharmaceuticalGroup>(pharmaceuticalGroupDto);
        entity.PharmaceuticalGroupId = id;
        if (repository.Put(entity))
            return mapper.Map<PharmaceuticalGroupFullDto>(entity);
        return null;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса фармацевтическая группа из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Метод возвращает коллекцию объектов с информацией о средней стоимости препаратов в каждой фармацевтической группе для каждой аптеки
    /// </summary>
    /// <returns>Коллекция объектов с информацией о средней стоимости препаратов в каждой фармацевтической группе для каждой аптеки</returns>
    public IEnumerable<PharmaceuticalGroupPriceDto> GetPharmaceuticalGroupPriceForEachPharmacy()
    {
        return from data in repository.GetPharmaceuticalGroupPriceForEachPharmacy()
               select new PharmaceuticalGroupPriceDto
               {
                   PharmacyName = data.Item1,
                   PharmaceuticalGroupName = data.Item2,
                   Price = data.Item3,
               };
    }
}