using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DatabaseLayer
{
    public class SavedTextDbContext : DbContext
    {
        public SavedTextDbContext():base("name=SavedTextContext")
        {

        }

        public DbSet<SavedText> SavedTexts { get; set; }
    }
}
