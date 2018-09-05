using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    class Program
    {
        static void Main(string[] args)
        {
            int width, height, infectAfter, maxGenerations;
            bool[,] world;

            // if all args are ok run the game
            if (ParseArgs(args, out width, out height, out maxGenerations, out infectAfter, out world))
            {
                var game = new GameOfLifeInfection(width, height, maxGenerations, infectAfter, world);

                game.RunAll(Console.WriteLine);
            }
            else
            {
                Console.WriteLine("Args: [width] [height] [infect-after] [max-generations] [world (example: \"0 0 0 1 0 0 1 0 1\")]");

                Console.WriteLine("Doing Tests");
                // test1
                world = new bool[,]
                {
                    { false,false,false },
                    { true,false,false },
                    { true,false,true }
                };

                var game = new GameOfLife(3, 3, 2, world);
                if (game.ToString() != "000100101")
                {
                    Console.WriteLine("Fail");
                    return;
                }

                if (game.RunAll(null, 0) != "000010010")
                {
                    Console.WriteLine("Fail");
                    return;
                }

                // test2
                world = new bool[,]
                {
                    { false,true,false },
                    { true,false,false },
                    { false,true,true }
                };

                game = new GameOfLifeInfection(3, 3, 2, 0, world);

                if (game.ToString() != "010100011")
                {
                    Console.WriteLine("Fail");
                    return;
                }

                if (game.RunAll(null, 0) != "001000011")
                {
                    Console.WriteLine("Fail");
                    return;
                }


                // test3
                world = new bool[,]
                {
                    { true,true,false },
                    { true,false,false },
                    { false,false,true }
                };

                game = new GameOfLifeInfection(3, 3, 10, 5, world);

                if (game.ToString() != "110100001")
                {
                    Console.WriteLine("Fail");
                    return;
                }

                if (game.RunStep() != "110100000")
                {
                    Console.WriteLine("Fail");
                    return;
                }

                if (game.RunAll(null, 0) != "110110000")
                {
                    Console.WriteLine("Fail");
                    return;
                }

                if (game.RunStep() != "110110001")
                {
                    Console.WriteLine("Fail");
                    return;
                }

                Console.WriteLine("Success");
            }
        }

        /// <summary>
        /// parse the args for the game, if args are invalide return false
        /// </summary>
        /// <param name="args">the args list</param>
        /// <param name="width">returns the width</param>
        /// <param name="height">returns the height</param>
        /// <param name="maxGenerations">returns the maxGenerations</param>
        /// <param name="infectAfter">returns the infectAfter</param>
        /// <param name="worldStart">returns the worldStart</param>
        /// <returns></returns>
        static bool ParseArgs(string[] args, out int width, out int height, out int maxGenerations, out int infectAfter, out bool[,] worldStart)
        {
            width = 0; height = 0; maxGenerations = 0; infectAfter = 0;
            worldStart = null;

            // check if there enough args
            if (args.Length != 5)
            {
                Console.WriteLine("not all args given");
                return false;
            }

            // check if all integers are ok
            if (!int.TryParse(args[0], out width) || !int.TryParse(args[1], out height) ||
                !int.TryParse(args[2], out infectAfter) || !int.TryParse(args[3], out maxGenerations))
            {
                Console.WriteLine("parse error");
                return false;
            }
            worldStart = new bool[height, width];

            // check if the world contain enough numbers
            var worldString = args[4].Split(' ');
            if (worldString.Length != width * height)
            {
                Console.WriteLine("parse error");
                return false;
            }

            // check if the world contain all 1 or 0
            for (int i = 0; i < worldString.Length; i++)
                if (worldString[i] == "1" || worldString[i] == "0")
                    worldStart[i / width, i % width] = worldString[i] == "1";
                else
                {
                    Console.WriteLine("parse error");
                    return false;
                }

            return true;
        }
    }
}
