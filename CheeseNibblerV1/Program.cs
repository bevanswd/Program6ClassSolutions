using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseNibbler
{
    class Program
    {
        static void Main(string[] args)
        {
            //play the game
            new CheeseNibbler().PlayGame();
            //keep console open
            Console.ReadKey();
        }
    }

    //ENNUMERATIONS
    //set outside of class so it's accessible wherever (would need to be specified as public if inside a class)
    public enum PointStatus
    {
        Empty,
        Mouse,
        Cheese
    }

    //POINT CLASS
    //stores the status of the points on the grid
    public class Point
    {
        //PROPERTIES
        //set X and Y properties
        public int X { get; set; }
        public int Y { get; set; }
        //create a property with "PointStatus" type with a name "PointStatus"
        public PointStatus Status { get; set; }

        //CONSTRUCTOR
        //plot 2D points using x & y
        public Point(int x, int y) //use lowercase as paramaters so we can reference the upercase X & Y properties
        {
            //set points to "empty" by default
            this.X = x; this.Y = y; this.Status = PointStatus.Empty;
        }
    }

    //CHEESENIBBLER CLASS
    //(stuff actually happens in this class)
    class CheeseNibbler
    {
        //PROPERTIES
        public Point[,] Grid { get; set; }
        public Point Mouse { get; set; }
        public Point Cheese { get; set; }
        int Round { get; set; } //get how many rounds you played

        //CONSTRUCTORS
        /// <summary>
        /// function to initialize all the things on the grid
        /// </summary>
        public CheeseNibbler()
        {
            //initialize grid array (and how many points you want the grid to contain)
            this.Grid = new Point[10, 10];
            //set round to 1 to start
            this.Round = 1;

            //fill each cell of grid with a point (initialize grid with a bunch of points)
            //for each row y
            for (int y = 0; y < this.Grid.GetLength(1); y++) //loop through every y value in the grid (use GetLength(1) to pick up # of grid points from the Grid array on the Y axis)
            {
                //for each column x
                for (int x = 0; x < this.Grid.GetLength(0); x++) //loop through every x value in the grid (use GetLength(0) to pick up # of grid points from the Grid array on the X axis)
                {
                    //setting a new point into each coordinate of the grid
                    this.Grid[x, y] = new Point(x, y);
                    //(the default "empty" status in the Point constructor will set all points on the grid as empty)
                }
            }

            //initialize RNG
            Random rng = new Random();

            //place mouse randomly on grid (10 by 10 grid here)
            this.Mouse = Grid[rng.Next(0, 10), rng.Next(0, 10)];
            //the PointStatus of the mouse is declared here
            //(because this is set as a reference, the property will be changed in the Grid as well)
            this.Mouse.Status = PointStatus.Mouse;


            //place cheese with a do/while loop 
            //(you don't want to place the mouse in the same place as cheese)
            //CONDITIONS MUST BE MET TO EXECUTE CHEESE PLACEMENT 
            //(will loop through random points until it finds one that's not empty, then it will place cheese)
            do //loop through random points
            {
                //get a point to check 
                //(will randomly check for points on a grid until it finds one that's empty)
                this.Cheese = Grid[rng.Next(0, 10), rng.Next(0, 10)]; //pull a random point
            } while (this.Cheese.Status != PointStatus.Empty); //check if a point is not empty
            this.Cheese.Status = PointStatus.Cheese; //set cheese after making sure the random point is empty
        }

        /// <summary>
        /// plot-out the grid with stuff
        /// </summary>
        private void DrawGrid()
        {
            //clear the console to display the grid
            Console.Clear();

            //loop through each grid point on the Y axis
            for (int y = 0; y < this.Grid.GetLength(1); y++)
            {
                //loop through each grid point on the X axis
                for (int x = 0; x < this.Grid.GetLength(0); x++)
                {
                    //use switch/case to define the things on the grid
                    //check the type of each point
                    switch (this.Grid[x, y].Status)
                    {
                        //plot empty
                        case PointStatus.Empty:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("[ ]");
                            break;
                        //plot cheese
                        case PointStatus.Cheese:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("[C]");
                            break;
                        //plot cat
                        //case PointStatus.Cat:
                        //    Console.ForegroundColor = ConsoleColor.Red;
                        //    Console.Write("[  =^.^=  ]");
                        //    break;
                        //plot mouse
                        case PointStatus.Mouse:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("[M]");
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                //force the console to write the next line
                Console.WriteLine();
            }
            //Console.WriteLine("Cheese Eaten: {0}", this.CheeseCount);
            //Console.WriteLine("Mouse Health: {0}", this.Mouse.Energy);
        }

        /// <summary>
        /// determine user keypress
        /// </summary>
        /// <returns></returns>
        private ConsoleKey GetUserMove()
        {
            //using switch statement to check input validation
            //bool validKey = false;
            //ConsoleKeyInfo input;
            //while (!validKey)
            //{
            //    input = Console.ReadKey(true);
            //    switch(input.Key)
            //    {
            //        case ConsoleKey.LeftArrow:
            //        case ConsoleKey.RightArrow:
            //        case ConsoleKey.UpArrow:
            //        case ConsoleKey.DownArrow:
            //            validKey = true;
            //            return input.Key; //cases don't need breaks here because the return function sets the boundary
            //        default: //anything else will write "invald move"
            //            Console.WriteLine("Invalid Move");
            //            break;
            //    }
            //}

            //Console.ReadKey(true) keeps the char from being written to the console
            ConsoleKeyInfo input = Console.ReadKey(true);
            //checking for valid input (anything but arrows is invalid)
            while ((input.Key != ConsoleKey.LeftArrow && input.Key != ConsoleKey.RightArrow && input.Key != ConsoleKey.UpArrow && input.Key != ConsoleKey.DownArrow || !ValidMove(input.Key)))
            {
                //tell user they hit wrong key
                Console.WriteLine("Invalid Move");
                //anticipate another keypress without writing it to the console (using Console.ReadKey(true))
                input = Console.ReadKey(true);
            }
            //if not invalid input, return it to the console
            return input.Key;
        }

        /// <summary>
        /// validates user input (makes sure it's an arrow)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool ValidMove(ConsoleKey input)
        {
            //check each type of keypress
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    //true if move is on the grid
                    return this.Mouse.X - 1 >= 0;
                case ConsoleKey.RightArrow:
                    //true if move is on the grid
                    return this.Mouse.X + 1 < this.Grid.GetLength(1); //GetLength() specifies the dimension to check (as specified in the grid array)
                case ConsoleKey.UpArrow:
                    //true if move is on the grid
                    return this.Mouse.Y - 1 >= 1;
                default:
                    //true if move is on the grid
                    //checks for down case (defaults to down arrow as that's the only other key specified in GetUserMove)
                    return this.Mouse.Y + 1 < this.Grid.GetLength(0);
            }
        }

        /// <summary>
        /// moves the mouse depending on user keypress (up, down, left, right)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool MouseMove(ConsoleKey input)
        {
            //get current x & y coordinates of the mouse
            int mouseX = this.Mouse.X;
            int mouseY = this.Mouse.Y;
            //change value of the mouse to new position upon input
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    mouseX--;
                    break;
                case ConsoleKey.RightArrow:
                    mouseX++;
                    break;
                case ConsoleKey.UpArrow:
                    mouseY--;
                    break;
                default:
                    mouseY++;
                    break;
            }
            //get point from the grid to set a new position
            Point targetPosition = this.Grid[mouseX, mouseY];
            //check if Status of new position is a PointStatus type "cheese"
            if (targetPosition.Status == PointStatus.Cheese)
            {
                //found a cheese, return true
                return true;
            }
            else
            {
                //the point must be empty if there's no cheese

                //********** THIS PART IS KINDA CONFUSING ************

                //clear the old status of Mouse
                this.Mouse.Status = PointStatus.Empty;
                //set new position of Mouse using "targetPosition"
                targetPosition.Status = PointStatus.Mouse;
                //update Mouse property to have x & y values of current "targetPosition"
                this.Mouse = targetPosition;

                //return false because there wasn't a cheese
                return false;
            }
        
        }

        public void PlayGame()
        {
            //set a boolean value to determine when the mouse gets the cheese (initialize as 'false')
            bool cheeseFound = false;
            //play game while cheese has not been found
            while (!cheeseFound)
            {
                //call DrawGrid() constructor to initialize the grid
                DrawGrid();
                //set user input to the GetUserMove() constructor
                //(move the mouse upon user input)
                ConsoleKey input = GetUserMove();
                //when mouse eats the cheese (cheeseFound turns to 'true' when MouseMove hits it)
                cheeseFound = MouseMove(input);
                //increment round counter determine how many moves our mouse makes
                this.Round++;
            }
            Console.WriteLine("Hooray! you found the cheese. it only took you {0} moves!", this.Round);
        }
    }
}