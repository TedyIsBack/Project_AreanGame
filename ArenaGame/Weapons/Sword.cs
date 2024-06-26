﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArenaGame.GameEngine;

namespace ArenaGame.Weapons
{
    public class Sword : IWeapon
    {
        public string Name { get; private set; }
        public double AttackDamage { get; private set; }
        public double BlockingPower { get; private set; }
        public SpecialAbilities SpecialAbilities { get; } = SpecialAbilities.None;

        public Sword(string name)
        {
            Name = name;
            AttackDamage = 20;
            BlockingPower = 10;

        }

        public void CalculateDamages(Hero attacker, Hero defender, WeaponEffectNotify wrp)
        {
        }
    }
}
