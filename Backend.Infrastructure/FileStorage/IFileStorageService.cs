using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.FileStorage;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(IFormFile file, string folderName);
}
