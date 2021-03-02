using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

    
        public int Count
        {
            get
            { 
                return data.Count;
            }
           
        }

        public void Add(Car car)
        {
            if (data.Count<Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove (string manufacturer, string model)
        {
            if (data.Any(x=>x.Manufacturer==manufacturer&&x.Model==model))
            {
                var currentCar = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
                data.Remove(currentCar);
                return true;
            }
           
                return false;
           
        }

        public Car GetLatestCar()
        {
            if (data.Count > 0)
            {
                var latestCar = data.OrderByDescending(x => x.Year).First();

                return latestCar;
            }
            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            if (data.Any(x => x.Manufacturer == manufacturer && x.Model == model))
            {
                var currentCar = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

                return currentCar;
            }
            return null;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
