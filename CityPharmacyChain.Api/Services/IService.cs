namespace CityPharmacyChain.Api.Host.Services;

/// <summary>
/// Интерфейс для сервисов
/// </summary>
/// <typeparam name="TEntity">Тип сущности класса Full DTO</typeparam>
/// <typeparam name="TDto">Тип сущности класса DTO</typeparam>
public interface IService<TEntity, TDto>
    where TEntity : class
    where TDto : class
{
    /// <summary>
    /// Метод возвращает все объекты класса T из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса T</returns>
    public IEnumerable<TEntity> GetAll();

    /// <summary>
    /// Метод возвращает объект класса T из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <returns>Объект класса T</returns>
    public TDto? GetById(int id);

    /// <summary>
    /// Метод добавляет новый объект класса T в базу данных 
    /// </summary>
    /// <param name="dto">Объект класса T</param>
    /// <return>Добавленный объект класса T</return>
    public TEntity? Post(TDto dto);

    /// <summary>
    /// Метод модифицирует существующий объект класса T в базе данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <param name="dto">Данные для объекта класса T</param>
    /// <returns>Изменённый объект класса T или null при отсутствии объекта в базе данных</returns>
    public TEntity? Put(int id, TDto dto);

    /// <summary>
    /// Метод удаляет существующий объект класса T из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id);
}
