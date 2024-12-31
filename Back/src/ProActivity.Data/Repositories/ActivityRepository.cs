using Microsoft.EntityFrameworkCore;
using ProActivity.Data.Context;
using ProActivity.Domain.Entities;
using ProActivity.Domain.Interfaces.Repositories;

namespace ProActivity.Data.Repositories;

public class ActivityRepository(DataContext context) : BaseRepository(context), IActivityRepository
{
    private readonly DataContext _context = context;

    public async Task<List<Activity>> GetAllAsync()
    {
        return await _context.Activities.AsNoTracking().OrderBy(activity => activity.Id).ToListAsync();
    }
    
    public async Task<Activity?> GetByTitleAsync(string title)
    {
        return await _context.Activities.AsNoTracking().FirstOrDefaultAsync(activity => activity != null && activity.Title == title);
    }        

    public async Task<Activity> GetByIdAsync(int id)
    {
        return await _context.Activities.AsNoTracking().FirstOrDefaultAsync(activity => activity != null && activity.Id == id);
    }
}