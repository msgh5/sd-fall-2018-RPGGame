using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class AchievementManager
    {
        private List<IAchievement> Achievements { get; set; }

        public AchievementManager()
        {
            Achievements = new List<IAchievement>();
            GenerateAchievements();
        }

        private void GenerateAchievements()
        {
            Achievements.Add(new KilledOneMonsterAchievement());
            Achievements.Add(new KilledThreeMonstersAchievement());
            Achievements.Add(new Killed10MonstersAchievement());
            Achievements.Add(new Killed5DifferentMonsters());
        }

        public void CheckAchievements(Hero hero)
        {
            foreach(var achievement in Achievements)
            {
                var completedAchievements = hero.GetAchievements();
                var hasHeroFulfilledRequirements = achievement.Check(hero);

                if (hasHeroFulfilledRequirements && !completedAchievements
                    .Any(p => p.Achievement.Name == achievement.Name))
                {
                    Console.WriteLine($"Congratulations! " +
                        $"You complete the achievement {achievement.Name}");

                    hero.AddAchievement(achievement);
                }
            }
        }
    }
}
