using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shield : IShield
    {
        public string Name { get; }
        public int Defense { get; }
        public int Price { get; }
        public int ResellValue { get; }

        public Shield(string name, int defense, int price, int resellValue)
        {
            Name = name;
            Defense = defense;
            Price = price;
            ResellValue = resellValue;
        }

        public string GetDescription(bool useResellValue = false)
        {
            return $"Name: {Name} - Def: {Defense} " +
                $"- Price: {(useResellValue ? ResellValue : Price)}";
        }
    }
}
