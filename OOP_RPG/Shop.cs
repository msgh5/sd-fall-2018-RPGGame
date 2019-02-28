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
            Items.Add(new Weapon("Sword", 3, 10, 2));
            Items.Add(new Weapon("Axe", 4, 12, 3));
            Items.Add(new Weapon("Longsword", 7, 15, 4));

            Items.Add(new Armor("Wooden Armor", 10, 8, 3));
            Items.Add(new Armor("Metal Armor", 12, 14, 4));
            Items.Add(new Armor("Golden Armor", 15, 18, 5));

            Items.Add(new HealthPotion("Health Potion", 5 , 7, 2));
            Items.Add(new HealthPotion("Strong Health Potion", 10, 11, 4));
            Items.Add(new HealthPotion("Greath Health Potion", 15, 16, 5));

            Items.Add(new Shield("Wooden Shield", 3, 10, 3));
            Items.Add(new Shield("Battle Shield", 4, 12, 4));
            Items.Add(new Shield("Dragon Shield", 7, 15, 5));
        }

        public void Start()
        {
            var keyboardInput = "0";

            while(keyboardInput != "3")
            {
                Console.WriteLine("Hello hero! Welcome to the SHOP!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - Buy Items");
                Console.WriteLine("2 - Sell Items");
                Console.WriteLine("3 - Exit");

                keyboardInput = Console.ReadLine();

                if (keyboardInput == "1")
                {
                    BuyItems();
                }
                else if (keyboardInput == "2")
                {
                    SellItems();
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
                    Hero.GoldCoins -= item.Price;
                    Hero.Bag.Add(item);
                }
                else
                {
                    Console.WriteLine("You don't have enough gold coins.");
                }
            }
        }

        private void SellItems()
        {
            var unequippedItems = Hero.GetUnequippedItems();

            for (var i = 0; i < unequippedItems.Count(); i++)
            {
                Console.WriteLine($"{i + 1} - {unequippedItems[i].GetDescription(true)}");
            }

            var keyboardInput = Convert.ToInt32(Console.ReadLine());
            var itemIndex = keyboardInput - 1;

            var item = unequippedItems.ElementAtOrDefault(itemIndex);

            if (item != null)
            {
                Hero.GoldCoins += item.ResellValue;
                Hero.Bag.Remove(item);
            }
        }
    }
}
