using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSelesman
{
    public class Car
    {

        //•	Model: a string property
        //•	Engine: a property holding the engine object
        //•	Weight: an int property, it is optional
        //•	Color: a string property, it is optional


        public Car(string model, Engine engine)
        {
            this.Engine = engine;
            this.Model = model;
           
            this.Color = "n/a";

        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {

            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine,weight)
        {
            this.Color = color;
        }


        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int? Weight { get; set; }

        public string Color { get; set; }


        public static string PrintCar(Car car)
        {
            string carInfo = string.Empty;

            string carDisplacement = car.Engine.Displacement.HasValue ? car.Engine.Displacement.ToString() : "n/a";
            string carWeight = car.Weight.HasValue ? car.Weight.ToString() : "n/a";

            carInfo = $"{ car.Model}:\r\n" +
                      $"  {car.Engine.EngineModel}:\r\n" +
                      $"    Power: { car.Engine.Power}\r\n" +
                      $"    Displacement: {carDisplacement}\r\n" +
                      $"    Efficiency: {car.Engine.Efficiency}\r\n" +
                      $"  Weight: {carWeight}\r\n" +
                      $"  Color: { car.Color}";
            
            return carInfo;
        }
    }
}
