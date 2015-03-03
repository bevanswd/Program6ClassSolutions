using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Review
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SpaceRemover("hihi there e i s a  lott of spa ce s in this str in g"));
            SpecificLetterCounter("S", "Sally is sunny");
            //different space remover
            string noSpaces = "lots of spaces".Replace(" ", "");

            if ("aeiou".Contains(noSpaces[1].ToString().ToLower()))
            {

            }

            annoyingtextifyer("nickleback");

            Console.ReadKey();
        }

        static void DeclaringVariables()
        {
            //declaring a variable
            int count = 10;
            while (count < 20)
            {
                count++;
            }
        }

        /// <summary>
        /// takes in a string, removes all spaces
        /// </summary>
        /// <param name="inputString">string to despacify</param>
        /// <returns>a string with no faces</returns>
        static string SpaceRemover(string inputString)
        { 
            //declare an empty return string
            string returnString = ""; //or string.Empty

            //loop over each letter
            for (int i = 0; i < inputString.Length; i++)
            { 
                //get an individual letter (can grab char by index)
                string letter = inputString[i].ToString(); //this will convert the letter[i] to a string
                if (letter != " ") 
                {
                    returnString = returnString + letter;
                }
            }
            return returnString;
        }

        /// <summary>
        /// counts the number of instances of a specific letter in a string
        /// </summary>
        /// <param name="letterToCount">letter to count</param>
        /// <param name="stringToSearch">string to search</param>
        static void SpecificLetterCounter(string letterToCount, string stringToSearch)
        {
            //Output:
            //<stringToSearch> has x number of letterToCount in it
            //Sally is sunny has 3 s's in it

            //counter for the letter (holds number of matching letters found)
            int numberOfHits = 0;

            //loop through each letter
            for (int i = 0; i < stringToSearch.Length; i++ )
            {
                //get a letter
                string letter = stringToSearch[i].ToString();

                //compare current letter with letterToCount, convert both to lowercase
                if (letter.ToLower() == letterToCount.ToLower()) 
                {
                    numberOfHits++;
                }
            }

            //Output:
            // <stringToSearch> has x letterToCount's in it
            //sally is sunny has 3 s's in it
            Console.WriteLine("{0} has {1} {2}'s in it.", stringToSearch, numberOfHits, letterToCount);
        }

        /// <summary>
        /// NumberRounder, rounds an int to nearest 5
        /// </summary>
        /// <param name="numberToRound">number to round off</param>
        /// <returns>nearest 5</returns>
        static int NumberRounder(int numberToRound)
        {
            int remainder = numberToRound % 5;

            if (remainder > 2)
            {
                return (numberToRound - remainder + 5);
            }

            if (remainder == 1)
            {
                return numberToRound - 1;
            }
            else
            {
                return (numberToRound - remainder);
            }

        }

        ///summary - take in a string, returning a string with letters alternating between upper and lower case.
        ///param - string to make annoying
        ///returns - hard to read string
        //AnNoYiNgTeXtIfYeR, makes every other letter uppercase
        static String annoyingtextifyer(string notAnnoyingString)
        {
            for (int i = 0; i < notAnnoyingString; i++)
            {
                if (notAnnoyingString(i))
                foreach (notAnnoyingString(i) + 1) 
                {
                    Console.WriteLine(notAnnoyingString(i).ToUpper());
                }
            }

                //input: nickleback
                //output: NiCkLeBaCk
                //declare return string for output
                string returnString = string.Empty;
                for (int i = 0; i < notAnnoyingString.Length; i++) 
                {
                    //get a letter to examine
                    string currentLetter = notAnnoyingString[i].ToString();
                    //see if the position of the letter is odd or even
                    if (if % 2 == 0)
                    {
                        //even, make it CAPITAL
                        returnString += currentLetter.ToUpper();
                    }
                    else
                    {
                        //odd, make it SMALL
                        returnString += currentLetter.ToLower();
                    }
                }
                return "";
        }

    }
}