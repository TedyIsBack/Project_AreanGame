using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Mace: ISpecialWeapon
    {
        public SpecialAbilities SpecialAbilities { get; } = SpecialAbilities.ReduceArmor;

        public string Name { get; }

        public double AttackDamage { get; }

        public double BlockingPower { get; }
        public int Level { get; }

        public Mace(int level)
        {
            
            Name = "Arcade Wrecking Mace";
            Level = level;
            if (level > 3)
                Level = 3;
            AttackDamage = 50 + 2 * level;
            BlockingPower = 5;
        }
    }
}
