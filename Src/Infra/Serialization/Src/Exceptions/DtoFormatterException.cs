namespace Serialization
{
    /// <summary>
    /// Represents an exception that occurs during data transfer object (DTO) formatting operations.
    /// </summary>
    public class DtoFormatterException : Exception
    {
        /// <summary>
        /// Gets the type of error associated with the exception.
        /// </summary>
        public DtoFormatterErrorType Type { get; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DtoFormatterException"/> class with the specified error type, message, and inner exception.
        /// </summary>
        /// <param name="type">The type of error that caused the exception.</param>
        /// <param name="message">A descriptive message that explains the error.</param>
        /// <param name="innerException">The exception that caused the current exception, or <see langword="null"/> if no inner exception is specified.</param>
        public DtoFormatterException(DtoFormatterErrorType type, string message, Exception innerException) 
            : base(message, innerException)
        {
            Type = type;
        }
    }
}