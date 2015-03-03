using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bEvans_Week2CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //call FizzBuzz in loop
            for (int i = 0; i <= 20; i++)
            {
                FizzBuzz(i);
            }

            Console.WriteLine();

            //call LetterCounter
            LetterCounter('i', "I love biscuits and gravy. It's the best breakfast ever.");
            LetterCounter('n', "Never gonna give you up. Never gonna let you down.");
            LetterCounter('s', "Sally sells seashells down by the seashore. She's from Sussex.");
        }

        /// <summary>
        /// FizzBuzz function
        /// </summary>
        /// <param name="number">counting 0-20</param>
        static void FizzBuzz(int number)
        { 
            if((number % 5 == 0) && (number % 3 == 0) && (number != 0))
            {
                Console.WriteLine("FizzBuzz");
            }
            else if ((number % 5 == 0) && (number != 0))
            {
                Console.WriteLine("Fizz");
            }
            else if ((number % 3 == 0) && (number != 0))
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(number);
            }
        }

        static void LetterCounter(char letter, string inString)
        {
            //set letter counts to 0
            int letterCount = 0;
            int upperChars = 0;
            int lowerChars = 0;


            //loop through each char in inString
            for (int i = 0; i < inString.Length; i++)
            {
                //create array for looping through chars in string
                string stringArray = inString[i].ToString();

                //check is letter is contained within string
                if (letter.ToString().ToLower().Contains(stringArray.ToLower()))
                {
                    //add value to letterCount
                    letterCount++;
                }
                    
                //if uppercase
                if (letter.ToString().ToUpper().Contains(stringArray))
                    { 
                        //addvalue to upperChars
                        upperChars++;
                    }
                    
                //if lowercase
                if (letter.ToString().ToLower().Contains(stringArray))
                    {
                        //addvalue to upperChars
                        lowerChars++;
                    }
                
            }
            Console.WriteLine();
            Console.WriteLine("Input: " + inString);
            Console.WriteLine();
            Console.WriteLine("Number of uppercase " + letter + "'s found: " + upperChars);
            Console.WriteLine("Number of lowercase " + letter + "'s found: " + lowerChars);
            Console.WriteLine("Total number of " + letter + "'s found: " + letterCount);
            Console.WriteLine();
        }
    }
}
