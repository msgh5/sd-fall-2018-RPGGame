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
                return Strength + CalculatedEquipmentStrength;
            }
        }
        public int CalculatedEquipmentStrength
        {
            get
            {
                return (EquippedWeapon == null ?
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

                return Defense + CalculatedEquipmentDefense;
            }
        }
        public int CalculatedEquipmentDefense
        {
            get
            {
                //Syntax sugar
                //return Defense + EquippedArmor?.Defense ?? 0;

                return (EquippedArmor == null ?
                    0 :
                    EquippedArmor.Defense) +
                    (EquippedShield == null ?
                    0 :
                    EquippedShield.Defense);
            }
        }

        public int Defense { get; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public IWeapon EquippedWeapon { get; private set; }
        public IArmor EquippedArmor { get; private set; }
        public IShield EquippedShield { get; private set; }
        public List<IShopItem> Bag { get; private set; }
        public int GoldCoins { get; set; }
        private List<KillHistory> KillHistory { get; set; }
        private List<CompletedAchievement> CompletedAchievements { get; set; }

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
            KillHistory = new List<KillHistory>();
            CompletedAchievements = new List<CompletedAchievement>();
            Strength = 1000;
            Defense = 10;
            OriginalHP = 30;
            CurrentHP = 30;
            GoldCoins = 500;
        }

        public IReadOnlyList<KillHistory> GetKillHistory()
        {
            return KillHistory.ToList();
        }

        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine($"Strength: {this.Strength} " +
                $"{(this.CalculatedEquipmentStrength == 0 ? "" : "(+" + this.CalculatedEquipmentStrength + ")")}");
            Console.WriteLine($"Defense: {this.Defense} " +
                $"{(this.CalculatedEquipmentDefense == 0 ? "" : "(+" + this.CalculatedEquipmentDefense + ")")}");
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

            Console.WriteLine("Shield: ");

            foreach (var shield in GetShields())
            {
                Console.WriteLine(shield.Name + " of " + shield.Defense + " Defense");
            }
        }

        public void EquipArmor(int index)
        {
            var armor = GetArmors()[index];
            EquippedArmor = armor;
        }

        public void EquipWeapon(int index)
        {
            var weapon = GetWeapons()[index];
            EquippedWeapon = weapon;
        }

        public void EquipShield(int index)
        {
            var shield = GetShields()[index];
            this.EquippedShield = shield;
        }

        public void DrinkPotion(int index)
        {
            var potion = GetPotions()[index];

            var hpAfterHealed = CurrentHP + potion.Health;

            var finalHp = Math.Min(OriginalHP, hpAfterHealed);

            CurrentHP = finalHp;

            Bag.Remove(potion);
        }

        public void UnEquipArmor()
        {
            EquippedArmor = null;
        }

        public void UnEquipWeapon()
        {
            EquippedWeapon = null;
        }

        public void UnEquipShield()
        {
            EquippedShield = null;
        }

        public IReadOnlyList<IWeapon> GetWeapons()
        {
            return Bag.Where(p => p is IWeapon).Cast<IWeapon>().ToList();
        }

        public IReadOnlyList<IArmor> GetArmors()
        {
            return Bag.Where(p => p is IArmor).Cast<IArmor>().ToList();
        }

        public IReadOnlyList<IShield> GetShields()
        {
            return Bag.Where(item => item is IShield).Cast<IShield>().ToList();
        }

        public IReadOnlyList<HealthPotion> GetPotions()
        {
            return Bag.Where(p => p is HealthPotion).Cast<HealthPotion>().ToList();
        }

        public IReadOnlyList<IShopItem> GetUnequippedItems()
        {
            return Bag.Where(item => item != EquippedArmor
            && item != EquippedWeapon
            && item != EquippedShield).ToList();
        }

        public void ShowPotions()
        {
            var potions = GetPotions();

            for (var i = 0; i < potions.Count(); i++)
            {
                Console.WriteLine($"{i + 1} - {potions[i].Name}");
            }
        }

        public void AddKillHistory(string monsterName)
        {
            var record = KillHistory
                .Where(p => p.MonsterName == monsterName)
                .FirstOrDefault();

            if (record == null)
            {
                record = new KillHistory(monsterName);
                KillHistory.Add(record);
            }

            record.KillCount++;
        }

        public void AddAchievement(IAchievement achievement)
        {
            var completedAchiemevent = 
                new CompletedAchievement(DateTime.Now, achievement);

            CompletedAchievements.Add(completedAchiemevent);
        }

        public IReadOnlyList<CompletedAchievement> GetAchievements()
        {
            return CompletedAchievements.ToList();
        }
    }
}