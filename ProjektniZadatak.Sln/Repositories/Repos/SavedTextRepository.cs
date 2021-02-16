using Core.DatabaseLayer;
using Core.Entities;
using CustomErrorLogger;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class SavedTextRepository : ISavedTextRepository
    {
        private SavedTextDbContext _dbContext;

        public SavedTextRepository(SavedTextDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string AddNewSavedText(SavedText savedText)
        {
            try
            {
                _dbContext.SavedTexts.Add(savedText);
                return "Entry inserted successfully";
            }
            catch (Exception ex)
            {
                CustomNLogger.LogException(ex.Message);
                return null;
            }
        }

        public List<SavedText> GetAll()
        {
            return _dbContext.SavedTexts.ToList();
        }

        public SavedText GetById(int id)
        {
            return _dbContext.SavedTexts.FirstOrDefault(x => x.Id == id);
        }
    }
}
