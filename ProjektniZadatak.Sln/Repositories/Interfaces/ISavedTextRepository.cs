
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ISavedTextRepository
    {
        SavedText GetById(int id);
        string AddNewSavedText(SavedText savedText);
        List<SavedText> GetAll();
    }
}
