using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    internal class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car(string[] carArgs)
        {

            Engine = new Engine();

            Cargo = new Cargo();

            Model = carArgs[0];
           
            Engine.Speed = int.Parse(carArgs[1]);
            
            Engine.Power = int.Parse(carArgs[2]);

            Cargo.Weight = int.Parse(carArgs[3]);

            Cargo.Type = carArgs[4];

          Tires = new Tire[4]
            {
              new Tire(int.Parse(carArgs[6]), double.Parse(carArgs[5])),
              new Tire( int.Parse(carArgs[8]), double.Parse(carArgs[7])),
              new Tire( int.Parse(carArgs[10]), double.Parse(carArgs[9])),
              new Tire( int.Parse(carArgs[12]), double.Parse(carArgs[11]))

            };
            
        }
    }
}
