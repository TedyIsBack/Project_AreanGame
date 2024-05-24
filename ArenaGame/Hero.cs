using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public abstract class Hero : IHero
    {
        protected Random random = new Random();
        public string Name { get; private set; }
        public double Health { get; private set; }
        public double Armor { get; set; }
        public double Strenght { get; set; }
        public IWeapon? Weapon { get; set; }
        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }


      

        public Hero(string name, double armor, double strenght, IWeapon? weapon)
        {
            Health = 100;

            Name = name;
            Armor = armor;
            Strenght = strenght;
            Weapon = weapon;
        }


        // returns actual damage
        public virtual double Attack()
        {
            double totalDamage = Strenght;
            if (Weapon != null)
                totalDamage += Weapon.AttackDamage;
            double coef = random.Next(80, 120 + 1);
            double realDamage = totalDamage * (coef / 100);
            return realDamage;
        }

        public virtual double Defend(double damage)
        {
            double coef = random.Next(80, 120 + 1);
            double defendPower;
            if (Weapon != null)
                defendPower = (Armor + Weapon.BlockingPower) * (coef / 100);

            defendPower = Armor * (coef / 100);
            double realDamage = damage - defendPower;
            if (realDamage < 0)
                realDamage = 0;
            Health -= realDamage;
            return realDamage;
        }

        public override string ToString()
        {
            string w = Weapon == null ? "has no weapon" : $"use {Weapon.Name}";
            return $"{Name} with health {Math.Round(Health, 2)} and armor {Armor} {w}";


        }
    }
}
