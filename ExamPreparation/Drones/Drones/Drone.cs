﻿using System.Text;

namespace Drones
{
    public class Drone
    {


        //•	Name: string
        //•	Brand: string
        //•	Range: int
        //•	Available: boolean - true by default

        private string name;
        private string brand;
        private int range;
        private bool available;

        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Available = true;
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drone: {name}");
            sb.AppendLine($"Manufactured by: {brand}");
            sb.AppendLine($"Range: {range} kilometers");

            return sb.ToString().Trim();

        }

    }
}
