using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {

        //        •	Name: string
        //•	NeededRenovators: int
        //•	Project: string

        private Dictionary<string ,Renovator> renovators = new Dictionary<string, Renovator>();

        private string name;

        private int neededRenovators;

        private string project;



        public Catalog(string name, int neededRenovators, string project)
        {
            this.name = name;
            this.neededRenovators = neededRenovators;
            this.project = project;


        }
        // •	Getter Count - returns the count of the renovators in the catalog.

        public int Count { get => renovators.Count; }

        public Dictionary<string, Renovator> Renovators
        {
            get { return renovators; }
            set { renovators = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }

        public string Project
        {
            get { return project; }
            set { project = value; }
        }


//•	string AddRenovator(Renovator renovator) - adds a renovator to the catalog's collection, if renovators are still needed.
//Before adding a renovator, check:
//o If the name or specialty are null or empty, return "Invalid renovator's information.".
//o If renovators are no more needed, return "Renovators are no more needed.".
//Renovators are needed when the count of the added renovators is less than the NeededRenovators property of the Catalog.
//o   If the rate is above 350 BGN, return "Invalid renovator's rate.".
//o Otherwise, return: "Successfully added {renovatorName} to the 


        public string AddRenovator(Renovator renovator)
        {

            if (renovator.Name == null || renovator.Type==null)
            {
                return "Invalid renovator's information.";
            }

            if (renovators.Count>=neededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate>350)
            {
                return "Invalid renovator's rate.";
            }


            renovators.Add(renovator.Name,renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (renovators.ContainsKey(name))
            {
                renovators.Remove(name);
                return true;
            }
            return false;
        }

        //•	int RemoveRenovatorBySpecialty(string type) - removes all renovators by the given specialty.
        //o If such exist(s), returns the count of the removed renovators;
        //o Otherwise, returns 0.
        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedRenovators = renovators.Where(r => r.Value.Type == type).Count();

            renovators = renovators.Where(r => r.Value.Type != type).ToDictionary(x=>x.Key, x=>x.Value);

            return removedRenovators;
        }

        //•	Renovator HireRenovator(string name) method – hire (set their available
        //property to true without removing them from the collection) the renovator
        //with the given name, if they exist. As a result, return the renovator, or null,
        //if they don't exist.
        public Renovator HireRenovator(string name)
        {
            if (renovators.ContainsKey(name))
            {
                renovators[name].Hired = true;
                return renovators[name];
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List < Renovator > workedRenovators = new List <Renovator>();
            foreach (var renovator in renovators)
            {
                if (renovator.Value.Days>=days)
                {
                    workedRenovators.Add(renovator.Value);
                }

            }

            return workedRenovators;
        }

        public string Report()
        {
        
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {project}:");
            foreach (var renovator in renovators.Where(r=>r.Value.Hired==false))
            {
                sb.AppendLine(renovator.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
