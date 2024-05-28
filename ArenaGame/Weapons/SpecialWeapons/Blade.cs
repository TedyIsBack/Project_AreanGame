namespace ArenaGame.Weapons
{
    public class Blade : ISpecialWeapon
    {
        private Random rn { get; } = new Random();
        public SpecialAbilities SpecialAbilities { get; } = SpecialAbilities.ReduceStrength;

        public string Name { get; }

        public double AttackDamage { get; }

        public double BlockingPower { get; }
        public int Level { get; }

        public Blade(int level)
        {
            Name = "Cursed Blade";//Spirit
            Level = level;
            if(level > 5)
                Level = 5;
            AttackDamage = 40 + (rn.Next(3) * Level);
            BlockingPower = 10;
        }
    }
}
