using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class KillHistory
    {
        public string MonsterName { get; set; }
        public int KillCount { get; set; }

        public KillHistory(string monsterName)
        {
            MonsterName = monsterName;
        }
    }
}
