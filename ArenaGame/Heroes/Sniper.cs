using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
  internal class Sniper : Hero

  {
    public Sniper(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
    {
    }

    
  }
}
