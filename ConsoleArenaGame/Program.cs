using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;

namespace ConsoleArenaGame
{
    class Program
    {
        static void ConsoleNotification(GameEngine.NotificationArgs args)
        {

            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.");
            Console.WriteLine($"Attacker: {args.Attacker} ");
            Console.WriteLine($"Defender: {args.Defender} ");
            Console.WriteLine(new string('.', 40));
        }
        public static void ReducingPowerWeapon(Hero attacker, double reducedArmor)
        {
            Console.WriteLine($"{attacker.Name} took {reducedArmor}");
        }

        public static void GameBeginNotifications(Hero heroA, Hero heroB)
        {
            Console.WriteLine($"{heroA.Name} choose " + 
               ( heroA.Weapon.SpecialAbilities != SpecialAbilities.None ? $"special weapon: " +
               $"{heroA.Weapon.Name}" : $"normal weapon : {heroA.Weapon.Name}")
                );
            Console.WriteLine($"{heroB.Name} choose " + 
               (heroA.Weapon.SpecialAbilities != SpecialAbilities.None ? $"special weapon : " +
               $"{heroB.Weapon.Name}" : $"normal weapon : {heroA.Weapon.Name}")
                );
        }


        /*public static void WeaponTypes(ISpecialWeapon weapon)
        {
            if (weapon is Dagger)
            {
                Console.WriteLine($"Dagger : {weapon.SpecialAbilities} or normal dagger");
            }
            else if (weapon is Sword)
            {
                Console.WriteLine($"Sword : {weapon.AbilityName} or normal sword");
            }
        }*/
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine()
            {
                HeroA = new Knight("Knight", 10, 20, new Sword("Sword")),
                HeroB = new Assassin("Assassin", 10, 5, new Blade(2)),
                //WeaponReducingPowers = ReducingPowerWeapon,
                NotificationsCallBack = ConsoleNotification,
                OnStarGame = GameBeginNotifications

            };

            gameEngine.Fight();

            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner}");
        }
    }
}