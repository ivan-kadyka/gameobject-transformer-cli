namespace Transformer.Exceptions;

public class GameObjectServiceException : Exception
{
    public GameObjectServiceException(string message, Exception innerException = default) : base(message, innerException)
    {

    }
}