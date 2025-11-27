using DrawGheterInfrastructure.Repositories.Intefaces;

namespace DrawGheterInfrastructure.Repositories;

public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : class
{
    public T Create(T entity)
    {
        context.Set<T>().Add(entity);
        context.SaveChanges();
        return entity;
    }

    public T Update(T entity)
    {
        context.Set<T>().Attach(entity);
        context.Set<T>().Update(entity);
        context.SaveChanges();
        return entity;
    }

    public void Delete(int id)
    {
        var entity = Show(id);
        
        if (entity == null)
        {
            return;
        }
        
        context.Set<T>().Remove(entity);
        context.SaveChanges();
    }

    public T? Show(int id)
    {
        return context.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public IEnumerable<T> CreateAll(IEnumerable<T> entities)
    {
        var listEntities = entities.ToList();

        foreach (var entity in listEntities)
        {
            context.Set<T>().Add(entity);
        }

        context.SaveChanges();
        return listEntities;
    }

    public IEnumerable<T> UpdateAll(IEnumerable<T> entities)
    {
        var listEntities = entities.ToList();

        foreach (var entity in listEntities)
        {
            context.Set<T>().Attach(entity);
            context.Set<T>().Update(entity);
        }

        context.SaveChanges();
        return listEntities;
    }

    public void DeleteAll(IEnumerable<int> ids)
    {
        var listEntities = ids.ToList();
        foreach (var entityOrNull in listEntities.Select(Show).OfType<T>())
        {
            context.Set<T>().Remove(entityOrNull);
        }
    }
}