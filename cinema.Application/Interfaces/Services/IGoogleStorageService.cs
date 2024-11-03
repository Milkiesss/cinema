namespace cinema.Application.Interfaces.Services;

public interface IGoogleStorageService
{
    public Task<string> UploadFile(string bucketName, string localPath, Stream source);
    public Task DeleteFile(string fileName);
    public Task<string> GetFileMetadataAsync(string fileName);
}