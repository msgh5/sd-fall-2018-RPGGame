using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Killed5DifferentMonsters : IAchievement
    {
        public string Name { get; }
        public int Points { get; }

        public Killed5DifferentMonsters()
        {
            Name = "Killing 5 different monsters";
            Points = 3;
        }

        public bool Check(Hero hero)
        {
            var killHistory = hero.GetKillHistory();

            return killHistory.Count() >= 5;
        }
    }
}
