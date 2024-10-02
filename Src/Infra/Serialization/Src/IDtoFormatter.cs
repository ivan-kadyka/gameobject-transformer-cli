namespace Serialization
{
    /// <summary>
    /// Defines methods for serializing and deserializing objects to and from data transfer object (DTO) format.
    /// </summary>
    public interface IDtoFormatter
    {
        /// <summary>
        /// Serializes an object to a formatted string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="value">The data object to serialize.</param>
        /// <exception cref="DtoFormatterException">Thrown when failed to deserialize data value.</exception>
        /// <returns>A formatted string representing the serialized object.</returns>
        string Serialize<T>(T value);
    
        /// <summary>
        /// Deserializes a formatted string to create a new object.
        /// </summary>
        /// <typeparam name="T">The type of the object to create.</typeparam>
        /// <param name="value">The formatted string to deserialize.</param>
        /// <exception cref="DtoFormatterException">Thrown when failed to deserialize data value.</exception>
        /// <returns>A new instance of the specified type.</returns>
        T Deserialize<T>(string value);
    }

}