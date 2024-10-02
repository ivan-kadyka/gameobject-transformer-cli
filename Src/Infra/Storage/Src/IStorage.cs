using Storage.Exceptions;

namespace Storage;

/// <summary>
/// Represents a storage interface capable of persisting user-defined data between application runs.
/// </summary>
public interface IStorage
{
    /// <summary>
    /// Saves generic data into the storage.
    /// </summary>
    /// <typeparam name="T">The type of data to save.</typeparam>
    /// <param name="key">The key associated with the data.</param>
    /// <param name="data">The generic data to be saved.</param>
    /// <param name="token">Optional cancellation token</param>
    /// <exception cref="StorageException">raised when failed to save data</exception>
    Task Save<T>(string key, T data, CancellationToken token = default);

    /// <summary>
    /// Loads generic data from the storage.
    /// </summary>
    /// <typeparam name="T">The type of data to load.</typeparam>
    /// <param name="key">The key associated with the data to be loaded.</param>
    /// <param name="token">Optional cancellation token</param>
    /// <exception cref="StorageException">raised when failed to load data</exception>
    /// <returns>The generic data loaded from the storage.<see langword="true"/> if data is successfully loaded, <see langword="false"/> otherwise.</returns>
    Task<T> Load<T>(string key, CancellationToken token = default);
        
    // also possible methods for public API:
    // 1) Task Remove(string key);
    // 2) bool Contains(sting key);
}