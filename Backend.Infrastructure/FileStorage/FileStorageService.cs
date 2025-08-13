using Microsoft.AspNetCore.Http;

namespace Backend.Infrastructure.FileStorage;

public class FileStorageService : IFileStorageService
{
    public async Task<string> SaveFileAsync(IFormFile file, string folderName)
    {
        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Path.Combine(folderName, fileName).Replace("\\", "/");
    }
}
