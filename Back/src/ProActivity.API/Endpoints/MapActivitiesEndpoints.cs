using ProActivity.Domain.Entities;
using ProActivity.Domain.Interfaces.Services;

namespace ProActivity.API.Endpoints;

public static class ActivitiesEndpoints
{
    public static WebApplication MapActivitiesEndpoints(this WebApplication app)
    {
        var activitiesApi = app.MapGroup(prefix: "/activities");
        activitiesApi.MapGet("/", async (IActivityService service) => await service.GetAllAsync());
        activitiesApi.MapGet("/{id:int}", async (int id, IActivityService service) => await service.GetByIdAsync(id));
        activitiesApi.MapGet("/title/{title}", async (string title, IActivityService service) => await service.GetByTitleAsync(title));
        activitiesApi.MapPost("/", async (Activity activity, IActivityService service) => await service.AddAsync(activity));
        activitiesApi.MapPut("/", async (Activity activity, IActivityService service) => await service.UpdateAsync(activity));
        activitiesApi.MapDelete("/{id:int}", async (int id, IActivityService service) => await service.DeleteAsync(id));
        activitiesApi.MapPut("/complete/{id:int}", async (int id, IActivityService service) => await service.CompleteAsync(id));

        return app;
    }
}