using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static ArenaGame.GameEngine;

namespace ArenaGame.Weapons
{
    public class Mace : ISpecialWeapon
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

        public void CalculateDamages(Hero attacker, Hero defender, WeaponEffectNotify weaponEffect)
        {
            if (attacker.Health < 40)
            {
                double reducedArmor = defender.Armor * 0.30;
                attacker.Armor += reducedArmor;
                defender.Armor -= reducedArmor;
                weaponEffect?.Invoke(attacker, defender);
            }
        }
    }
}
