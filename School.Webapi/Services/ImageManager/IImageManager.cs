using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace School.Webapi.Services.ImageManager
{
    public interface IImageManager
    {
        public bool CheckImageSize(IFormFile file);

        public bool CheckIsImage(string filename);

        public string GetFullPath(string imagename);

        public Task<string> UploadFileAsync(IFormFile file);

        public Task<string> ChangeFileAsync(string deletedImagename, 
            IFormFile file);

        public bool DeleteFile(string filename);
    }
}
