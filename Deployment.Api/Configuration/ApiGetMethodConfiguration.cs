using Microsoft.AspNetCore.SignalR.Protocol;

namespace Deployment.Api;

public static class ApiGetMethodConfiguration
{
    public static void ConfigureGetMethod(this WebApplication app)
    {
        app.MapGet("/targetversions", (ITargetVersionContorller tvController) =>
            {
                var tv = tvController.GetTargetVersions();      
                return tv;
            });
    }
}
