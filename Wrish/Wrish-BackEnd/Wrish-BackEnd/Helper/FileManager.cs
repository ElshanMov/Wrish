using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Helper
{
    public static class FileManager
    {
        public static string Save(string roothPath, string folder, IFormFile file) 
        {
            string fileName = file.FileName;
            fileName = fileName.Length <= 64 ? fileName : fileName.Substring(fileName.Length - 64, 64);
            fileName = Guid.NewGuid().ToString() + fileName;
            string path = Path.Combine(roothPath, folder, fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }

        public static bool Delete(string roothPath, string folder, string fileName)
        {
            string path = Path.Combine(roothPath, folder, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
