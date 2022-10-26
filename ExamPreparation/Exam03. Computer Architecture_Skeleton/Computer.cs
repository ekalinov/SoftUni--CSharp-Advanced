using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;
        private string model;
        private int capacity;

        public Computer(string model, int capacity)
        {
            this.multiprocessor = new List<CPU>();
            this.model = model;
            this.capacity = capacity;
        }

        public List<CPU> Multiprocessor { get => multiprocessor; set => multiprocessor = value; }
        public string Model { get => model; set => model = value; }

        public int Capacity { get => capacity; set => capacity = value; }

        //•	Getter Count - returns the number of CPUs
        public int Count { get => multiprocessor.Count; }





        //•	Method Add(CPU cpu) - adds an entity to the multiprocessor
        //if there is room for it.If there is no room for another CPU, skip the command
        public void Add(CPU cpu)
        {
            if (capacity>Count)
            {
                multiprocessor.Add(cpu);
            }
        }

        //•	Method Remove(string brand) - removes a CPU by a given brand.If such exists,
        //returns true, otherwise, returns false.
        public bool Remove(string brand)
        {
            var cpu = multiprocessor.Where(x => x.Brand == brand).FirstOrDefault();
            if (cpu!=default)
            {
                multiprocessor.Remove(cpu);
                return true;
            }
            return false;
        }

        //•	Method MostPowerful() - returns the most powerful CPU(the CPU with the highest frequency)

        public CPU MostPowerful()
        {
            var cpu = multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
            
            return cpu;
        }
        //•	Method GetCPU(string brand) – returns the CPU with the given brand.If there is no CPU,
        //meeting the requirements, return null

        public CPU GetCPU(string brand)
        {
            var cpu = multiprocessor.Where(x => x.Brand==brand).FirstOrDefault();

            return cpu;
        }
        //•	Method Report() - returns a String in the following format:	
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {model}:");
            foreach (var cpu in multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().Trim();
        }
        //o	"CPUs in the Computer {model}:
        //{CPU1}
        //{CPU2}
        //(…)"


    }
}
