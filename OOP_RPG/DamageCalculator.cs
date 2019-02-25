using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class DamageCalculator
    {
        private Random Random { get; }

        public DamageCalculator()
        {
            Random = new Random();
        }

        public int CalculateDamage(int baseDamage)
        {
            var minDamage = Convert.ToInt32(baseDamage * 0.5);
            var maxDamage = Convert.ToInt32(baseDamage * 1.5);
            var finalDamage = Random.Next(minDamage, maxDamage + 1);

            if (finalDamage <= 0)
            {
                finalDamage = 1;
            }

            return finalDamage;
        }
    }
}
