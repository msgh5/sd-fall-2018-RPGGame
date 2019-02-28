using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class CompletedAchievement
    {
        public DateTime Date { get; }
        public IAchievement Achievement { get; }

        public CompletedAchievement(DateTime date, IAchievement achievement)
        {
            Date = date;
            Achievement = achievement;
        }
    }
}
