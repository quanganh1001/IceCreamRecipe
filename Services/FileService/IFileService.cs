
using Models;

namespace Services.FileService;

public interface IFileService
{
    Task<string> Upload(FileModel model);
    
    Task Delete(string name);

}