using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class KilledOneMonsterAchievement : IAchievement
    {
        public string Name { get; }
        public int Points { get; }

        public KilledOneMonsterAchievement()
        {
            Name = "Killing 1 monster";
            Points = 1;
        }

        public bool Check(Hero hero)
        {
            var killHistory = hero.GetKillHistory();

            return killHistory.Any();
        }
    }
}
