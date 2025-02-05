using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Extensions
{
    public static class FileExtension
    {
        public static  bool isValidType(this IFormFile file, string type)
            => file.ContentType.StartsWith(type);
        public static bool isValidSize(this IFormFile file, int kb)
            => file.Length < kb * 1024;

        public static async Task<string> UploadAsync(this IFormFile file, params string[] paths)
        {
            string uploadPath = Path.Combine(paths);

            if (!Path.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string newFileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);

            using(Stream stream = File.Create(Path.Combine(uploadPath, newFileName)))
            {
                await file.CopyToAsync(stream);
            }
            return newFileName;
        }
    }
}
