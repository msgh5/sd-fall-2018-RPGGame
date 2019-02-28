using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class HealthPotion : IShopItem
    {
        public string Name { get; }
        public int Price { get; }
        public int Health { get; }
        public int ResellValue { get; }

        public HealthPotion(string name, int price, int health, int resellValue)
        {
            Name = name;
            Price = price;
            Health = health;
            ResellValue = resellValue;
        }

        public string GetDescription(bool useResellValue = false)
        {
            return $"Name: {Name} - Health: {Health} " +
                $"- Price: {(useResellValue ? ResellValue : Price)}";
        }
    }
}
