using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class KilledThreeMonstersAchievement : IAchievement
    {
        public string Name { get; }
        public int Points { get; }

        public KilledThreeMonstersAchievement()
        {
            Name = "Killing 3 monsters";
            Points = 2;
        }

        public bool Check(Hero hero)
        {
            var killHistory = hero.GetKillHistory();

            return killHistory.Sum(p => p.KillCount) >= 3;
        }
    }
}
