using System;
using System.Text;

namespace Rover
{
    class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }
        public char[] Instructions { get; set; }

        public Rover(string str)
        {
            string[] args = str.Split(' ');
            X = int.Parse(args[0]);
            Y = int.Parse(args[1]);
            Direction = char.Parse(args[2]);
        }

        public void Instruct(string instructions)
        {
            instructions = instructions.Replace("lr", "");
            instructions = instructions.Replace("rl", "");
            Instructions = instructions.ToCharArray();
        }

        public void Survey(int[] grid)
        {
            // Got pretty messy in here
            foreach (char ins in Instructions)
            {
                switch (ins)
                {
                    case 'l':
                        switch (Direction)
                        {
                            case 'n':
                                Direction = 'w';
                                break;
                            case 'w':
                                Direction = 's';
                                break;
                            case 's':
                                Direction = 'e';
                                break;
                            case 'e':
                                Direction = 'n';
                                break;
                        }
                        break;
                    case 'r':
                        switch (Direction)
                        {
                            case 'n':
                                Direction = 'e';
                                break;
                            case 'w':
                                Direction = 'n';
                                break;
                            case 's':
                                Direction = 'w';
                                break;
                            case 'e':
                                Direction = 's';
                                break;
                        }
                        break;
                    case 'm':
                        if (IsFacingEdge(grid))
                            continue;
                        else
                        {
                            switch (Direction)
                            {
                                case 'n':
                                    Y++;
                                    break;
                                case 'w':
                                    X--;
                                    break;
                                case 's':
                                    Y--;
                                    break;
                                case 'e':
                                    X++;
                                    break;
                            }    
                        }
                        break;
                }
            }
            Console.WriteLine("{0} {1} {2}", X, Y, Direction);
        }

        private bool IsFacingEdge(int[] grid)
        {
            switch (Direction)
            {
                case 'n':
                    if (Y == grid[1])
                        return true;
                    break;
                case 'w':
                    if (X == 0)
                        return true;
                    break;
                case 's':
                    if (Y == 0)
                        return true;
                    break;
                case 'e':
                    if (X == grid[0])
                        return true;
                    break;
            }
            return false;
        }
    }
}
