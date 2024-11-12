using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Application.Repository;

/// <summary>
/// Репозиторий для работы с сущностями класса препарат
/// </summary>
/// <param name="context">Контекст базы данных</param>
public class ProductRepository(CityPharmacyChainContext context) : IRepository<Product>
{
    /// <summary>
    /// Свободный идентификатор в базе данных для объектов класса препарат
    /// </summary>
    public int FreeId { get; private set; } = context.Products.Any() ? context.Products.Max(x => x.ProductId) + 1 : 1;

    /// <summary>
    /// Метод возвращает все объекты класса препарат из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса препарат</returns>
    public IEnumerable<Product> GetAll()
    {
        return [.. context.Products];
    }

    /// <summary>
    /// Метод возвращает объект класса препарат из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <returns>Объект класса аптека</returns>
    public Product? GetById(int id)
    {
        return context.Products.FirstOrDefault(x => x.ProductId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса препарат в базу данных 
    /// </summary>
    /// <param name="product">Объект класса препарат</param>
    /// <returns>Успешность операции добавления</returns>
    public bool Post(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса препарат в базе данных
    /// </summary>
    /// <param name="product">Объект класса препарат</param>
    /// <returns>Успешность операции модификации</returns>
    public bool Put(Product product)
    {
        var value = GetById(product.ProductId);
        if (value is null)
            return false;
        context.Entry(value).CurrentValues.SetValues(product);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса препарат из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        context.Products.Remove(value);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод возвращает свободный идентификатор в базе данных для объектов класса препарат
    /// </summary>
    /// <returns>Свободный идентификатор</returns>
    public int GetFreeId()
    {
        return FreeId++;
    }

    /// <summary>
    /// Метод возвращает список всех аптек, у которых есть в наличии препарат с названием productName, с указанием количества данного препарата в них
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Список всех аптек, у которых есть в наличии препарат с названием productName, с указанием количества данного препарата в них</returns>
    public List<Tuple<string?, int?>> GetProductCountForEachPharmacy(string productName)
    {
        return [.. (from pharmacy in context.Pharmacies
               join pharmacyProduct in context.PharmacyProducts on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
               join product in context.Products on pharmacyProduct.ProductId equals product.ProductId
               orderby product.Name
               where product.Name == productName
               select new Tuple<string?, int?>
               (
                   pharmacy.Name,
                   pharmacyProduct.Count
               ))];
    }
}