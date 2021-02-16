using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextOperationServices.Interfaces;

namespace TextOperationServices
{
    public class TextService : ITextService
    {
        public string ReturnNumberOfWordsInText(string text)
        {
            int regexCount = Regex.Matches(text, @"[A-Za-z0-9-']+").Count;
            return $"number of words: {regexCount} ";
        }

        private string ReturnNumberOfWordsInTextTest(string text)
        {
            string result = "";

            #region 1. way
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            int wordNumber = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

            result += $"number of words using split method is {wordNumber}";
            #endregion

            #region RegEx way
            //int regexCount = Regex.Matches(text, @"[A-Za-z0-9-']+").Count;
            int regexCount = Regex.Matches(text, @"[A-Za-z0-9-']+").Count;
            result += $"\n using Regex: {regexCount} ";
            #endregion

            #region RegEx second way
            var regex = new Regex("\\w+");
            result += $"second regex counter {regex.Matches(text).Count}";
            #endregion

            return result;
        }
    }
}
