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
            //set console width to 100
            Console.WindowWidth = 100;
            //play the game
            new CheeseNibbler().PlayGame();
            //keep console open
            Console.ReadKey(true);
        }
    }

    //ENNUMERATIONS
    //set outside of class so it's accessible wherever (would need to be specified as public if inside a class)
    public enum PointStatus
    {
        Empty,
        Mouse,
        Cheese,
        Cat,
        CatAndCheese
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
    //MOUSE CLASS
    //stores status of mouse on the grid
    public class Mouse
    {
        public int Energy { get; set; }
        public Point Position { get; set; }
        public bool Dead { get; set; }
        public Mouse()
        {
            this.Dead = false;
            this.Energy = 50;
        }
        public void EatCheese()
        {
            this.Energy += 10;
        }
    }
    //CAT CLASS
    //stores status of cat on the grid
    public class Cat
    {
        public Point Position { get; set; }
    }
    //CHEESENIBBLER CLASS
    //(stuff actually happens in this class)
    class CheeseNibbler
    {
        //PROPERTIES
        public Point[,] Grid { get; set; }
        public Mouse Mouse { get; set; }
        public Point Cheese { get; set; }
        public int CheeseCount { get; set; }
        public List<Cat> Cats { get; set; }

        //initialize RNG
        Random rng = new Random();

        //CONSTRUCTOR
        /// <summary>
        /// function to initialize all the things on the grid
        /// </summary>
        public CheeseNibbler()
        {
            //initialize cat, cheese, & mouse
            this.Cats = new List<Cat>();
            this.CheeseCount = 0;
            this.Mouse = new Mouse();
            //initialize grid array (and how many points you want the grid to contain)
            this.Grid = new Point[10, 10];

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

            //place mouse randomly on grid (10 by 10 grid here)
            this.Mouse.Position = Grid[rng.Next(0, 10), rng.Next(0, 10)];
            //the PointStatus of the mouse is declared here
            //(because this is set as a reference, the property will be changed in the Grid as well)
            this.Mouse.Position.Status = PointStatus.Mouse;

            //call PlaceCheese() function
            PlaceCheese();
        }

        //FUNCTIONS
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
                            Console.Write("[       ]");
                            break;
                        //plot cheese
                        case PointStatus.Cheese:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("[   0   ]");
                            break;
                        //plot cat
                        case PointStatus.Cat:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[ =^.^= ]");
                            break;
                        //plot cat & cheese
                        case PointStatus.CatAndCheese:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[ =^.^= ]");
                            break;
                        //plot mouse
                        case PointStatus.Mouse:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("[~(_^·> ]");
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                //force the console to write the next line
                Console.WriteLine();
            }
            //write stats to the console
            Console.WriteLine("Cheese Eaten: {0}", this.CheeseCount);
            Console.WriteLine("Mouse Health: {0}", this.Mouse.Energy);
        }
        /// <summary>
        /// determine user keypress
        /// </summary>
        /// <returns></returns>
        private ConsoleKey GetUserMove()
        {
            //set boolean value to FALSE
            bool validInput = false;
            //we're going to validate input here
            while (!validInput) //while validInput is TRUE
            {
                //handle key stroke from user with Console.ReadKey() function, which returns a type "ConsoleKeyInfo"
                ConsoleKeyInfo inputKey = Console.ReadKey(true); //use Console.ReadKey(true) to prevent invalid input writing to the console
                //make sure user presses an arrow key
                if (inputKey.Key == ConsoleKey.LeftArrow || inputKey.Key == ConsoleKey.RightArrow || inputKey.Key == ConsoleKey.UpArrow || inputKey.Key == ConsoleKey.DownArrow)
                {
                    //if we have valid input 
                    if (ValidMouseMove(inputKey.Key))
                    {
                        //set validInput to TRUE
                        validInput = true;
                        //return the input key
                        return inputKey.Key;
                    }
                }
                else
                {
                    //otherwise, write error message to the console
                    Console.WriteLine("Invalid Move");
                }
            }
                return ConsoleKey.UpArrow;
        }
        /// <summary>
        /// validates user input (makes sure it's an arrow)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool ValidMouseMove(ConsoleKey input)
        {
            int thisX = this.Mouse.Position.X;
            int thisY = this.Mouse.Position.Y;
            //check each type of keypress
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    thisX--;
                    return (thisX >= 0);
                case ConsoleKey.RightArrow:
                    thisX++;
                    return thisX <= 9;
                case ConsoleKey.UpArrow:
                    thisY--;
                    return thisY >= 0;
                case ConsoleKey.DownArrow:
                    thisY++;
                    return thisY <= 9;
                default:
                    return false;
            }
        }
        /// <summary>
        /// moves the mouse depending on user keypress (up, down, left, right)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private void MouseMove(ConsoleKey input)
        {
            //lower energy with each mouse move
            this.Mouse.Energy--;
            //get current x & y coordinates of the mouse
            int mouseX = this.Mouse.Position.X;
            int mouseY = this.Mouse.Position.Y;
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
                case ConsoleKey.DownArrow:
                    mouseY++;
                    break;
                default:
                    break;
            }
            //get point from the grid to set a new position
            Point targetPosition = this.Grid[mouseX, mouseY];
            //check if Status of new position is a PointStatus type "Cheese"
            if (targetPosition.Status == PointStatus.Cheese)
            {
                //cheese touches mouse, cheese count goes up, mouse eats cheese
                //found a cheese, increase cheese count
                this.CheeseCount++;
                //call EatCheese() function to remove cheese
                this.Mouse.EatCheese();
                //place new cheese after mouse eats cheese
                PlaceCheese();

                //add a new cat for every even number of cheese eaten
                if (this.CheeseCount % 2 == 0)
                {
                    AddCat();
                }
                targetPosition.Status = PointStatus.Mouse;
            }
            //check if Status of new position is a PointStatus type "Cat"
            else if (targetPosition.Status == PointStatus.Cat)
            {
                //if cat touches mouse, mouse is dead
                this.Mouse.Dead = true;
                targetPosition.Status = PointStatus.Cat;
            }
            else
            {
                //the mouse is alone
                targetPosition.Status = PointStatus.Mouse;
            }

            //move mouse
            this.Mouse.Position.Status = PointStatus.Empty;
            this.Mouse.Position = targetPosition;

        }
        /// <summary>
        /// function to place cheese randomly on the grid
        /// </summary>
        private void PlaceCheese()
        {
            //set initial boolean value of placecheese to false (we don't want to place a cheese on a cheese)
            bool placeCheese = false;
            //while placecheese is TRUE
            while (!placeCheese)
            {
                //define a random point on the grid
                Point point = this.Grid[rng.Next(0, 10), rng.Next(0, 10)];
                //if the point is empty
                if (point.Status == PointStatus.Empty)
                {
                    //place cheese on grid, only place the cat on an empty point
                    placeCheese = true;
                    point.Status = PointStatus.Cheese;
                    this.Cheese = point;
                }
            }
        }
        /// <summary>
        /// function to create cat
        /// </summary>
        private void AddCat()
        {
            //create cat object
            Cat newCat = new Cat();
            //call "place cat" function here
            PlaceCat(newCat);
            //add cat to cat list
            this.Cats.Add(newCat);
        }
        /// <summary>
        /// function to place cat on the grid
        /// </summary>
        /// <param name="cat"></param>
        private void PlaceCat(Cat cat)
        {
            //set initial boolean value to false (we don't want to place a cat on a cheese)
            bool placeCheese = false;
            //while placecheese is TRUE
            while (!placeCheese)
            {
                //define a random point on the grid
                Point point = this.Grid[rng.Next(0, 10), rng.Next(0, 10)];
                //if the point is empty
                if (point.Status == PointStatus.Empty)
                {
                    //place cat on grid, only place the cat on an empty point
                    placeCheese = true;
                    point.Status = PointStatus.Cat;
                    cat.Position = point;
                }
            }
        }
        /// <summary>
        /// function to move cat across the grid
        /// </summary>
        /// <param name="cat"></param>
        private void MoveCat(Cat cat)
        {
            //mouse was 80% chance to move
            if (rng.Next(6) > 1)
            {
                //define x & y coordinates to store in bools for determining cat movement
                int x = this.Mouse.Position.X - cat.Position.X; //cat will follow mouse along the X axis (mouse position minus cat position)
                int y = this.Mouse.Position.Y - cat.Position.Y; // cat will follow mouse along the Y axis (mouse position minus cat position)
                //define the bool for verifying correct cat movement
                bool validMove = false;
                //define a point to determine cat poisition
                Point targetLocation = cat.Position;
                //set cat movement bools with x & y coordinates by comparing the coordinates of Mouse.Position & cat.Position
                bool moveLeft = (x < 0); //cat will move left toward the mouse if the x coordinates of Mouse is less than Cat
                bool moveRight = (x > 0); //cat will move right toward the mouse if the x coordinates of Mouse is more than Cat
                bool moveUp = (y < 0); //cat will move up toward the mouse if the y coordinates of Mouse is more than Cat
                bool moveDown = (y > 0); //cat will move down toward the mouse if the y coordinates of Mouse is less than Cat

                //while loop for implementing the variables that move the mouse
                //while validMove is TRUE, and one of the boolean conditions are met
                while (!validMove && (moveLeft || moveRight || moveUp || moveDown))
                {
                    //define coordinates of current cat position
                    int findX = cat.Position.X;
                    int findY = cat.Position.Y;

                    //if mouse coordinates are to the right of cat coordinates
                    if (moveRight)
                    {
                        //cat targetLocation will move 1 coordinate right along the x axis
                        targetLocation = Grid[++findX, findY];
                        moveRight = false;
                    }
                    //if mouse coordinates are to the left of cat coordinates
                    else if (moveLeft)
                    {
                        //cat targetLocation will move 1 coordinate left along the x axis
                        targetLocation = Grid[--findX, findY];
                        moveLeft = false;
                    }
                    //if mouse coordinates are below cat coordinates
                    else if (moveDown)
                    {
                        //cat targetLocation will move 1 coordinate up along the y axis
                        targetLocation = Grid[findX, ++findY];
                        moveDown = false;
                    }
                    //if mouse coordinates are above cat coordinates
                    else if (moveUp)
                    {
                        //cat targetLocation will move 1 coordinate down along the y axis
                        targetLocation = Grid[findX, --findY];
                        moveUp = false;
                    }
                    //validate cat movement
                    validMove = IsValidCatMove(targetLocation);
                }
                //PREVENT CAT FROM TOUCHING CHEESE
                //if cat's current position is on the cheese
                if (cat.Position.Status == PointStatus.CatAndCheese)
                {
                    //move cat off that point by setting it to cheese
                    cat.Position.Status = PointStatus.Cheese;
                }
                else //move the cat to an empty point
                {
                    cat.Position.Status = PointStatus.Empty;
                }
                //if cat's current position is on the mouse
                if (targetLocation.Status == PointStatus.Mouse)
                {
                    //mouse is dead
                    this.Mouse.Dead = true;
                    //cat ate the mouse and took over mouse's point
                    targetLocation.Status = PointStatus.Cat;
                }
                //if the status of Cheese
                else if (targetLocation.Status == PointStatus.Cheese)
                {
                    //set status to CatAndCheese
                    targetLocation.Status = PointStatus.CatAndCheese;
                }
                //otherwise, set status to Cat
                else
                {
                    targetLocation.Status = PointStatus.Cat;
                }
                //update cat's position with targetPosition
                cat.Position = targetLocation;
            }
        }
        //bool to determine whether the cat moves to a valid point
        private bool IsValidCatMove(Point targetLocation)
        {
            //cat can only land on empty spaces or mouse
            return (targetLocation.Status == PointStatus.Empty || targetLocation.Status == PointStatus.Mouse);
        }
        /// <summary>
        /// play game function
        /// </summary>
        public void PlayGame()
        {
            //while mouse is still alive
            while (this.Mouse.Energy > 0 && !this.Mouse.Dead)
            {
                //call grid function to display grid
                DrawGrid();
                //call MouseMove method with user input
                MouseMove(GetUserMove());
                //move the cat(s) along the grid
                foreach (Cat cat in this.Cats)
                {
                    MoveCat(cat);
                }
            }
            //call DrawGrid() function again to re-draw the grid without the mouse (mouse is dead, it shouldn't be on the grid)
            DrawGrid();
            //write 'game over' text to the console
            if (Mouse.Dead)
            {
                Console.WriteLine("\nYou were eaten! x_x");
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("At least you enjoyed {0} nibbles of cheese during your short life\n", this.CheeseCount);
            }
            else if (Mouse.Energy == 0)
            {
                Console.WriteLine("\nYou died of starvation");
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("At least you enjoyed {0} nibbles of cheese during your short life\n", this.CheeseCount);
            }
        }
    }
}