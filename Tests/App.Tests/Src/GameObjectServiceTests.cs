using MainApp;
using Microsoft.Extensions.DependencyInjection;
using Transformer;

namespace App.Tests;

public class GameObjectServiceTests
{
    private AppServiceProvider _appServiceProvider;
    
    [SetUp]
    public void Setup()
    {
        _appServiceProvider = AppServiceProvider.CreateTestInstance();
    }

    [Test]
    public void Resolve_IGameObjectService_ShouldSuccess()
    {
      var gameObjectService =  _appServiceProvider.GetService<IGameObjectService>();
      
       Assert.IsNotNull(gameObjectService);
    }
    
    
    [TearDown]
    public void TearDown()
    {
        _appServiceProvider.Dispose();
    }
}
