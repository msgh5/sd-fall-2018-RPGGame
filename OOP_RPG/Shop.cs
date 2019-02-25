using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        private List<IShopItem> Items { get; set; }
        private Hero Hero { get; set; }

        public Shop(Hero hero)
        {
            Items = new List<IShopItem>();
            Hero = hero;

            GenerateItems();
        }

        private void GenerateItems()
        {
            Items.Add(new Weapon("Sword", 3, 10));
            Items.Add(new Weapon("Axe", 4, 12));
            Items.Add(new Weapon("Longsword", 7, 15));

            Items.Add(new Armor("Wooden Armor", 10, 8));
            Items.Add(new Armor("Metal Armor", 12, 14));
            Items.Add(new Armor("Golden Armor", 15, 18));
        }

        public void Start()
        {
            var keyboardInput = "0";

            while(keyboardInput != "2")
            {
                Console.WriteLine("Hello hero! Welcome to the SHOP!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - Buy Items");
                Console.WriteLine("2 - Exit");

                keyboardInput = Console.ReadLine();

                if (keyboardInput == "1")
                {
                    BuyItems();
                }
            }
        }

        private void BuyItems()
        {
            for(var i = 0; i < Items.Count(); i++)
            {
                Console.WriteLine($"{i + 1} - {Items[i].GetDescription()}");
            }

            var keyboardInput = Convert.ToInt32(Console.ReadLine());
            var itemIndex = keyboardInput - 1;

            var item = Items.ElementAtOrDefault(itemIndex);

            if (item != null)
            {
                if (Hero.GoldCoins >= item.Price)
                {
                    AddItemToHero(item);
                    Hero.GoldCoins -= item.Price;
                }
                else
                {
                    Console.WriteLine("You don't have enough gold coins.");
                }
            }
        }

        /// <summary>
        /// This is not good and should be refactored.
        /// </summary>
        /// <param name="item"></param>
        private void AddItemToHero(IShopItem item)
        {
            if (item is Weapon)
            {
                Hero.WeaponsBag.Add((Weapon)item);
            }
            else if (item is Armor)
            {
                Hero.ArmorsBag.Add((Armor)item);
            }
        }
    }
}
