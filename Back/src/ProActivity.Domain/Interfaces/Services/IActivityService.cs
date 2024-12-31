using ProActivity.Domain.Entities;

namespace ProActivity.Domain.Interfaces.Services;

public interface IActivityService
{
    Task<Activity> AddAsync(Activity activity);
    Task<Activity> UpdateAsync(Activity activity);
    Task<bool> DeleteAsync(int activityId);
    Task<List<Activity>> GetAllAsync();
    Task<Activity?> GetByIdAsync(int id);
    Task<Activity?> GetByTitleAsync(string title);
    Task<bool> CompleteAsync(int activityId);
}