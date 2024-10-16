using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

public class PharmaceuticalGroupRepository(DataBase dataBase) : IRepository<PharmaceuticalGroup>
{
    /// <summary>
    /// Метод возвращает все объекты класса фармацевтическая группа из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса фармацевтическая группа</returns>
    public IEnumerable<PharmaceuticalGroup> GetAll()
    {
        return dataBase.PharmaceuticalGroups;
    }

    /// <summary>
    /// Метод возвращает объект класса фармацевтическая группа из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <returns>Объект класса фармацевтическая группа</returns>
    public PharmaceuticalGroup? GetById(int id)
    {
        return dataBase.PharmaceuticalGroups.Find(x => x.PharmaceuticalGroupId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса фармацевтическая группа в базу данных 
    /// </summary>
    /// <param name="pharmaceuticalGroup">Объект класса фармацевтическая группа</param>
    public void Post(PharmaceuticalGroup pharmaceuticalGroup)
    {
        dataBase.PharmaceuticalGroups.Add(pharmaceuticalGroup);
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса фармацевтическая группа в базе данных
    /// </summary>
    /// <param name="pharmacy">Объект класса фармацевтическая группа</param>
    /// <returns>Успешность операции модификации</returns>
    public bool Put(PharmaceuticalGroup pharmaceuticalGroup)
    {
        var value = GetById(pharmaceuticalGroup.PharmaceuticalGroupId);
        if (value is null)
            return false;
        value.ProductId = pharmaceuticalGroup.ProductId;
        value.Name = pharmaceuticalGroup.Name;
        return true;
    }

    /// <summary>
    /// Метод удаляет существующий объект класса фармацевтическая группа из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <returns>Успешность операции удаления</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value is null)
            return false;
        dataBase.PharmaceuticalGroups.Remove(value);
        return true;
    }

    /// <summary>
    /// Метод возвращает минимальный незанятый идентификатор в базе данных для объектов класса фармацевтическая группа
    /// </summary>
    /// <returns>Минимальный незанятый идентификатор</returns>
    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach(var value in dataBase.PharmaceuticalGroups)
        {
            ids.Add(value.PharmaceuticalGroupId);
        }
        for (var i = 1; i < ids.Max(); i++)
        {
            if (!ids.Contains(i))
                return i;
        }
        return ids.Max() + 1;
    }

    /// <summary>
    /// Метод возвращает список с информацией о средней стоимости препаратов в каждой фармацевтической группе для каждой аптеки
    /// </summary>
    /// <returns>Список с информацией о средней стоимости препаратов в каждой фармацевтической группе для каждой аптеки</returns>
    public List<Tuple<string, string, double>> GetPharmaceuticalGroupPriceForEachPharmacy()
    {
        var result = new List<Tuple<string, string, double>>();
        foreach (var item in dataBase.Pharmacies)
        {
            var pharmaceuticalGroupPriceForPharmacy =
                    (from pharmaceuticalGroup in dataBase.PharmaceuticalGroups
                     join product in dataBase.Products on pharmaceuticalGroup.ProductId equals product.ProductId
                     join pharmacyProduct in dataBase.PharmacyProducts on product.ProductId equals pharmacyProduct.ProductId
                     join pharmacy in dataBase.Pharmacies on pharmacyProduct.PharmacyId equals pharmacy.PharmacyId
                     join priceListEntry in dataBase.Prices on product.ProductId equals priceListEntry.ProductId
                     select new
                     {
                         pharmaceuticalGroup.Name,
                         PharmacyName = pharmacy.Name,
                         pharmacyProduct.Price,
                     }).ToList();
            var avgPharmaceuticalGroupPriceForPharmacy =
                (from entry in pharmaceuticalGroupPriceForPharmacy
                 where entry.PharmacyName == item.Name
                 group entry by entry.Name into groups
                 select new Tuple<string, string, double>
                 (
                     item.Name,
                     groups.Key,
                     groups.Average(p => p.Price)
                 )).ToList();
            result = [.. result, .. avgPharmaceuticalGroupPriceForPharmacy];
        }
        return result;
    }
}
