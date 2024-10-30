using CityPharmacyChain.Domain.Entity;

namespace CityPharmacyChain.Domain.Repository;

/// <summary>
/// Репозиторий для работы с сущностями класса фармацевтическая группа
/// </summary>
/// <param name="context">Контекст базы данных</param>
public class PharmaceuticalGroupRepository(CityPharmacyChainContext context) : IRepository<PharmaceuticalGroup>
{
    /// <summary>
    /// Метод возвращает все объекты класса фармацевтическая группа из базы данных в виде коллекции
    /// </summary>
    /// <returns>Коллекция объектов класса фармацевтическая группа</returns>
    public IEnumerable<PharmaceuticalGroup> GetAll()
    {
        return [.. context.PharmaceuticalGroups];
    }

    /// <summary>
    /// Метод возвращает объект класса фармацевтическая группа из базы данных по его идентификатору
    /// </summary>
    /// <param name="id">Идентификатор фармацевтической группы</param>
    /// <returns>Объект класса фармацевтическая группа</returns>
    public PharmaceuticalGroup? GetById(int id)
    {
        return context.PharmaceuticalGroups.FirstOrDefault(x => x.PharmaceuticalGroupId == id);
    }

    /// <summary>
    /// Метод добавляет новый объект класса фармацевтическая группа в базу данных 
    /// </summary>
    /// <param name="pharmaceuticalGroup">Объект класса фармацевтическая группа</param>
    public void Post(PharmaceuticalGroup pharmaceuticalGroup)
    {
        context.PharmaceuticalGroups.Add(pharmaceuticalGroup);
        context.SaveChanges();
    }

    /// <summary>
    /// Метод модифицирует существующий объект класса фармацевтическая группа в базе данных
    /// </summary>
    /// <param name="pharmaceuticalGroup">Объект класса фармацевтическая группа</param>
    /// <returns>Успешность операции модификации</returns>
    public bool Put(PharmaceuticalGroup pharmaceuticalGroup)
    {
        var value = GetById(pharmaceuticalGroup.PharmaceuticalGroupId);
        if (value is null)
            return false;
        context.Entry(value).CurrentValues.SetValues(pharmaceuticalGroup);
        context.SaveChanges();
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
        context.PharmaceuticalGroups.Remove(value);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Метод возвращает минимальный незанятый идентификатор в базе данных для объектов класса фармацевтическая группа
    /// </summary>
    /// <returns>Минимальный незанятый идентификатор</returns>
    public int GetFreeId()
    {
        var ids = new HashSet<int>();
        foreach(var value in context.PharmaceuticalGroups.ToList())
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
    public List<Tuple<string?, string?, decimal?>> GetPharmaceuticalGroupPriceForEachPharmacy()
    {
        var result = new List<Tuple<string?, string?, decimal?>>();
        foreach (var item in context.Pharmacies)
        {
            var pharmaceuticalGroupPriceForPharmacy =
                    (from pharmaceuticalGroup in context.PharmaceuticalGroups
                     join product in context.Products on pharmaceuticalGroup.ProductId equals product.ProductId
                     join pharmacyProduct in context.PharmacyProducts on product.ProductId equals pharmacyProduct.ProductId
                     join pharmacy in context.Pharmacies on pharmacyProduct.PharmacyId equals pharmacy.PharmacyId
                     join priceListEntry in context.Prices on product.ProductId equals priceListEntry.ProductId
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
                 select new Tuple<string?, string?, decimal?>
                 (
                     item.Name,
                     groups.Key,
                     groups.Average(p => p.Price ?? 0)
                 )).ToList();
            result = [.. result, .. avgPharmaceuticalGroupPriceForPharmacy];
        }
        return result;
    }
}
