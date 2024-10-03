using MainApp;
using Microsoft.Extensions.DependencyInjection;
using Transformer;

namespace App.Tests;

public class GameObjectServiceTests
{
    private const string OutputDirectory = "Output";
    private AppServiceProvider _appServiceProvider;
    
    [SetUp]
    public void Setup()
    {
        _appServiceProvider = AppServiceProvider.CreateTestInstance();

        var directory = Path.GetFullPath(OutputDirectory);
        Directory.CreateDirectory(directory);
    }

    [Test]
    public void Resolve_IGameObjectService_ShouldSuccess()
    {
        // Arrange & Act
         var gameObjectService =  _appServiceProvider.GetRequiredService<IGameObjectService>();
      
        Assert.IsNotNull(gameObjectService);
    }
    
    [Test]
    public async Task Transform_UseValidData_ShouldSuccessOutput()
    {
        // Arrange
        var gameObjectService =  _appServiceProvider.GetRequiredService<IGameObjectService>();
        
        // Act
        
        await gameObjectService.Transform("TestData/testData.json", $"{OutputDirectory}/output1.json");
        
      
        Assert.IsNotNull(gameObjectService);
    }
    
    
    [TearDown]
    public void TearDown()
    {
        _appServiceProvider.Dispose();
        
        var directory = Path.GetFullPath(OutputDirectory);

        if (Directory.Exists(directory))
        {
            Directory.Delete(directory, true);
        }
    }
}
