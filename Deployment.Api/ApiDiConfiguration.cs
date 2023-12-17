namespace Deployment.Api;

public static class ApiDiConfiguration
{ 
    public static void DiApiConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<ITargetVersionContorller, TargetVersionContorller>();
    }
}
