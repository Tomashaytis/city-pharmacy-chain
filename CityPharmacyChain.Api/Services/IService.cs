namespace CityPharmacyChain.Api.Services;

/// <summary>
/// Интерфейс для сервисов
/// </summary>
/// <typeparam name="T">Тип сущности класса Full DTO</typeparam>
/// <typeparam name="D">Тип сущности класса DTO</typeparam>
public interface IService<T, D>
{
    /// <summary>
    /// Метод возвращает все объекты класса T из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса T</returns>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Метод возвращает объект класса T из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <returns>Объект класса T</returns>
    public D? GetById(int id);

    /// <summary>
    /// Метод добавляет новый объект класса T в базу данных 
    /// </summary>
    /// <param name="dto">Объект класса T</param>
    /// <return>Добавленный объект класса T</return>
    public T? Post(D dto);

    /// <summary>
    /// Метод модифицирует существующий объект класса T в базе данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <param name="dto">Данные для объекта класса T</param>
    /// <returns>Изменённый объект класса T или null при отсутствии объекта в базе данных</returns>
    public T? Put(int id, D dto);

    /// <summary>
    /// Метод удаляет существующий объект класса T из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id);
}
