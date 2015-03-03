using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupSort
{
    class Program
    {

        static void Main(string[] args)
        {
            //create list of strings (namesList)
            List<string> namesList = new List<string>();
            //populate that list with the strings (using ints converted to strings)

            namesList.Add("tim");
            namesList.Add("laura");
            namesList.Add("michael");
            namesList.Add("linda");
            namesList.Add("eugene");
            namesList.Add("juli");
            namesList.Add("andrii");
            namesList.Add("nate");
            namesList.Add("nicole");
            namesList.Add("sergio");
            namesList.Add("mike");
            namesList.Add("brandon s");
            namesList.Add("patrick");
            namesList.Add("brandon e");
            namesList.Add("maria");
            namesList.Add("daniel");

            //call the function in groups of 4
            groupSort(namesList, 4);

            Console.ReadKey();

        }

        /// <summary>
        /// sorts randomized namesList strings into groups of 4
        /// </summary>
        /// <param name="namesList">randomized selection</param>
        /// <param name="groupMaxNumber">4</param>
        static void groupSort(List<string> namesList, int groupMaxNumber)
        {
            //create random object
            Random rng = new Random();
            //create list of groups
            List<string> group = new List<string>();
            //declare group number
            int groupNumber = 1;

            //while loop to distribute names into groups
            while (namesList.Count > 0)
            {
                //write groupNumber
                Console.WriteLine("Group {0}", groupNumber);

                //while loop to increment group number (until 4)
                while (group.Count < groupMaxNumber && namesList.Count > 0)
                {
                    //create an int that randomizes the index of namesList
                    int randomIndex = rng.Next(0, namesList.Count);
                    //create a name string to pick from the random assortment
                    string randomName = namesList[randomIndex];
                    //add the name string to the group
                    group.Add(randomName);
                    //remove string from the namesList
                    namesList.Remove(randomName);
                }
                //write the randomized names in group (separated by line break)
                Console.WriteLine(string.Join("\n", group));
                //clear the group for the next one
                group.Clear();
                //increment to next group
                groupNumber++;
                //another line break
                Console.WriteLine();
            }
        }
    }
}