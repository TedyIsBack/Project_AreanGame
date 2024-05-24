using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public interface IWeapon
    {
        public SpecialAbilities SpecialAbilities { get; }
        string Name { get; set; }
        double AttackDamage { get; } 
        double BlockingPower { get; }
        bool HasSpecialAbilities { get; }

  }
}
