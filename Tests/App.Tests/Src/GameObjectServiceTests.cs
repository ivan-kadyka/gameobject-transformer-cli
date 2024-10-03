using MainApp;
using Microsoft.Extensions.DependencyInjection;
using Storage;
using Transformer;
using Transformer.Exceptions;
using Transformer.Model;

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
        var storage = _appServiceProvider.GetRequiredService<IStorage>();
        var output = $"{OutputDirectory}/output1.json";
        
        // Act
        await gameObjectService.Transform("TestData/testData.json", output);
        
        // Assert
        var data = await storage.Load<GameObjectsData>(output);
        Assert.IsNotNull(data);
    }
    
    
    [Test]
    public void Transform_UseInvalidData_ShouldBeRaisedException()
    {
        // Arrange
        var gameObjectService =  _appServiceProvider.GetRequiredService<IGameObjectService>();
        var output = $"{OutputDirectory}/output2.json";
        
        // Act & Assert
        Assert.ThrowsAsync<GameObjectServiceException>(async () =>
        {
            await gameObjectService.Transform("TestData/invalidTestData.json", output);
        });
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
