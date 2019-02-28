using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Killed10MonstersAchievement : IAchievement
    {
        public string Name { get; }
        public int Points { get; }

        public Killed10MonstersAchievement()
        {
            Name = "Killing 10 monster";
            Points = 5;
        }

        public bool Check(Hero hero)
        {
            var killHistory = hero.GetKillHistory();

            return killHistory.Sum(p => p.KillCount) >= 10;
        }
    }
}
