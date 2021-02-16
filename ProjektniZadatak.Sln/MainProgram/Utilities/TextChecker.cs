using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MainProgram.Utilities
{
    public static class TextChecker
    {
        public static bool CheckIfTextIsFormedCorrectly(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            if (!Regex.IsMatch(text, @"[a-zA-Z]"))
                return false;

            return true;
        }
    }
}
