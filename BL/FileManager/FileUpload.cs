using Microsoft.AspNetCore.Http;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BL.FileManager
//{
//    public static class FileUpload
//    {
//        public static async Task<string> SaveAsync(this IFormFile formFile, string folder)
//        {
//            string path = Path.Combine(Path.GetFullPath("wwwroot"), "Images", folder);
//            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

//            string filename = Guid.NewGuid().ToString() + formFile.FileName;

//            using (FileStream fs = new(Path.Combine(path,filename), FileMode.Create))
//            {
//                await fs.CopyToAsync(fs);
//            }
//            return filename;
//        }


//        public static bool CheckType(this IFormFile formFile, string required) => formFile.ContentType.Contains(required);
//    }
//}
