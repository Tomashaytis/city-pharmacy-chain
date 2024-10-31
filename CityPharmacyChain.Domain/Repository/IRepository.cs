namespace CityPharmacyChain.Domain.Repository;

/// <summary>
/// Интерфейс для репозиториев
/// </summary>
/// <typeparam name="T">Тип сущности класса Entity</typeparam>
public interface IRepository<T>
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
    public T? GetById(int id);

    /// <summary>
    /// Метод добавляет новый объект класса T в базу данных 
    /// </summary>
    /// <param name="entity">Объект класса T</param>
    /// <returns>Успешность операции добавления</returns>
    public bool Post(T entity);

    /// <summary>
    /// Метод модифицирует существующий объект класса T в базе данных
    /// </summary>
    /// <param name="entity">Объект класса T</param>
    /// <returns>Успешность операции модификации</returns>
    public bool Put(T entity);

    /// <summary>
    /// Метод удаляет существующий объект класса T из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id);

    /// <summary>
    /// Метод возвращает минимальный незанятый идентификатор в базе данных для объектов класса T
    /// </summary>
    /// <returns>Минимальный незанятый идентификатор</returns>
    public int GetFreeId();
}
