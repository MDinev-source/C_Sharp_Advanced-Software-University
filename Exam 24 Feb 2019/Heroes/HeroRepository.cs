namespace Heroes
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }
        public int Count
        {
            get { return heroes.Count; }
        }

        public void Add(Hero hero)
        {
            heroes.Add(hero);
        }
        public void Remove(string name)
        {
            if (heroes.Any(x => x.Name == name))
            {
                heroes.Remove(heroes.FirstOrDefault(x => x.Name == name));
            }
        }

        public Hero GetHeroWithHighestStrength()
        {

            Hero highestStrength = heroes
                .OrderByDescending(x => x.Item.Strength)
                .First();

            return highestStrength;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero highestAbility = heroes
                .OrderByDescending(x => x.Item.Ability)
                .First();

            return highestAbility;
        }



        public Hero GetHeroWithHighestIntelligence()
        {
            Hero highestIntelligence = heroes
                    .OrderByDescending(x => x.Item.Intelligence)
                    .First();

            return highestIntelligence;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (Hero hero in heroes)
            {
                sb.AppendLine($"{hero}");
            }

            return sb.ToString();
        }
    }
}
