using Microsoft.AspNetCore.Http;
namespace BL.FileManager
{
    public static class FileUpload
    {
        public static async Task<string> SaveAsync(this IFormFile file, string folder)
        {
            string uploadPath = Path.Combine(Path.GetFullPath("wwwroot"), "Images", folder);

            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);

            string filename = Guid.NewGuid().ToString() + file.FileName;

            using (FileStream fs = new(Path.Combine(uploadPath, filename), FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return filename;
        }

        public static bool CheckType(this IFormFile formFile, string required) => formFile.ContentType.Contains(required);
    }
}
