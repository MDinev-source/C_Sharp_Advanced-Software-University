namespace SpaceStationRecruitment
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var spaceStation = new SpaceStation("Apolo", 10);
            var astronaut = new Astronaut("Stephen", 40, "Bulgaria");
            Console.WriteLine(astronaut);
            spaceStation.Add(astronaut);
            spaceStation.Remove("Astronaut name");
            var secondAstronaut = new Astronaut("Mark", 34, "UK");
            spaceStation.Add(secondAstronaut);

            var oldestAstronaut = spaceStation.GetOldestAstronaut();
            var astronautStephen = spaceStation.GetAstronaut("Stephen");
            Console.WriteLine(oldestAstronaut);
            Console.WriteLine(astronautStephen);

            Console.WriteLine(spaceStation.Count);
            Console.WriteLine(spaceStation.Report());
        }
    }
}
