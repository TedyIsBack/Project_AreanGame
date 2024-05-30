using static ArenaGame.GameEngine;

namespace ArenaGame.Weapons
{
    public class Blade : ISpecialWeapon
    {
        private Random rn { get; } = new Random();
        public SpecialAbilities SpecialAbilities { get; } = SpecialAbilities.ReduceStrength;

        public string Name { get; }

        public double AttackDamage { get; }

        public double BlockingPower { get; }
        public int Level { get; }
        public delegate void WeaponUsageDelegate(Hero attacker, Hero defender);

        public Blade(int level)
        {
            Name = "Cursed Blade";
            Level = level;
            if (level > 5)
                Level = 5;
            AttackDamage = 40 + (rn.Next(3) * Level);
            BlockingPower = 10;
        }

        public void CalculateDamages(Hero attacker, Hero defender, WeaponEffectNotify weaponEffect)
        {
            if (attacker.Armor < 5)
            {
                double reducedStrength = defender.Strength * 0.15;
                attacker.Strength += reducedStrength;
                defender.Strength -= reducedStrength;
                weaponEffect?.Invoke(attacker, defender);
            }
        }
    }
}
