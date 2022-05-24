using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Beacon.service.Helpers
{
   public class Helper
    {
        public static void DeleteImage(string root,string folder,string imagename)
        {
            string FullPath = Path.Combine(root, folder, imagename);

            if (File.Exists(FullPath))
            {
                File.Delete(FullPath);
            }
        }
    }
}
