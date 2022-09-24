using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guestsRegular = new HashSet<string>();
            HashSet<string> guestsVIP = new HashSet<string>();

            //Adding guests in the Guest lists.
            // VIPs reservation numbers starts with a digit!!

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    break;
                }
                char firstChar = char.Parse(input[0].ToString());

                if (char.IsDigit(firstChar))
                {
                    guestsVIP.Add(input);
                }
                else
                {
                    guestsRegular.Add(input);
                }

            }

            

            // Removing guests who came in from the lists

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                char firstChar = char.Parse(input[0].ToString());

                if (char.IsDigit(firstChar))
                {
                    guestsVIP.Remove(input);
                }
                else
                {
                    guestsRegular.Remove(input);
                }

            }

            int peopleDidntCome = guestsRegular.Count + guestsVIP.Count;

            Console.WriteLine(peopleDidntCome);


            if (guestsVIP.Count > 0)
            {
                foreach (var guest in guestsVIP)
                {
                    Console.WriteLine(guest);
                }
            }

            if (guestsRegular.Count > 0)
            {
                foreach (var guest in guestsRegular)
                {
                    Console.WriteLine(guest);
                }
            }
            


        }
    }
}
