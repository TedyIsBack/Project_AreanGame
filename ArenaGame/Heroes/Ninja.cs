using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Ninja : Hero
    {
        private Random rn = new Random();
        public Ninja(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
        {
        }

        public override double Defend(double damage)
        {
            int speed = rn.Next(20, 51);
            double speedFactor = speed / 100;
            double realDamage = base.Defend(damage);

            if (realDamage < speedFactor)
                return 0;

            realDamage -= speedFactor;
            return realDamage;
        }
    }
}
