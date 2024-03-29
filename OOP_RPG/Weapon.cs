namespace OOP_RPG
{
    public class Weapon : IWeapon
    {
        public string Name { get; }
        public int Strength { get; }
        public int Price { get; }
        public int ResellValue { get; }

        public Weapon(string name, int strength, int price, int resellValue)
        {
            Name = name;
            Strength = strength;
            Price = price;
            ResellValue = resellValue;
        }

        public string GetDescription(bool useResellValue = false)
        {
            return $"Name: {Name} - Str: {Strength} " +
                $"- Price: {(useResellValue ? ResellValue : Price)}";
        }
    }
}