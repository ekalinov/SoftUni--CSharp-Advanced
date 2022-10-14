using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    internal class Race
    {
        
         

        private List<Car> participants = new List<Car>();

        

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;

        }

        public List<Car> Participants
        {
            get { return participants; }
            set { participants = value; }
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count { get { return Participants.Count; } }


        //•	Method Add(Car car) - adds the entity if there isn't a Car with the same License plate and
        //if there is enough space in terms of race capacity and if the car meets the maximum horse power requirment of the race.

        public void Add(Car car)
        {
          

            if (!Participants.Contains(car) && Capacity > Count && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
            

        }

        //•	Method Remove(string licensePlate) - removes a Car from the race with the given License plate,
        //if such exists and returns bool if the deletion is successful.
        public bool Remove(string licensePlate)
        {
            if (Participants.Any())
            {
                var thisCar = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
                if (Participants.Contains(thisCar))
                {
                    Participants.Remove(thisCar);
                    return true;
                }
            }
            return false;

        }

        //•	Method FindParticipant(string licensePlate) - returns a Car with the given License plate.If it doesn't exist, return null.

        public Car FindParticipant(string licensePlate)
        {
            if (Participants.Any())
            {
                var thisCar = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
                if (Participants.Contains(thisCar))
                {
                    return thisCar;
                }
            }
            return null;

        }

        //•	Method GetMostPowerfulCar() – returns the Car with most HorsePower.If there are no Cars in the Race, method should return null.
        public Car GetMostPowerfulCar()
        {

            if (Participants.Any())
            { 
            var thisCar = Participants.OrderByDescending(x => x.HorsePower).First();
                return thisCar;
            }

            return null;

        }


        //•	Method Report() - returns information about the Race and the Cars participating it in the following format:
        //"Race: {Name} - Type: {Type} (Laps: {Laps})
        //{Car1}
        //{Car2}
        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            if (Participants.Any())
            {
                foreach (var car in Participants)
                {
                    sb.AppendLine(car.ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}
