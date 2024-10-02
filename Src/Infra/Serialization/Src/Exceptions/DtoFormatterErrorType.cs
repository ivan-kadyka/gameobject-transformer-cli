namespace Serialization
{
    /// <summary>
    /// Enumerates the types of errors encountered during data transfer object (DTO) formatting operations.
    /// </summary>
    public enum DtoFormatterErrorType
    {
        /// <summary>
        /// Represents errors that occur during the encoding process, converting data into a suitable format for transmission or storage.
        /// </summary>
        Encoding,

        /// <summary>
        /// Denotes errors encountered during the decoding process, attempting to interpret or deserialize data from its encoded format back into its original form.
        /// </summary>
        Decoding
    }
}