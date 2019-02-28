using System;

namespace OOP_RPG
{
    public class Fight
    {
        private Hero Hero { get; }
        private Monster Enemy { get; set; }
        private DamageCalculator DamageCalculator { get; }
        private AchievementManager AchievementManager { get; }

        public Fight(Hero hero, 
            Monster enemy, 
            DamageCalculator calculator,
            AchievementManager achievementManager)
        {
            Hero = hero;
            Enemy = enemy;
            DamageCalculator = calculator;
            AchievementManager = achievementManager;
        }

        public void Start()
        {
            while (Enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine("You've encountered a " + Enemy.Name + "! " + Enemy.Strength + " Strength/" + Enemy.Defense + " Defense/" +
                Enemy.CurrentHP + " HP. What will you do?");

                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Heal");
                Console.WriteLine("3. Run Away");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn();
                }
                else if (input == "2")
                {
                    Heal();
                }
                else if (input == "3")
                {
                    RunAway();
                }
            }
        }

        private void RunAway()
        {
            var random = new Random();
            var monsterChance = Enemy.GetRunAwayChance();
            var result = random.Next(1, 101);

            if (result <= monsterChance)
            {
                Console.WriteLine("You ran away from the monster");
                Enemy.CurrentHP = 0;
            }
            else
            {
                Console.WriteLine("You failed to run away");
                MonsterTurn();
            }
        }
        
        private void Heal()
        {
            Hero.ShowPotions();

            var index = Convert.ToInt32(Console.ReadLine()) - 1;

            Hero.DrinkPotion(index);
        }

        private void HeroTurn()
        {   
            var baseDamage = Hero.CalculatedStrength - Enemy.Defense;

            var finalDamage = DamageCalculator.CalculateDamage(baseDamage);

            Enemy.CurrentHP -= finalDamage;

            Console.WriteLine("You did " + finalDamage + " damage!");

            if (Enemy.CurrentHP <= 0)
            {
                Win();
            }
            else
            {
                MonsterTurn();
            }
        }

        private void MonsterTurn()
        {
            var baseDamage = Enemy.Strength - Hero.CalculatedDefense;

            var finalDamage = DamageCalculator.CalculateDamage(baseDamage);

            Hero.CurrentHP -= finalDamage;

            Console.WriteLine(Enemy.Name + " does " + finalDamage + " damage!");

            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }

        private void Win()
        {
            var goldCoins = Enemy.DropLoot();

            Hero.GoldCoins += goldCoins;
            Hero.AddKillHistory(Enemy.Name);
            AchievementManager.CheckAchievements(Hero);

            Console.WriteLine(Enemy.Name + " has been defeated! You win the battle!");
        }

        private void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }
    }
}