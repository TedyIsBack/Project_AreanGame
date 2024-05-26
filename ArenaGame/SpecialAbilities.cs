using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
  public enum SpecialAbilities 
    {

    None,
        [Description("disable enemy's weapon")]
    DisableEnemyWeapon ,
        [Description("reduce enemy's strength with 15%")]
    ReduceStrength,
        [Description("reduce enemy's armor with 30%")]
        ReduceArmor
    }
}