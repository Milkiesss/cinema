using cinema.Application.Interfaces.Services;
using Google.Cloud.Storage.V1;

namespace cinema.Application.Services;

public class GoogleStorageService : IGoogleStorageService
{
    private readonly StorageClient _storageClient;
    private readonly string _bucketName = "cinema-bucket";
    public GoogleStorageService()
    {
        var credentialsPath = "C:\\Users\\annap\\OneDrive\\Документы\\texn\\cinema\\cinema-439118-4942cce8ee08.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsPath);
        _storageClient = StorageClient.Create();
    }
    public async Task<string> UploadFile(string objectName,string contentType, Stream source)
    {
        await _storageClient.UploadObjectAsync(
            _bucketName,
            objectName,
            contentType,
            source
        );
        return $"https://storage.googleapis.com/{_bucketName}/{objectName}";
        
    }
    
    public async Task DeleteFile(string objectName)
    { 
        await _storageClient.DeleteObjectAsync(_bucketName, objectName);
    }

    public async Task<string> GetFileMetadataAsync(string fileName)
    {
        var fileobject = await _storageClient.GetObjectAsync(_bucketName, fileName);

        return fileobject.Name;
    }
}