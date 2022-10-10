using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSelesman
{
    public class Engine
    {
        //•	Model: a string property
        //•	Power: an int property
        //•	Displacement: an int property, it is optional
        //•	Efficiency: a string property, it is optional

        public Engine(string model,int power)
        {
            this.EngineModel = model;
            this.Power = power;
         
            this.Efficiency = "n/a";
        }

        public Engine(string engineModel, int power, int displacement) : this(engineModel, power)
        {
            Displacement = displacement;
        }

        public Engine(string engineModel, int power, string efficiency) : this(engineModel, power)
        {
            Efficiency = efficiency;

        }

        public Engine(string engineModel, int power, int displacement, string efficiency) : this(engineModel, power, displacement)
        {
            Efficiency = efficiency;
        }

        public string EngineModel { get; set; }

        public int Power { get; set; }

        public int? Displacement { get; set; }

        public string Efficiency { get; set; }


    }
}
