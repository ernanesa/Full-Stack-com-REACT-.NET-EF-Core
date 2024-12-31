using ProActivity.Domain.Entities;

namespace ProActivity.Domain.Interfaces.Repositories;

public interface IActivityRepository : IBaseRepository
{
    Task<List<Activity>> GetAllAsync();
    Task<Activity> GetByIdAsync(int id);
    Task<Activity?> GetByTitleAsync(string title);
}
