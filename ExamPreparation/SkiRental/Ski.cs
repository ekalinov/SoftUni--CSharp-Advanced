using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental
{
    public class Ski
    {
        private string manufacturer;
        private string model;
        private int year;

        //•	Manufacturer: string
        //•	Model: string
        //•	Year: int
        public Ski(string manufacturer, string model,int year )
        {
            this.manufacturer = manufacturer;
            this.model = model;
            this.year = year;
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public override string ToString()
        {
            return $"{this.manufacturer} - {this.model} - {this.year}";
        }
    }
}
