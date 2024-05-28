using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Gladiator : Hero
    {

        public Gladiator(string name, double armor, double strenght, IWeapon? weapon) : base(name, armor, strenght, weapon)
        {
        }
        public override double Attack()
        {
            if(Health < 20)
            {
                return base.Attack() * 2;
            }
            return base.Attack();
           
        }
       
    }
}
