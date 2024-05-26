 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    internal class Pistol : ISpecialWeapon
    {
        public SpecialAbilities SpecialAbilities { get; } = SpecialAbilities.DisableEnemyWeapon;

        public string Name { get; }

        public double AttackDamage { get; }

        public double BlockingPower { get; }

        public int Level { get; }

        public Pistol(int level)
        {
            Name = "Soul Sapper";
            Level = level;
            if (level > 3)
                Level = 3;
            AttackDamage = 30 + Math.Pow(level, 2) / 2;
            BlockingPower = 10;
        }
    }
}
