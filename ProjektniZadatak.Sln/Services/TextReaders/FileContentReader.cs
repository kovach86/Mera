using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TextReaders
{
    public class FileContentReader : ISourceReader
    {
        public string GetTextFromSource(string filePath)
        {
            if(!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
               return File.ReadAllText(filePath);

            return null;
        }
    }
}
