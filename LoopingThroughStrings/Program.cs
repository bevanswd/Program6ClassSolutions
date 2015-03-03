using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopingThroughStrings
{
    class Program
    {
        //The main function should contain final output with parameters implemented (using other pre-defined functions)
        static void Main(string[] args)
        {
            //function call for vowel counter
            string testString = "the lazy dog jumps over the lazy bear";
            Console.WriteLine("We found {0} vowels in {1}", VowelCounter3000(testString), testString);
            Console.WriteLine("The average length of a word in {0} is {1}", testString, AverageWordLengthFinder8000(testString));

            //OldTimeyTextPrinter
            oldTimeyTextPrinter(testString, 40);

            Console.ReadKey();
        }

        //new functions are *always* declared outside of other functions but inside a class
        /// <summary>
        /// Count the number of vowels in a string
        /// </summary>
        /// <param name="inputText">the string to analyze</param>
        /// <returns>return the number of vowels found</returns>
        static int VowelCounter3000(string inputText)
        {
            //this is the vowel counter
            int numberOfVowelsFound = 0;
            //"hello"
            for (int i = 0; i < inputText.Length; i++)
            {
                char letter = char.ToLower(inputText[i]);
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    //if it's a vowel, then count it
                    numberOfVowelsFound = numberOfVowelsFound + 1;
                }
            }
            //loop complete. searched through each letter of the string, counted vowels, now return number of vowels found.
            return numberOfVowelsFound;
        }

        /// <summary>
        /// Finds the average length of a word in a string
        /// </summary>
        /// <param name="inputString">string to analyze</param>
        /// <returns>average length of characters in a word</returns>
        static double AverageWordLengthFinder8000(string inputString)
        {
            //counters to hold our values to calculate an average
            int totalNumberOfCharacters = 0;
            int totalNumberOfWords = 0;

            //we need to split a string into words
            //e.g. "hello|how|are|you"
            //this will split each word between a blank space and store them in an array
            string[] wordArray = inputString.Split(' ');

            //loop over each word in the wordArray
            for (int i = 0; i < wordArray.Length; i++)
            {
                //get the current word
                string currentWord = wordArray[i];
                //now let's process the word
                totalNumberOfWords++;
                totalNumberOfCharacters = totalNumberOfCharacters + currentWord.Length;
                // or totalNumberOfCharacters += currentWord.Length;
            }

            //return results as average (total value/number of items)
            return totalNumberOfCharacters / totalNumberOfWords;
        }

        /// <summary>
        /// Prints text to the screen like an old as hell computer
        /// </summary>
        /// <param name="inputString">text to print</param>
        /// <param name="pauseDuration">pause between chars in ms</param>
        static void oldTimeyTextPrinter(string inputString, int pauseDuration)
        {
            //loop over each char
            for (int i = 0; i < inputString.Length; i++)
            {
                //get a letter
                char letter = inputString[i];
                //Console.Write will print only single digits rather than strings
                Console.Write(letter);
                //pause
                System.Threading.Thread.Sleep(pauseDuration);
            }
            //after the text is complete, write a line break
            Console.WriteLine();
        }
    }
}