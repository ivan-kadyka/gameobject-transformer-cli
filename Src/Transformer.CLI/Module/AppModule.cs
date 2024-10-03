using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serialization;
using Serialization.Json;
using Serialization.Json.Convertors;
using Storage;
using Storage.FileSystem;
using Transformer.Generator;

namespace Transformer.CLI.Module;

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
     
        // possible use UnityGameObjectFactory instead of GameObjectFactory for Unity Editor
        // services.AddSingleton<IGameObjectFactory, UnityGameObjectFactory>();
        services.AddSingleton<IGameObjectFactory, GameObjectFactory>();
        services.AddSingleton<GameObjectService>();
        
        services.AddSingleton<IGameObjectService, GameObjectExceptionDecoratorService>(c =>
            new GameObjectExceptionDecoratorService(
                c.GetRequiredService<GameObjectService>(),
            c.GetRequiredService<ILoggerFactory>()));
        
        services.AddLogging(builder => builder.AddConsole());
        
        return services;
    }
}