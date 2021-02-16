using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TextReaders
{
    public interface ISourceReader
    {
        string GetTextFromSource(string source);
    }
    public  class SourceReader
    {
        private ISavedTextRepository _isavedTextRepo;

        public void SetTextRepo(ISavedTextRepository savedTextRepository)
        {
            _isavedTextRepo = savedTextRepository;
        }
        public  ISourceReader GetAppropriateReader(ReaderType readerType)
        {
            ISourceReader reader = null;
            switch (readerType)
            {
                case ReaderType.UserInputText:
                    reader = new UserInputReader();
                    break;
                case ReaderType.TextFromFile:
                    reader = new FileContentReader();
                    break;
                default:
                    break;
            }

            return reader;
        }
    }

    public enum ReaderType
    {
        UserInputText = 1,
        TextFromFile = 3
    }
}
