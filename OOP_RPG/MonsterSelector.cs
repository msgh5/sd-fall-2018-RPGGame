using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class MonsterSelector
    {
        private List<Monster> Monsters { get; set; }

        public MonsterSelector()
        {
            GenerateMonsters();
        }

        public Monster SelectMonsterBasedOnWeekDay()
        {
            var dayOfWeek = DateTime.Now.DayOfWeek;

            return (from monster in Monsters
                     where monster.RespawnDay == dayOfWeek
                     orderby Guid.NewGuid().ToString()
                     select monster).First();
        }

        private void GenerateMonsters()
        {
            Monsters = new List<Monster>
            {
                new Monster("Bat", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Monday),
                new Monster("Bug", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Monday),
                new Monster("Rat", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Tuesday),
                new Monster("Troll", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Tuesday),
                new Monster("Goblin", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Wednesday),
                new Monster("Spider", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Wednesday),
                new Monster("Frog", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Thursday),
                new Monster("Snake", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Thursday),
                new Monster("Wasp", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Friday),
                new Monster("Wolf", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Friday),
                new Monster("Amazon", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Saturday),
                new Monster("Bandit", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Saturday),
                new Monster("Bear", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Sunday),
                new Monster("Serpent", 10, 3, 10, MonsterDificulty.Easy, DayOfWeek.Sunday),
                new Monster("Beholder", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Monday),
                new Monster("Cyclops", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Monday),
                new Monster("Monk", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Tuesday),
                new Monster("Dwarf", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Tuesday),
                new Monster("Necromancer", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Wednesday),
                new Monster("Dworc", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Wednesday),
                new Monster("Elf", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Thursday),
                new Monster("Gargoyle", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Thursday),
                new Monster("Ghoul", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Friday),
                new Monster("Skeleton", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Friday),
                new Monster("Hunter", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Saturday),
                new Monster("Lizard", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Saturday),
                new Monster("Minotaur", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Sunday),
                new Monster("Mummy", 15, 5, 25, MonsterDificulty.Medium, DayOfWeek.Sunday),
                new Monster("Medusa", 20, 8, 30, MonsterDificulty.Hard, DayOfWeek.Monday),
                new Monster("Reaper", 20, 8, 30, MonsterDificulty.Hard, DayOfWeek.Tuesday),
                new Monster("Draken", 20, 8, 30, MonsterDificulty.Hard, DayOfWeek.Wednesday),
                new Monster("Demon", 20, 8, 30, MonsterDificulty.Hard, DayOfWeek.Thursday),
                new Monster("Wyrm", 20, 8, 30, MonsterDificulty.Hard, DayOfWeek.Friday),
                new Monster("Werewolf", 20, 8, 30, MonsterDificulty.Hard, DayOfWeek.Saturday),
                new Monster("Warlock", 20, 8, 30, MonsterDificulty.Hard, DayOfWeek.Sunday)
            };
        }
    }
}
