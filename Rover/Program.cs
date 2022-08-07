using System;
using System.Linq;
using System.Text;
using static System.Console;

namespace Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "NASA Expedition";

            WriteLine("NASA HQ Connection Established...");
            WriteLine("Planet: Mars");
            WriteLine("Mission: Expedition");
            WriteLine();

            Expedition expedition = new Expedition();
            expedition.Run();
        }
    }
}
