using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArenaGame.GameEngine;

namespace ArenaGame.Weapons
{
    public class Naginata : ISpecialWeapon
    {
        public SpecialAbilities SpecialAbilities { get; } = SpecialAbilities.DisableEnemyWeapon;
        public string Name { get; }
        public double AttackDamage { get; }
        public double BlockingPower { get; }
        public int Level { get; }
        private int count = 0;//for a one-time message when the attacker take enemy's weapon

        public Naginata(int level)
        {
            Name = "Dread Disarmer Naginata";
            Level = level;
            if (level > 3)
                Level = 3;
            AttackDamage = 30 + Math.Pow(level, 3);
            BlockingPower = 10;
        }

        public void CalculateDamages(Hero attacker, Hero defender, WeaponEffectNotify weaponEffect)
        {
            if (attacker.Health < 30 && count < 1)
            {
                count += 1;
                defender.Weapon = null;
                weaponEffect?.Invoke(attacker, defender);
            }
        }
    }
}
