namespace FightingArena
{
    using System.Linq;

    using System.Collections.Generic;

    public class Arena
    {
        private List<Gladiator> gladiators;
        public Arena(string name)
        {
            Name = name;
            this.gladiators = new List<Gladiator>();
        }
        public string Name { get; set; }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }
        public void Remove(string name)
        {
            var currentGladiator = gladiators.FirstOrDefault(x => x.Name == name);
            gladiators.Remove(currentGladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return gladiators
                .OrderByDescending(x => x.GetStatPower())
                .First();
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return gladiators
                .OrderByDescending(x => x.GetWeaponPower())
                .First();
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return gladiators
                .OrderByDescending(x => x.GetTotalPower())
                .First();
        }

        public int Count
        {
            get
            {
                return gladiators.Count;
            }

        }

        public override string ToString()
        {
            return $"[{Name}] - [{Count}] gladiators are participating".ToString();
        }
    }
}
