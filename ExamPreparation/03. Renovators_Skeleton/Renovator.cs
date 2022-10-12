using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {

        //•	Name: string
        //•	Type: string
        //•	Rate: double
        //•	Days: int
        //•	Hired: boolean - false by default
        private string name;

        private string type;

        private double rate;

        private int days;

        private bool hired = false;


        public Renovator(string name, string type, double rate, int days)
        {
            Name= name;
            Type = type;
            Rate = rate;
            this.days = days;

        }





        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public int Days
        {
            get { return days; }
            set { days = value; }
        }

        public bool Hired
        {
            get { return hired; }
            set { hired = value; }
        }




        public override string ToString()
        {
            string otputString =
                $"-Renovator: {name}{Environment.NewLine}" +
                $"--Specialty: {type}{Environment.NewLine}" +
                $"--Rate per day: {rate} BGN";

            return otputString;
        }




    }
}
