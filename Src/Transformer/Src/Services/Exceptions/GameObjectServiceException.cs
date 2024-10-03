namespace Transformer.Exceptions;

/// <summary>
/// Represents errors that occur during game object service operations.
/// </summary>
public class GameObjectServiceException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameObjectServiceException"/> class with a specified error message and an optional inner exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    public GameObjectServiceException(string message, Exception innerException = default) : base(message, innerException)
    {
    }
}