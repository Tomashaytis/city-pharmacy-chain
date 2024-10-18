﻿using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

/// <summary>
/// Репозиторий для работы с сущностями класса препарат
/// </summary>
/// <param name="dataBase">Объект базы данных</param>
public class ProductRepository(DataBase dataBase) : IRepository<Product>
{
    /// <summary>
    /// Метод возвращает все объекты класса препарат из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса препарат</returns>
    public IEnumerable<Product> GetAll()
    {
        return dataBase.Products;
    }

    /// <summary>
    /// Метод возвращает объект класса препарат из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор препарата</param>
    /// <returns>Объект класса аптека</returns>
    public Product? GetById(int id)
    {
        return dataBase.Products.Find(x => x.ProductId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса препарат в базу данных 
    /// </summary>
    /// <param name="product">Объект класса препарат</param>
    public void Post(Product product)
    {
        dataBase.Products.Add(product);
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
        value.ProductGroup = product.ProductGroup;
        value.ProductCode = product.ProductCode;
        value.Name = product.Name;
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
        dataBase.Products.Remove(value);
        return true;
    }

    /// <summary>
    /// Метод возвращает минимальный незанятый идентификатор в базе данных для объектов класса препарат
    /// </summary>
    /// <returns>Минимальный незанятый идентификатор</returns>
    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach (var value in dataBase.Products)
        {
            ids.Add(value.ProductId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }

    /// <summary>
    /// Метод возвращает список всех аптек, у которых есть в наличии препарат с названием productName, с указанием количества данного препарата в них
    /// </summary>
    /// <param name="productName">Название препарата</param>
    /// <returns>Список всех аптек, у которых есть в наличии препарат с названием productName, с указанием количества данного препарата в них</returns>
    public List<Tuple<string?, int?>> GetProductCountForEachPharmacy(string productName)
    {
        return (from pharmacy in dataBase.Pharmacies
               join pharmacyProduct in dataBase.PharmacyProducts on pharmacy.PharmacyId equals pharmacyProduct.PharmacyId
               join product in dataBase.Products on pharmacyProduct.ProductId equals product.ProductId
               orderby product.Name
               where product.Name == productName
               select new Tuple<string?, int?>
               (
                   pharmacy.Name,
                   pharmacyProduct.Count
               )).ToList();
    }
}