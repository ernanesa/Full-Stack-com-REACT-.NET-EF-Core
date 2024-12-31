using ProActivity.Data.Context;
using ProActivity.Domain.Interfaces.Repositories;

namespace ProActivity.Data.Repositories;

public class BaseRepository(DataContext context) : IBaseRepository
{
    public void Add<T>(T entity) where T : class
    {
        context.Set<T>().Add(entity);
    }
    
    public void Update<T>(T entity) where T : class
    {
        context.Set<T>().Update(entity);
    }
    
    public void Delete<T>(T entity) where T : class
    {
        context.Set<T>().Remove(entity);
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}