﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    internal class Car
    {

        //•	Make: string
        //•	Model: string
        //•	LicensePlate: string
        //•	HorsePower: int
        //•	Weight: double


        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.Make = make;
            this.Model = model;
            this.LicensePlate = licensePlate;
            this.HorsePower = horsePower;
            this.Weight = weight;    

        }


        public string Make { get; set; }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public int HorsePower { get; set; }

        public double Weight { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: { Model}");
            sb.AppendLine($"License Plate: { LicensePlate}");
            sb.AppendLine($"Horse Power: { HorsePower}");
            sb.AppendLine($"Weight: {Weight}");

            return sb.ToString().Trim();
        }
    }
}
