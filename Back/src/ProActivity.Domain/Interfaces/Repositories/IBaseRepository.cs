namespace ProActivity.Domain.Interfaces.Repositories;

public interface IBaseRepository
{
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();
}