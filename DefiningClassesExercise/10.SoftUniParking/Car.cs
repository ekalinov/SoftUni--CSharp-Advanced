using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        //•	Make: string
        //•	Model: string
        //•	HorsePower: int
        //•	RegistrationNumber: string

        public Car(string make, string model, int hp, string regNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower=hp;
            this.RegistrationNumber=regNumber;
        }



        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }


        public override string ToString()
        {

            return  $"Make: {Make}{Environment.NewLine}" +
                    $"Model: {Model}{Environment.NewLine}" +
                    $"HorsePower: {HorsePower}{Environment.NewLine}" +
                    $"RegistrationNumber: {RegistrationNumber}";
        }



    }
}
