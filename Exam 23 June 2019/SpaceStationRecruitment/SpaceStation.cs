namespace SpaceStationRecruitment
{
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        private SpaceStation()
        {
            astronauts = new List<Astronaut>();
        }
        public SpaceStation(string name, int capacity)
            : this()
        {
            Name = name;
            Capacity = capacity;

        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return astronauts.Count;
            }

        }

        public void Add(Astronaut astronaut)
        {
            if (astronauts.Count < Capacity)
            {
                astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            var currentAstronaut = astronauts
                .FirstOrDefault(a => a.Name == name);

            if (currentAstronaut == null)
            {
                return false;

            }
            astronauts.Remove(currentAstronaut);
            return true;
        }

        public Astronaut GetOldestAstronaut()
        {
            var currentAstronaut = astronauts.OrderByDescending(x => x.Age).FirstOrDefault();
            return currentAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            var currentAstronaut = astronauts
                .FirstOrDefault(a => a.Name == name);
            return currentAstronaut;
        }

        public string Report()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Astronauts working at Space Station {Name}");

            foreach (var astronaut in astronauts)
            {
                stringBuilder.AppendLine(astronaut.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
