namespace CityPharmacyChain.Domain.Repository;

public interface IRepository<T>
{
    public IEnumerable<T> GetAll();

    public T? GetById(int id);

    public void Post(T entity);

    public bool Put(T entity);

    public bool Delete(int id);

    public int GetFreeId();
}
