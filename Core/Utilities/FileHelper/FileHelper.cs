using Core.Utilities.Results;
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
            return newGuidPath;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(IFormFile file, string oldPath)
        {
            Delete(oldPath);
            return Add(file);

        }
    }
}
