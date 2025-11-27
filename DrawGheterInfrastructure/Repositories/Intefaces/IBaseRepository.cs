namespace DrawGheterInfrastructure.Repositories.Intefaces;

public interface IBaseRepository<T>
{
    public T Create(T entity);
    public T Update(T entity);
    public void Delete(int id);
    public T? Show(int id);
    public IEnumerable<T> GetAll();
    public IEnumerable<T> CreateAll(IEnumerable<T> entities);
    public IEnumerable<T> UpdateAll(IEnumerable<T> entities);
    public void DeleteAll(IEnumerable<int> ids);
}