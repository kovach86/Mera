using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Path = System.IO.Path;

namespace Services.TextReaders
{
    public class FileContentReader : ISourceReader
    {
        public string GetTextFromSource(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return null;

            if (Path.GetExtension(filePath).ToLower().Equals(".pdf"))
                return GetTextFromPdf(filePath);

            return File.ReadAllText(filePath);
        }

        private string GetTextFromPdf(string filePath)
        {
            using (PdfReader reader = new PdfReader(filePath))
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    sb.Append((PdfTextExtractor.GetTextFromPage(reader, i)));
                }

                return sb.ToString();
            }
        }
    }
}
