namespace CityPharmacyChain.Api.DAO;

public interface IDao<T>
{
    public List<T> Values { get; set; }

    public T GetById(int id);

    public void Create(T obj);

    public void Update(T obj);

    public void Delete(int id);
}
