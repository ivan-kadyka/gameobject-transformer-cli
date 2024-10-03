using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Transformer;
using Transformer.CLI;
using Transformer.CLI.Options;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var optionsResult = Parser.Default.ParseArguments<Options>(args);

        if (optionsResult.Tag == ParserResultType.NotParsed)
        {
            foreach (var error in optionsResult.Errors)
            {
                Console.WriteLine(error);
            }

            Environment.Exit(-1);
        }
        
        
        using (var appServiceProvider = AppServiceProvider.Create())
        {
            var gameObjectService = appServiceProvider.GetRequiredService<IGameObjectService>();
            
            var options = optionsResult.Value;
            await gameObjectService.Transform(options.Input, options.Output);
        }
    }
}

