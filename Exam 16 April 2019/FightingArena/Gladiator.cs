namespace FightingArena
{
    using System.Text;
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }

        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            return GetWeaponPower() + GetStatPower();
        }

        public int GetWeaponPower()
        {
            return Weapon.Sharpness + Weapon.Size + Weapon.Solidity;
        }

        public int GetStatPower()
        {
            return Stat.Agility + Stat.Flexibility + Stat.Intelligence + Stat.Skills + Stat.Strength;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Name} - {GetTotalPower()}");
            stringBuilder.AppendLine($"  Weapon Power: {GetWeaponPower()}");
            stringBuilder.Append($"  Weapon Power: {GetStatPower()}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
