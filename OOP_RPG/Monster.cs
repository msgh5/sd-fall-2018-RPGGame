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
    }
}