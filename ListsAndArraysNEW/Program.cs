using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsAndArraysNEW
{
    class Program
    {
        static void Main(string[] args)
        {
            // fixed length array
            string[] foodArray = new string[5];
            foodArray[0] = "couscous";
            foodArray[1] = "bananas";
            foodArray[2] = "corn";
            foodArray[3] = "cheese";
            foodArray[4] = "beans";

            for (int i = 0; i < foodArray.Length; i++)
			{
                Console.WriteLine(foodArray[i]);
            }

            //2D arrays
            int[,] twoD = new int[5, 5];
            twoD[1, 4] = 7;
            Console.WriteLine(twoD[1,4]);

            //Lists
            List<string> teams = new List<string>();
            teams.Add("broncos");
            teams.Add("tigers");
            teams.Add("eagles");
            Console.WriteLine("before sort");
            //write the list as-is
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i]);
            }

            // put list in alphabetical order (defaults as alphabetical order if they're strings)
            teams.Sort();
            Console.WriteLine("after sort");
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i]);
            }

            //insert an index into teams' array (log to console)
            teams.Insert(0, "49ers");
            Console.WriteLine(teams[0]);

            //remove stuff
            teams.Remove("eagles");

            //remove by index
            teams.RemoveAt(0);

            //keep console open
            Console.ReadKey();
        }
    }
}