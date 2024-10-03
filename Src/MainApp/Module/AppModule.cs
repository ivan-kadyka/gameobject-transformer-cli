using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serialization;
using Serialization.Json;
using Serialization.Json.Convertors;
using Storage;
using Storage.FileSystem;
using Transformer;
using Transformer.Generator;

namespace MainApp.Module;

public static class AppModule
{
    public static IServiceCollection AddAppModule(this IServiceCollection services)
    {
        services.AddTransient<IDtoFormatter>(_ =>
        {
            var jsonConvertors = new JsonConverter[]
            {
                new Vector3Converter(),
                new QuaternionConverter(),
            };
            
            return new JsonDtoFormatter(jsonConvertors);
        });

        services.AddTransient<IStorage, FileSystemStorage>();
        services.AddSingleton<IGameObjectService, GameObjectService>();
        
        services.AddSingleton<IGameObjectFactory, GameObjectFactory>();
        // possible use UnityGameObjectFactory instead of GameObjectFactory for Unity Editor
        // services.AddSingleton<IGameObjectFactory, UnityGameObjectFactory>();
        
        return services;
    }
}