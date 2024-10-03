using MainApp;
using MainApp.Options;
using Microsoft.Extensions.DependencyInjection;
using Transformer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        //TODO: pass option via CLI args
        IOptions options = new Options
        {
            Input = "testData.json",
            Output = "outputData.json"
        };

        using (var appServiceProvider = AppServiceProvider.Create())
        {
            var gameObjectService = appServiceProvider.GetRequiredService<IGameObjectService>();

            await gameObjectService.Transform(options.Input, options.Output);
        }
    }
}

