using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; }
        public int CalculatedStrength
        {
            get
            {
                return Strength + 
                    (EquippedWeapon == null ? 
                    0 : 
                    EquippedWeapon.Strength);
            }
        }
        public int CalculatedDefense
        {
            get
            {
                //Syntax sugar
                //return Defense + EquippedArmor?.Defense ?? 0;

                return Defense + (EquippedArmor == null ?
                    0:
                    EquippedArmor.Defense);
            }
        }
        public int Defense { get; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public IWeapon EquippedWeapon { get; private set; }
        public IArmor EquippedArmor { get; private set; }
        public List<IShopItem> Bag { get; private set; }
        public int GoldCoins { get; set; }

        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero()
        {
            Bag = new List<IShopItem>();
            Strength = 10;
            Defense = 10;
            OriginalHP = 30;
            CurrentHP = 30;
            GoldCoins = 500;
        }

        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine($"Strength: {this.Strength} " +
                $"{(this.EquippedWeapon == null ? "" : "(+"+ this.EquippedWeapon.Strength +")")}");
            Console.WriteLine($"Defense: {this.Defense} " +
                $"{(this.EquippedArmor == null ? "" : "(+" + this.EquippedArmor.Defense + ")")}");
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");

            foreach (var weapon in GetWeapons())
            {
                Console.WriteLine(weapon.Name + " of " + weapon.Strength + " Strength");
            }

            Console.WriteLine("Armor: ");

            foreach (var armor in GetArmors())
            {
                Console.WriteLine(armor.Name + " of " + armor.Defense + " Defense");
            }
        }

        public void EquipArmor(int index)
        {
            var armor = GetArmors()[index];
            this.EquippedArmor = armor;
        }

        public void EquipWeapon(int index)
        {
            var weapon = GetWeapons()[index];
            this.EquippedWeapon = weapon;
        }

        public void UnEquipArmor()
        {
            this.EquippedArmor = null;
        }

        public void UnEquipWeapon()
        {
            this.EquippedWeapon = null;
        }

        public IReadOnlyList<IWeapon> GetWeapons()
        {
            return Bag.Where(p => p is IWeapon).Cast<IWeapon>().ToList();
        }

        public IReadOnlyList<IArmor> GetArmors()
        {
            return Bag.Where(p => p is IArmor).Cast<IArmor>().ToList();
        }
    }
}