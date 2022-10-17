using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {

        private List<Animal> animals = new List<Animal>();
        private string name;
        private int capacity;


        public Zoo(string name, int capacity)
        {
            List<Animal> Animals = new List<Animal>();
            this.Name = name;
            this.Capacity = capacity;
        }



        public List<Animal> Animals
        {
            get { return animals; }
            set { animals = value; }
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


        //•	string AddAnimal(Animal animal) –  adds an Animal to the animals' collection if there is room for it.
        //Before adding an animal, check:
        //	If the animal species is null or whitespace, return "Invalid animal species." ----
        //	If the animal’s diet is different from "herbivore" or "carnivore", return "Invalid animal diet."
        //	If the zoo is full(there is no room for more animals), return "The zoo is full."
        //	Otherwise, return: "Successfully added {animal species} to the zoo."
        public string AddAnimal(Animal animal)
        {


            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Capacity <= Animals.Count)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        //•	int RemoveAnimals(string species) – removes all animals by given species, as a result,
        //return the count of the animals which were removed.
        public int RemoveAnimals(string species)
        {
            int removedAnimals = Animals.RemoveAll(x => x.Species == species);
            return removedAnimals;
        }

        //•	List<Animal> GetAnimalsByDiet(string diet) – search and returns a list of animals by given diet.
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animals = this.Animals.Where(x => x.Diet == diet).ToList();
            return animals;
        }

        //•	Animal GetAnimalByWeight(double weight) – return the first animal, with the given weight.
        public Animal GetAnimalByWeight(double weight)
        {
            var animal = this.Animals.FirstOrDefault(x => x.Weight == weight);

            return animal;
        }

        //•	string GetAnimalCountByLength(double minimumLength, double maximumLength) –
        //search of all animals which has a length between the given(inclusively).
        //As a result return the following format:
        //"There are {count} animals with a length between {minimum length} and {maximum length} meters."
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var animalsByLenght = this.Animals.Where(x => x.Length >= minimumLength && x.Length <= maximumLength).ToList();

            return $"There are {animalsByLenght.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
