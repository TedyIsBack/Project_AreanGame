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
        public static void ReducingPower(Hero attacker, Hero defender)
        {
            string str = "";
            string propertyType = "";
            double attackerProp = 0,
                defenderProp = 0;

            switch (attacker.Weapon.SpecialAbilities)
            {
                case SpecialAbilities.None:
                    break;
                case SpecialAbilities.DisableEnemyWeapon:
                    str = "disable enemy's weapon";
                    propertyType = "health";
                    attackerProp = attacker.Health;
                    defenderProp = defender.Health;
                    break;
                case SpecialAbilities.ReduceStrength:
                    str = "reduce enemy's strength with 15%";
                    propertyType = "strength";
                    attackerProp = attacker.Strength;
                    defenderProp = defender.Strength;
                    break;
                case SpecialAbilities.ReduceArmor:
                    str = "reduce enemy's armor with 30%";
                    propertyType = "armor";
                    attackerProp = attacker.Armor;
                    defenderProp = defender.Armor;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"[ACTIVATED SPECIAL WEAPON] {attacker.Weapon.Name} : {str}");

            Console.WriteLine($"    >>> Attacker {propertyType}: " +
                $"{attackerProp:F1} " +
                $"\n    >>> Defender {propertyType}: " +
                $"{defenderProp:F1}");

            Console.WriteLine();
        }


        static void ConsoleNotification(GameEngine.NotificationArgs args)
        {
            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.");
            Console.WriteLine($"Attacker: {args.Attacker} ");
            Console.WriteLine($"Defender: {args.Defender} ");
            Console.WriteLine("\n ------------------------------ \n");
        }
        static void Main(string[] args)
        {

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = new Ninja("Ninja", 10, 8, new Naginata(0)),
                HeroB = new Gladiator("Gladiator", 3, 5, new Mace(1)),
                WeaponEffects = ReducingPower,
                NotificationsCallBack = ConsoleNotification,
            };

            gameEngine.Fight();
            Console.WriteLine();
            Console.WriteLine($"And the winner is {gameEngine.Winner}");
        }
    }
}