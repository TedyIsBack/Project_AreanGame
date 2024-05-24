using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
  public class CursedBlade : IWeapon
  {
    public string Name { get; set; }
    public double AttackDamage { get;private set; }
    public double BlockingPower { get;private set; }
    public bool HasSpecialAbilities { get; private set; }
    public SpecialAbilities SpecialAbilities { get; private set; } = SpecialAbilities.None;

    public CursedBlade(string name,bool hasSpecialAbilities)
    {
      Name = name;
      AttackDamage = 0;
      BlockingPower = 0;
      HasSpecialAbilities = hasSpecialAbilities ;
    }

      
    }
}
