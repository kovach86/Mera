using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DatabaseLayer
{
    public class DatabaseInitializer: DropCreateDatabaseIfModelChanges<SavedTextDbContext>
    {
        protected override void Seed(SavedTextDbContext context)
        {
            var savedTexts = new List<SavedText>()
            {
                new SavedText{ TextValue = @"Before the game begins, each player creates their player character and records the details (described below) on a character sheet. 
                                First, a player determines their character's ability scores, which consist of Strength, Constitution, Dexterity, Intelligence, Wisdom, and Charisma. 
                                Each edition of the game has offered differing methods of determining these scores. The player then chooses a race (species) such as human or elf, a character class (occupation) such as fighter or wizard, 
                                an alignment (a moral and ethical outlook), and other features to round out the character's abilities and backstory, 
                                which have varied in nature through differing editions.
                                During the game, players describe their PCs' intended actions, such as punching an opponent or picking a lock, and converse with the DM, who then describes the result or response"},
                new SavedText {TextValue = "Some random smaller text with some numbers 12312312 41234 12,12, 34"}
            };

            context.SavedTexts.AddRange(savedTexts);
            context.SaveChanges();
        }
    }
}
