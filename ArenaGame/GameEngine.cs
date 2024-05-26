using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class GameEngine
    {
        public class NotificationArgs
        {
            public Hero Attacker { get; set; }
            public Hero Defender { get; set; }
            public double Attack { get; set; }
            public double Damage { get; set; }
           
        }

        public delegate void GameNotifications(NotificationArgs args);
        public delegate void WeaponDelegate(Hero hero, double reducedArmor);
        public delegate void GameStartInfo(Hero heroA, Hero heroB);
        private Random random = new Random();
        public Hero HeroA { get; set; }
        public Hero HeroB { get; set; }
        public Hero Winner { get; set; }
        public GameNotifications? NotificationsCallBack { get; set; }
        public WeaponDelegate? WeaponReducingPowers { get; set; }
        public GameStartInfo? OnStarGame { get; set; }

        public void Fight()
        {
            Hero attacker;
            Hero defender;

            double probability = random.NextDouble();
            if (probability < 0.5)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else
            {
                attacker = HeroB;
                defender = HeroA;
            }

            OnStarGame?.Invoke(attacker, defender);

            while (attacker.IsAlive)
            {
                //----------------------------------------------------------------
                if (attacker.Weapon != null && attacker.Weapon.SpecialAbilities != SpecialAbilities.None)
                {
                    SpecialPower(attacker, defender);
                }
                //-----------------------------------------------------------------
                double attack = attacker.Attack();
                double actualDamage = defender.Defend(attack);

                if (NotificationsCallBack != null)
                {

                    NotificationsCallBack(new NotificationArgs()
                    {
                        Attacker = attacker,
                        Defender = defender,
                        Attack = attack,
                        Damage = actualDamage
                    });
                }


                Hero tempHero = attacker;
                attacker = defender;
                defender = tempHero;
                

            }
            Winner = defender;
        }

        public  void SpecialPower( Hero attacker, Hero defender)
        {
            SpecialAbilities sp = attacker.Weapon.SpecialAbilities;
            switch (sp)
            {
                case SpecialAbilities.ReduceArmor:
                    if (attacker.Health < 40)
                    {
                        double reducedArmor = defender.Armor * 0.30;
                        attacker.Armor += reducedArmor;
                        defender.Armor -= reducedArmor;
                    }
                    break;

                case SpecialAbilities.DisableEnemyWeapon:
                    if (attacker.Health < 30)
                        defender.Weapon = null; 
                    break;

                case SpecialAbilities.ReduceStrength:
                    if (attacker.Armor < 5)
                    {
                        double reducedStrength = defender.Strength * 0.15;
                        attacker.Strength += reducedStrength;
                        defender.Strength -= reducedStrength;
                    }
                        break;

                default: break;
            }
        }
       
    }
}
