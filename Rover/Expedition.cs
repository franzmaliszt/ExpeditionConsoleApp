using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Rover
{
    class Expedition
    {
        private int[] Grid;
        private List<Rover> ActiveRovers = new List<Rover>();

        public void Run()
        {
            SetSurface();
            AssignRovers();

            ActiveRovers.ForEach(rover => rover.Survey(Grid));

            Console.WriteLine("\n\nEnd of transmission, press any button to exit...");
            Console.ReadKey(true);
        }

        private void SetSurface()
        {
            string pattern = @"^\d+\s+\d+$";
            Regex rg = new Regex(pattern);

            string input;
            do
            {
                Console.Write(">Field Size: ");
                input = Console.ReadLine();
            } while (!rg.IsMatch(input));

            Grid = Array.ConvertAll(input.Split(' '), s => int.Parse(s));
        }

        private void AssignRovers()
        {
            int roverCount;
            bool check;
            string input;

            do
            {
                Console.Write(">Number of units to be assigned: ");
                input = Console.ReadLine();
                check = int.TryParse(input, out roverCount);
            } while (!check);

            string pattern = @"^\d+\s+\d+\s[nswe]$";
            Regex rg = new Regex(pattern);
            string commandPattern = @"^[lmr]*$";
            Regex rgc = new Regex(commandPattern);
            while (ActiveRovers.Count < roverCount)
            {
                Console.Write(">Starting coordinates and orientation: ");
                input = Console.ReadLine().ToLower();
                if (rg.IsMatch(input))
                {
                    Rover rover = new Rover(input);

                    while (rover.X <= Grid[0] && rover.Y <= Grid[1])
                    {
                        Console.Write(">Instructions: ");
                        input = Console.ReadLine().ToLower();
                        if (rgc.IsMatch(input))
                        {
                            rover.Instruct(input);
                            ActiveRovers.Add(rover);
                            break;
                        }
                    }
                }
            }
        }
    }
}