using Microsoft.Extensions.Logging;
using Transformer.Exceptions;
using Transformer.Model;

namespace Transformer;

public class GameObjectExceptionDecoratorService : IGameObjectService
{
    private readonly IGameObjectService _service;
    private readonly ILogger _logger;
    
    public GameObjectExceptionDecoratorService(IGameObjectService service, ILoggerFactory loggerFactory)
    {
        _service = service;
        _logger = loggerFactory.CreateLogger(nameof(IGameObjectService));
    }
    
    
    public async Task Transform(string input, string output, CancellationToken token = default)
    {
       await WrapException(async () =>
       {
           await _service.Transform(input, output, token);
           return true;
       });
    }

    public async Task<IReadOnlyCollection<GameObjectDto>> Transform(IReadOnlyCollection<GameObjectDto> gameObjectDtos, CancellationToken token = default)
    {
       return await WrapException(async () => await _service.Transform(gameObjectDtos, token));
    }
    
    private async Task<T> WrapException<T>(Func<Task<T>> funcTask)
    {
        try
        {
            return await funcTask();
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (GameObjectServiceException e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            var gameServiceException = new GameObjectServiceException("Error while transforming GameObjects", e);
            _logger.LogError(gameServiceException, gameServiceException.Message);
            
            throw gameServiceException;
        }
    }
}