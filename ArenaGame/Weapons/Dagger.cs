using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Dagger : IWeapon
    {
        public string Name { get; set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }
        public bool HasSpecialAbilities { get; private set; }
        public SpecialAbilities SpecialAbilities { get; private set; } = SpecialAbilities.None;

        public Dagger(string name, bool hasSpecialAbilities)
        {
            Name = name;
            AttackDamage = 30;
            BlockingPower = 1;
            HasSpecialAbilities = hasSpecialAbilities;
            if (HasSpecialAbilities)
            {
                SpecialAbilities = SpecialAbilities.RedudeArmor;
                Name = "Armorbreaker Dagger";
            }
        }
    }
}
