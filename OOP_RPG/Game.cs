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

            while (input != "5")
            {
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. View Stats");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Fight Monster");
                Console.WriteLine("4. Visit Shop");
                Console.WriteLine("5. Exit");

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

                if (Hero.CurrentHP <= 0)
                {
                    return;
                }
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

            var keyboardInput = Console.ReadLine();

            if (keyboardInput == "1")
            {
                for (var i = 0; i < Hero.WeaponsBag.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {Hero.WeaponsBag[i].Name}");
                }

                var index = Convert.ToInt32(Console.ReadLine())-1;

                Hero.EquipWeapon(index);
            }
            else if (keyboardInput == "2")
            {
                for (var i = 0; i < Hero.ArmorsBag.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {Hero.ArmorsBag[i].Name}");
                }

                var index = Convert.ToInt32(Console.ReadLine()) - 1;

                Hero.EquipArmor(index);
            }
            else if (keyboardInput == "3")
            {
                Hero.UnequipWeapon();
            }
            else if (keyboardInput == "4")
            {
                Hero.UnequipArmor();
            }
        }

        private void Fight()
        {
            var damageCalculator = new DamageCalculator();
            var monsterSelector = new MonsterSelector();
            var enemy = monsterSelector.SelectMonsterBasedOnWeekDay();

            var fight = new Fight(Hero, enemy, damageCalculator);

            fight.Start();
        }

        private void Shop()
        {
            var shop = new Shop(Hero);

            shop.Start();
        }
    }
}