using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public static class FileHelper
    {
        public static string Add(IFormFile file)
        {
            string path = Directory.GetCurrentDirectory() + @"\wwwroot\Images";
            var newGuidPath = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string newPath = path + @"\" + newGuidPath;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            using (var stream = File.Create(newPath))
            {
                file.CopyTo(stream);
                stream.Flush();
            }
            return newPath;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static void Update(IFormFile file, string oldPath)
        {
            string extension = Path.GetExtension(file.FileName).ToUpper();
            using (FileStream stream = File.Open(oldPath, FileMode.Open))
            {
                file.CopyToAsync(stream);
                stream.Flush();
            }
        }
    }
}
