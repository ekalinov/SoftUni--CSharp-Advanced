using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    internal class SkiRental
    {
        private List<Ski> data = new List<Ski>();
        private string name;

        private int capacity;


        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }



        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }

        }

        public int Count { get {return data.Count;} }

        //Field data – collection that holds added Skis


        //Method Add(Ski ski) – adds an entity to the data if there is an empty slot for the Ski.
        public void Add(Ski ski)
        {
            if (capacity > data.Count)
            {
                data.Add(ski);
            }
        }

        //Method Remove(string manufacturer, string model) – removes the Ski by given manufacturer
        //and model, if such exists, and returns bool.

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (ski != default)
            {
                data.Remove(ski);
                return true;
            }

            return false;
        }

        //Method GetNewestSki() – returns the newest Ski (by year) or null if there are no Skis stored.

        public Ski GetNewestSki()
        {

            if (data.Any())
            {
                Ski ski = data.OrderByDescending(x => x.Year).First();
                return ski;
            }

            return null;
        }

        //Method GetSki(string manufacturer, string model) – returns the Ski with the given
        //manufacturer and model or null if there is no such Ski.
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (ski != default)
            {
                return ski;
            }

            return null;
        }

        //Getter Count – returns the number of Skis.


        //GetStatistics() – returns a string in the following format:
        //"The skis stored in {Ski Rental Name}:
        //{ Ski1}
        //{Ski2
        //    }
        //    (…)"

        public string GetStatistics()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().Trim();
        }












    }
}
