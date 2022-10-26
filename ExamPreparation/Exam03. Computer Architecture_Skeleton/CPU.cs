using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {

        //•	Brand - string
        //•	Cores - int
        //•	Frequency - double
        private string brand;
        private int cores;
        private double frequency;

        public CPU(string brand, int cores, double frequency)
        {
            this.brand = brand;
            this.cores = cores;
            this.frequency = frequency;
        }

        public string Brand { get => brand; set => brand = value; }
        public int Cores { get => cores; set => cores = value; }
        public double Frequency { get => frequency; set => frequency = value; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{brand} CPU:");
            sb.AppendLine($"Cores: {cores}");
            sb.AppendLine($"Frequency: {frequency:f1} GHz");

            return sb.ToString().Trim();

        }
    }
}
