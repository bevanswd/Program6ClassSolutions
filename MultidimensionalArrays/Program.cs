using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //making a 1d array
            //int[] my1DArray = new int[3];
            //how to make 2d array
            int[,] my2DArray = new int[3, 3];
            //populate 2D array with random values
            //going through an array
            int counter = 1;
            for (int y = 0; y < 3; y++)
            { 
                //for each Y (row)
                for (int x = 0; x < 3; x++)
                { 
                    //for each X (column)
                    //set value at the X & Y coordinates to the value of the counter
                    my2DArray[x, y] = counter;
                    //increase counter
                    counter++;
                }
            }

            //writing out a grid
            for (int y = 0; y < 3; y++)
            { 
                //for each row (row)
                for (int x = 0; x < 3; x++)
                {
                    //write X to the grid (column)
                    Console.Write("[{0}]", my2DArray[x, y]);
                }
                //kick down to the next line at the end of the row
                Console.WriteLine();
            }

            //create 2D array of points
            Point[,] pointArray = new Point[10, 10];

            for (int y = 0; y < pointArray.GetLength(1); y++)
            {
                //for each row
                for (int x = 0; x < pointArray.GetLength(0); x++)
                {
                    //for each column
                    pointArray[x, y] = new Point(x, y);
                }
            }
            //get specific point in array
            Point somePoint = pointArray [2, 6];

            //using arrow for movement

            //putting a single keystroke into a variable
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            { 
                case ConsoleKey.LeftArrow:
                    //do left arrow stuff
                    Console.WriteLine("left");
                    break;
                case ConsoleKey.RightArrow:
                    //do right arrow stuff
                    Console.WriteLine("right");
                    break;
                case ConsoleKey.UpArrow:
                    //do up arrow shenanigans
                    Console.WriteLine("up");
                    break;
                case ConsoleKey.DownArrow:
                    //do down arrow jazz
                    Console.WriteLine("down");
                    break;
                default:
                    //invalid
                    Console.WriteLine("now an arrow");
                    break;
            }

            Console.ReadKey();
        }
        /// <summary>
        /// represents a single point on a grid
        /// </summary>
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                this.X = x; this.Y = y;
            }
            public string Value { get; set; }
        }
    }
}
