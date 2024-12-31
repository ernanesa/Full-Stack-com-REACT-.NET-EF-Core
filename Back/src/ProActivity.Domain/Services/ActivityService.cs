using ProActivity.Domain.Entities;
using ProActivity.Domain.Interfaces.Repositories;
using ProActivity.Domain.Interfaces.Services;

namespace ProActivity.Domain.Services;

public class ActivityService(IActivityRepository activityRepository) : IActivityService
{
    public async Task<Activity> AddAsync(Activity activity)
    {
        if(await activityRepository.GetByTitleAsync(activity.Title) is not null)
            throw new Exception("Activity already exists");
        
        activityRepository.Add(activity);
        if(await activityRepository.SaveChangesAsync())
            return activity;
        
        throw new Exception("Activity could not be added");
    }

    public async Task<Activity> UpdateAsync(Activity activity)
    {
        var activityToUpdate = await activityRepository.GetByIdAsync(activity.Id);
        if(activityToUpdate is null)
            throw new Exception("Activity not found");
        
        if(activityToUpdate.CompletionDate != null)
            throw new Exception("Activity already completed");
        
        activityRepository.Update(activity);
        if(await activityRepository.SaveChangesAsync())
            return activity;
        
        throw new Exception("Activity could not be updated");
    }

    public async Task<bool> DeleteAsync(int activityId)
    {
        var activityToDelete = await activityRepository.GetByIdAsync(activityId);
        if(activityToDelete is null)
            throw new Exception("Activity not found");
        
        activityRepository.Delete(activityToDelete);
        return await activityRepository.SaveChangesAsync();
    }

    public async Task<List<Activity>> GetAllAsync()
    {
        try
        {
           return await activityRepository.GetAllAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Activity?> GetByIdAsync(int id)
    {
        try
        {
            return await activityRepository.GetByIdAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Activity?> GetByTitleAsync(string title)
    {
        try
        {
            return await activityRepository.GetByTitleAsync(title);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> CompleteAsync(int activityId)
    {
        var activity = await activityRepository.GetByIdAsync(activityId);
        if(activity is null)
            throw new Exception("Activity not found");
        
        activity.Complete();
        activityRepository.Update(activity);
        return await activityRepository.SaveChangesAsync();
    }
}
    