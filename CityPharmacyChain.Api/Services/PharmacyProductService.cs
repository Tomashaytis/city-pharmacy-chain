﻿using AutoMapper;
using CityPharmacyChain.Api.Dto;
using CityPharmacyChain.Domain.Entity;
using CityPharmacyChain.Domain.Repository;

namespace CityPharmacyChain.Api.Services;

public class PharmacyProductService(PharmacyProductRepository repository, IMapper mapper) : IService<PharmacyProduct, PharmacyProductDto>
{
    /// <summary>
    /// Метод возвращает все объекты класса связь препарат-аптека из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса связь препарат-аптека</returns>
    public IEnumerable<PharmacyProduct> GetAll()
    {
        return mapper.Map<IEnumerable<PharmacyProduct>>(repository.GetAll());
    }

    /// <summary>
    /// Метод возвращает объект класса связь препарат-аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <returns>Объект класса связь препарат-аптека</returns>
    public PharmacyProductDto GetById(int id)
    {
        return mapper.Map<PharmacyProductDto>(repository.GetById(id));
    }

    /// <summary>
    /// Метод добавляет новый объект класса связь препарат-аптека в базу данных 
    /// </summary>
    /// <param name="pharmacyProductDto">Объект класса связь препарат-аптека</param>
    /// <return>Добавленный объект класса связь препарат-аптека</return>
    public PharmacyProduct Post(PharmacyProductDto pharmacyProductDto)
    {
        var entity = mapper.Map<PharmacyProduct>(pharmacyProductDto);
        entity.PharmacyProductId = repository.GetFreeId();
        repository.Post(entity);
        return entity;
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса связь препарат-аптека в базе данных
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <param name="pharmacyProductDto">Объект класса связь препарат-аптека</param>
    /// <returns>Изменённый объект класса связь препарат-аптека или null при отсутствии объекта в базе данных</returns>
    public PharmacyProduct? Put(int id, PharmacyProductDto pharmacyProductDto)
    {
        var entity = mapper.Map<PharmacyProduct>(pharmacyProductDto);
        entity.PharmacyProductId = id;
        if (repository.Put(entity))
            return entity;
        return null;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса связь препарат-аптека из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор связи препарат-аптека</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Метод возвращает коллекцию объектов с информацией о топ 5 аптеках по количеству и объёму продаж препарата с названием productName во временном интервале от start до end
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <param name="start">Начало временного интервала</param>
    /// <param name="end">Конец временного интервала</param>
    /// <returns>Коллекция объектов с информацией о топ 5 аптеках по количеству и объёму продаж препарата с названием productName во временном интервале от start до end</returns>
    public IEnumerable<ProductSoldVolumeDto> GetTopFivePharmaciesBySoldVolume(string productName, DateTime start, DateTime end)
    {
        return from data in repository.GetTopFivePharmaciesBySoldVolume(productName, start, end)
               select new ProductSoldVolumeDto
               {
                   PharmacyName = data.Item1,
                   SoldCount = data.Item2,
                   SoldVolume = data.Item3,
               };
    }
}