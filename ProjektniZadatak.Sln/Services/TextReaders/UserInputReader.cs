using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TextReaders
{
    public class UserInputReader : ISourceReader
    {
        public string GetTextFromSource(string userInputText)
        {
            return userInputText;
        }
    }
}
