using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        //•	Name: string
        //•	Capacity: int
        //•	LandingStrip - double
        private List<Drone> drones;
        private string name;
        private int capacity;
        private double landingStrip;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.name = name;
            this.capacity = capacity;
            this.landingStrip = landingStrip;
            drones = new List<Drone>();
        }

        public int Count { get { return drones.Count; } }

        public List<Drone> Drones
        {
            get { return drones; }
            set { drones = value; }
        }

        public double LandingStrip
        {
            get { return landingStrip; }
            set { landingStrip = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        //•	string AddDrone(Drone drone) - adds a drone to the drone's collection
        //if there is room for it. Before adding a drone, check:
        //•	If the name or brand are null or empty.
        //•	If the range is NOT between 5-15 kilometers.
        //If the name, brand, or range properties are not valid,
        //return: "Invalid drone.".
        //If the airfield is full (there is no room for more drones), return "Airfield is full.".
        //Otherwise, return: "Successfully added {droneName} to the airfield."

        public string AddDrone(Drone drone)
        {
            if (Capacity == Count)
            {
                return "Airfield is full.";
            }
            if (string.IsNullOrEmpty(drone.Name) 
                || string.IsNullOrEmpty(drone.Brand)
                || drone.Range < 5 
                || drone.Range >15)
            {
                return "Invalid drone.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        //•	bool RemoveDrone(string name) - removes a drone by given name,
        //if such exists return true, otherwise false.

        public bool RemoveDrone(string name) 
        { 
            var drone = Drones.Where(x=>x.Name==name).FirstOrDefault();
            if (drone!=default)
            {
                Drones.Remove(drone);
                return true;
            }
            return false;
        }


        //•	int RemoveDroneByBrand(string brand) - removes all drones by the given brand,
        //if such exists, return how many drones were removed, otherwise 0.

        public int RemoveDroneByBrand(string brand)
        {
            return Drones.RemoveAll(x=>x.Brand==brand);
        }

        //•	Drone FlyDrone(string name) method – fly(set its available property to false without removing
        //it from the collection) the drone with the given name if exists.As a result return the drone,
        //or null if does not exist.

        public Drone FlyDrone(string name)
        {
            var drone = Drones.Where(x => x.Name == name).FirstOrDefault();
            if (drone != default)
            {
                drone.Available = false;
                
            }
            return drone;
        }


        //•	List<Drone> FlyDronesByRange(int range) method - fly and
        //returns all drones which have a range equal or bigger to the given.
        //Return a list of all drones which have been flown.The range will always be valid.

        public List<Drone> FlyDronesByRange(int range)
        {
            var dronesFly = Drones.Where(x => x.Range >= range).ToList();
            foreach (var drone in dronesFly)
            {
                FlyDrone(drone.Name);
            }
            return dronesFly;
        }


        //•	Report() - returns information about the airfield and drones
        //which are not in flight in the following format:	
        //o   "Drones available at {airfieldName}:
        //{ Drone1}
        //{Drone2
        //    }
        //    (…)"

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {Name}:");

            foreach (var drone  in Drones.Where(x=>x.Available==true))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().Trim();
        }



    }
}
