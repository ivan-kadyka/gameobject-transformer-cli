using Transformer.Exceptions;
using Transformer.Model;

namespace Transformer
{
    /// <summary>
    /// Defines methods for transforming game objects and managing their data representation.
    /// </summary>
    public interface IGameObjectService
    {
        /// <summary>
        /// Transforms game object data from the specified input to the specified output.
        /// </summary>
        /// <param name="input">The source path of the game object data to transform.</param>
        /// <param name="output">The destination path for the transformed game object data.</param>
        /// <param name="token">A token to monitor for cancellation requests.</param>
        /// <exception cref="GameObjectServiceException">Thrown when the transformation fails due to a service error.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Transform(string input, string output, CancellationToken token = default);

        /// <summary>
        /// Transforms a collection of game objects into a new representation.
        /// </summary>
        /// <param name="gameObjectDtos">A read-only collection of game object data transfer objects to transform.</param>
        /// <param name="token">A token to monitor for cancellation requests.</param>
        /// <exception cref="GameObjectServiceException">Thrown when the transformation fails due to a service error.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        /// <returns>A task that represents the asynchronous operation, containing the transformed game object collection.</returns>
        Task<IReadOnlyCollection<GameObjectDto>> Transform(IReadOnlyCollection<GameObjectDto> gameObjectDtos, CancellationToken token = default);
    }
}
