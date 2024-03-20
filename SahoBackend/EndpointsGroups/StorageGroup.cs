using SahoBackend.Endpoints;

namespace SahoBackend.EndpointsGroups;

public static class StorageGroup
{
    public static void AddEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/storage");

        group.MapGet("/users/{id}/avatar", StorageEndpoints.GetUserProfilePicture);
    }
    
}