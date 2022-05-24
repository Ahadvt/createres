using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Beacon.service.Extentions
{
    static class FileReader
    {

        public static bool IsSizeOk(this IFormFile file)
        {
            return file.Length / 1024 / 1024 <= 2;
        }

        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }

        public static string SaveImage(this IFormFile file,string root,string folder)
        {
            string RootPath = Path.Combine(root, folder);
            string FileName = Guid.NewGuid().ToString() + file.FileName;
            string FullPath = Path.Combine(RootPath,FileName);

            using(FileStream stream=new FileStream(FullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return FileName;
        }
    }
}
