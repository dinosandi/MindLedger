using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Backend.Application.Common.Interfaces
{
    public interface IFileStorageService
    {
        
        Task<string> SaveFileAsync(IFormFile file, string folderName);
    }
}
