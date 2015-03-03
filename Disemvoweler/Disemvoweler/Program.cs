using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class Program
    {
        static void Main(string[] args)
        {

            //call our Disemvoweler
            Disemvoweler("Nickleback is my favorite band. Their songwriting can't be beat!");
            Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears?");
            Disemvoweler("I'm a code ninja, baby. I make the functions and I make the calls.");

            // keep the console open
            Console.ReadKey();
        }
        public static string Disemvoweler(string input)
        {
            //declare blank output variable
            string output = string.Empty;
            //declare blank vowel variable
            string vowels = string.Empty;

            //loop through each char
            for (int i = 0; i < input.Length; i++)
            {
                //put the current letter into a varible
                string letter = input[i].ToString();
                //determine if there is a vowel
                if ("aeiou".Contains(letter.ToLower()))
                {
                    //add letter to vowels
                    vowels += letter;
                }
                else if (" ".Contains(letter.ToLower()))
                {
                    //its a space, do nothing
                }
                else if ("?!.',".Contains(letter.ToLower()))
                {
                    //its a special character, do nothing
                }
                else
                {
                    //add everything else to output
                    output += letter;
                }
            }

            // Write input, output, & vowels
            Console.WriteLine("Original: " + input + "\n");
            Console.WriteLine("Disemvoweled: " + output + "\n");
            Console.WriteLine("Vowels Removed: " + vowels + "\n"); 
            // Return the Disemvoweled string as well for testing
            return output;
        }
    }
}
