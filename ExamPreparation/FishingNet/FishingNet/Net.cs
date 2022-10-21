using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish=new List<Fish>();

        public Net(string material, int capacity)
        {
            
            Material = material;
            Capacity = capacity;
        }

        public List<Fish> Fish
        {
            get { return fish; }
            
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Fish.Count; } }
        //•	Material: string
        //•	Capacity: int


        //•	string AddFish(Fish fish) - adds a Fish to the fish's collection if there is room for it.
        //Before adding a fish, check:
        //•	If the fish type is null or whitespace.
        //•	If the fish’s length or weight is zero or less.
        //If the fish type, length, or weight properties are not valid, return: "Invalid fish.".
        //If the net is full (there is no room for more fish), return "Fishing net is full.".
        //Otherwise, return: "Successfully added {fishType} to the fishing net."
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";
            }
            else if (this.Count >= this.Capacity)
            {
                return "Fishing net is full.";
            }
            else 
            { 
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }

        //•	bool ReleaseFish(double weight) – removes a fish by given weight,
        //if such exists return true, otherwise false.
        public bool ReleaseFish(double weight)
        {
            var fish = Fish.Where(x => x.Weight == weight).FirstOrDefault();
            if (fish != null)
            {
                Fish.Remove(fish);
                return true;
            }
            return false;

        }



        //•	Fish GetFish(string fishType) – search and returns a fish by given fish type.
        public Fish GetFish(string fishType)
        {
            Fish fish = Fish.Where(x => x.FishType == fishType).FirstOrDefault();
            return fish;
        }


        //•	Fish GetBiggestFish()– search and returns the longest fish in the collection.
        public Fish GetBiggestFish()
        {
            Fish fish = Fish.OrderByDescending(x => x.Length).First();
            return fish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (Fish currfish in Fish.OrderByDescending(f=>f.Length))
            {
                sb.AppendLine(currfish.ToString());
            }

           return sb.ToString().Trim();
        }

    }
}

