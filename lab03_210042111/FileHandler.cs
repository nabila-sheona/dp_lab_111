using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02_210042111
{
   

    public class FileHandler
    {
        public static string Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.");
            }
            return File.ReadAllText(filePath);
        }

        public static void Write(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }

}
