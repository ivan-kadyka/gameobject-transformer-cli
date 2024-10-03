using Serialization;
using Storage.Exceptions;

namespace Storage.FileSystem;

public class FileSystemStorage : IStorage
{
    private readonly IDtoFormatter _dtoFormatter;

    public FileSystemStorage(IDtoFormatter dtoFormatter)
    {
        _dtoFormatter = dtoFormatter;
    }
    
    
    public async Task Save<T>(string key, T data, CancellationToken token = default)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        try
        {
            string content = default;
                
            if (data != null)
                content = _dtoFormatter.Serialize(data);
            
            var directory = Path.GetDirectoryName(Path.GetFullPath(key));
            Directory.CreateDirectory(directory);

            await File.WriteAllTextAsync(key, content, token).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            throw new StorageException($"Storage.Save has internal error for key: '{key}'", e);
        }
    }

    public async Task<T> Load<T>(string key, CancellationToken token = default)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));
            
        try
        {
            T data = default;

            if (!File.Exists(key))
                return data;

            var content = await File.ReadAllTextAsync(key, token);

            if (content != null)
                data = _dtoFormatter.Deserialize<T>(content);
                
            return data;
        }
        catch (Exception e)
        {
            throw new StorageException($"Storage.Load has internal error during for key: '{key}'", e);
        }
    }
}