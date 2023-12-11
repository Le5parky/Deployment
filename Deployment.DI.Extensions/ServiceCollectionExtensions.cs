using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Deployment.DependencyInjection.Extensions;


public static class ServiceCollectionExtensions
{
    public static IServiceCollection ReUseSingleton<T, TBase>(this IServiceCollection services)
        where T : TBase
        where TBase : class
    {
        services.AddSingleton<TBase>(a => a.GetRequiredService<T>());
        return services;
    }

    public static IServiceCollection ReUseTransient<T, TBase>(this IServiceCollection services)
        where T : TBase
        where TBase : class
    {
        services.AddTransient<TBase>(a => a.GetRequiredService<T>());
        return services;
    }

    public static IServiceCollection ReUseScoped<T, TBase>(this IServiceCollection services)
        where T : TBase
        where TBase : class
    {
        services.AddScoped<TBase>(a => a.GetRequiredService<T>());
        return services;
    }

    public static IServiceCollection RegisterAsInterfaceImplementation<T>(this IServiceCollection services, ServiceLifetime lifeTime = ServiceLifetime.Transient)
        where T : class
    {
        var assemblies = Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => x is { IsAbstract: false, IsClass: true } && typeof(T).IsAssignableFrom(x));

        foreach (var type in assemblies)
            services.Add(new ServiceDescriptor(typeof(T), type, lifeTime));

        return services;
    }

    public static IServiceCollection RegisterAssemblies<T, TBase>(this IServiceCollection service, ServiceLifetime lifeTime = ServiceLifetime.Transient)
        where T : class
        where TBase : class
    {
        var assemblies = typeof(TBase).Assembly.DefinedTypes.Where(t =>
            !t.IsAbstract && !t.IsGenericTypeDefinition &&
            typeof(T).IsAssignableFrom(t));

        foreach (var type in assemblies)
        {
            service.Add(new ServiceDescriptor(typeof(T), type, lifeTime));
        }
        return service;
    }
}
