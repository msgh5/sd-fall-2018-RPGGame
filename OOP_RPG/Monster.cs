using System;

namespace OOP_RPG
{ 
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public MonsterDificulty Dificulty { get; set; }
        public DayOfWeek RespawnDay { get; set; }

        public Monster(string name, int strength,
            int defense, int hp, MonsterDificulty dificulty, DayOfWeek respawnDay)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHP = hp;
            CurrentHP = hp;
            Dificulty = dificulty;
            RespawnDay = respawnDay;
        }

        public int DropLoot()
        {
            if (CurrentHP > 0)
            {
                throw new Exception("Monster is still alive");
            }

            var random = new Random();
            int goldCoins = 0;

            if (Dificulty == MonsterDificulty.Easy)
            {
                goldCoins = random.Next(1, 11);
            }
            else if (Dificulty == MonsterDificulty.Medium)
            {
                goldCoins = random.Next(11, 21);
            }
            else if (Dificulty == MonsterDificulty.Hard)
            {
                goldCoins = random.Next(21, 31);
            }

            return goldCoins;
        }

        public int GetRunAwayChance()
        {
            if (Dificulty == MonsterDificulty.Easy)
            {
                return 50;
            }
            else if (Dificulty == MonsterDificulty.Medium)
            {
                return 25;
            }
            else if (Dificulty == MonsterDificulty.Hard)
            {
                return 5;
            }
            else
            {
                throw new NotImplementedException(
                    $"Dificulty not implemented: {Dificulty}");
            }

        }
    }
}