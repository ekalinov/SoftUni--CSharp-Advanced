using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer

{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;


        public Engine(int horsePower, double engineCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = engineCapacity;
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }
        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }


    }

}
