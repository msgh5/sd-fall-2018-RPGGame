using System;
using System.Linq;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; }

        public Game()
        {
            Hero = new Hero();
        }

        public void Start()
        {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");

            Hero.Name = Console.ReadLine();

            Console.WriteLine("Hello " + Hero.Name);

            Main();
        }

        private void Main()
        {
            var input = "0";

            while (input != "6")
            {
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. View Stats");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Fight Monster");
                Console.WriteLine("4. Visit Shop");
                Console.WriteLine("5. Check Achievements");
                Console.WriteLine("6. Exit");

                input = Console.ReadLine();

                if (input == "1")
                {
                    this.Stats();
                }
                else if (input == "2")
                {
                    this.Inventory();
                }
                else if (input == "3")
                {
                    this.Fight();
                }
                else if (input == "4")
                {
                    this.Shop();
                }
                else if (input == "5")
                {
                    this.CheckAchievements();
                }

                if (Hero.CurrentHP <= 0)
                {
                    return;
                }
            }
        }

        private void CheckAchievements()
        {
            var completedAchievements = Hero.GetAchievements();
            var totalPoints = completedAchievements
                .Sum(p => p.Achievement.Points);

            Console.WriteLine($"Achievements " +
                $"({totalPoints})");

            foreach(var completedAchievement in completedAchievements)
            {
                Console.WriteLine($"{completedAchievement.Achievement.Name}" +
                    $"- {completedAchievement.Date.ToString("dd/MM/yyyy HH:mm")}");
            }
        }

        private void Stats()
        {
            Hero.ShowStats();

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void Inventory()
        {
            Hero.ShowInventory();

            Console.WriteLine("Select one option from the menu:");
            Console.WriteLine("1 - Equip Weapon");
            Console.WriteLine("2 - Equip Armor");
            Console.WriteLine("3 - Unequip Weapon");
            Console.WriteLine("4 - Unequip Armor");
            Console.WriteLine("5 - Drink Potion");
            Console.WriteLine("6 - Equip Shield");
            Console.WriteLine("7 - Unequip Shield");

            var keyboardInput = Console.ReadLine();

            if (keyboardInput == "1")
            {
                var weapons = Hero.GetWeapons();

                for (var i = 0; i < weapons.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {weapons[i].Name}");
                }

                var index = Convert.ToInt32(Console.ReadLine())-1;

                Hero.EquipWeapon(index);
            }
            else if (keyboardInput == "2")
            {
                var armors = Hero.GetArmors();

                for (var i = 0; i < armors.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {armors[i].Name}");
                }

                var index = Convert.ToInt32(Console.ReadLine()) - 1;

                Hero.EquipArmor(index);
            }
            else if (keyboardInput == "3")
            {
                Hero.UnEquipWeapon();
            }
            else if (keyboardInput == "4")
            {
                Hero.UnEquipArmor();
            }
            else if (keyboardInput == "5")
            {
                Hero.ShowPotions();

                var index = Convert.ToInt32(Console.ReadLine()) - 1;

                Hero.DrinkPotion(index);
            }
            else if (keyboardInput == "6")
            {
                var shields = Hero.GetShields();

                for (var i = 0; i < shields.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {shields[i].Name}");
                }

                var index = Convert.ToInt32(Console.ReadLine()) - 1;

                Hero.EquipShield(index);
            }
            else if (keyboardInput == "7")
            {
                Hero.UnEquipShield();
            }
        }

        private void Fight()
        {
            var damageCalculator = new DamageCalculator();
            var monsterSelector = new MonsterSelector();
            var achievementManager = new AchievementManager();
            var enemy = monsterSelector.SelectMonsterBasedOnWeekDay();

            var fight = new Fight(Hero, enemy, damageCalculator, achievementManager);

            fight.Start();
        }

        private void Shop()
        {
            var shop = new Shop(Hero);

            shop.Start();
        }
    }
}