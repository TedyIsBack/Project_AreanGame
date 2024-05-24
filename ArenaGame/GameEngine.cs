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

        private Random random = new Random();
        public Hero HeroA { get; set; }
        public Hero HeroB { get; set; }
        public Hero Winner { get; set; }

        public GameNotifications? NotificationsCallBack { get; set; }
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
            

            while (attacker.IsAlive)
            {
                //-----------------------------new code-----------------------------
                if (attacker.Weapon != null && attacker.Weapon.HasSpecialAbilities)
                {
                    SpecialPower(attacker, defender);
                }
                //-----------------------------------------------------------------
                double attack = attacker.Attack();//с каква сила герой 1 атакува
                double actualDamage = defender.Defend(attack);// с каква сила герой 2 отблъсква атаката на герой 1


                if (NotificationsCallBack != null)
                {

                    NotificationsCallBack(new NotificationArgs()
                    {
                        Attacker = attacker,
                        Defender = defender,
                        Attack = attack,
                        Damage = actualDamage
                    }) ;
                }

                Hero tempHero = attacker;
                attacker = defender;
                defender = tempHero;
                
            }
            Winner = defender;
        }

        public void SpecialPower( Hero attacker, Hero defender)
        {
            
            SpecialAbilities specialAbilities = attacker.Weapon.SpecialAbilities;
            switch (specialAbilities)
            {
                case SpecialAbilities.RedudeArmor:
                    if (attacker.Health < 60)
                    {
                        double reducedArmor = defender.Armor * 0.30;
                        attacker.Armor += reducedArmor;
                        defender.Armor -= reducedArmor;
                    }
                    break;
                case SpecialAbilities.DisableEnemeyWeapon:
                    if (attacker.Health < 30)
                    { defender.Weapon = null; }
                        break;
                case SpecialAbilities.TotalDamage:
                    break;
                default: break;
            }
          

        }
    }
}
