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
        public delegate void WeaponEffect(Hero hero,Hero heroB, string power);
        public delegate void StartInfo(Hero heroA, Hero heroB);
        
        private Random random = new Random();
        public Hero HeroA { get; set; }
        public Hero HeroB { get; set; }
        public Hero Winner { get; set; }
        public GameNotifications? NotificationsCallBack { get; set; }
        public WeaponEffect WeaponReducingPowers { get; set; }
        public StartInfo? OnStarGame { get; set; }
        private int count = 0;
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
                    CalculateDamages(attacker, defender);
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

        private void CalculateDamages(Hero attacker, Hero defender)
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
                        WeaponReducingPowers?.Invoke(attacker, defender, "armor");
                    }
                    break;

                case SpecialAbilities.DisableEnemyWeapon:
                    if (attacker.Health < 30 && count < 1)
                    {
                        count++;
                        defender.Weapon = null;
                        WeaponReducingPowers?.Invoke(attacker, defender, "health");
                    }
                        break;

                case SpecialAbilities.ReduceStrength:
                    if (attacker.Armor < 5)
                    {
                        double reducedStrength = defender.Strength * 0.15;
                        attacker.Strength += reducedStrength;
                        defender.Strength -= reducedStrength;
                        WeaponReducingPowers?.Invoke(attacker,defender,"strength");
                    }
                    break;

                default: break;
            }
        }
       
    }
}
