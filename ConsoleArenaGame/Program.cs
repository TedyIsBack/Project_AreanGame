using ArenaGame;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace ConsoleArenaGame
{
    class Program
    {
        static void Main(string[] args)
        {


            GameEngine gameEngine = new GameEngine()
            {
                HeroA = new Ninja("Ninja", 10, 10, new Naginata(2)),
                HeroB = new Assassin("Assassin", 10, 5, new Blade(2)),
                WeaponReducingPowers = ReducingPower,
                NotificationsCallBack = ConsoleNotification,
                OnStarGame = GameBeginNotifications

            };

            gameEngine.Fight();
            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner}");
        }

        static void ConsoleNotification(GameEngine.NotificationArgs args)
        {
            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.");
            Console.WriteLine($"Attacker: {args.Attacker} ");
            Console.WriteLine($"Defender: {args.Defender} ");
            Console.WriteLine("\n ------------------------------ \n");
        }
        public static void ReducingPower(Hero attacker, Hero defender, string power)
        {
            string str = "";

            switch (attacker.Weapon.SpecialAbilities)
            {
                case SpecialAbilities.None:
                    break;
                case SpecialAbilities.DisableEnemyWeapon:
                    str = "disable enemy's weapon";
                    break;
                case SpecialAbilities.ReduceStrength:
                    str = "reduce enemy's strength with 15%";
                    break;
                case SpecialAbilities.ReduceArmor:
                    str = "reduce enemy's armor with 30%";
                    break;
                default:
                    break;
            }

            Console.WriteLine($"[ACTIVATED SPECIAL WEAPON] {attacker.Weapon.Name} : {str}");

            Console.WriteLine($"    >>> Attacker {power}: " +
                $"{(power == "strength" ?attacker.Strength : attacker.Health):F0} " +
                $"\n    >>> Defender {power}: " +
                $"{(power == "strength" ?  defender.Strength : defender.Health):F0}");

            Console.WriteLine();
        }
      
        public static void GameBeginNotifications(Hero heroA, Hero heroB)
        {

            Console.WriteLine($"{heroA.Name} chose " +
               (heroA.Weapon.SpecialAbilities != SpecialAbilities.None ? $"special weapon: " +
               $"{heroA.Weapon.Name}" : $"normal weapon : {heroA.Weapon.Name}")
                );
            Console.WriteLine($"{heroB.Name} chose " +
               (heroB.Weapon.SpecialAbilities != SpecialAbilities.None ? $"special weapon : " +
               $"{heroB.Weapon.Name}" : $"normal weapon : {heroB.Weapon.Name}")
                );
            Console.WriteLine("\n---- THE GAME STARTED ----\n");
        }
    }

}