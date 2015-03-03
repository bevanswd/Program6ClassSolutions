using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //FizzBuzz call
            for(int i = 0; i < 21; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
            for (int i = 92; i >= 79; i--)
            {
                Console.WriteLine(FizzBuzz(i));
            }

            //Yodaizer call
            Console.WriteLine(Yodaizer("full pot coffee the keep"));
            Console.WriteLine(Yodaizer("challenge code"));

            //TextStats call
            TextStats("wofi kof., ,?? kd");

            //IsPrime call
            IsPrime(20);

            //DashInsert call
            Console.WriteLine(DashInsert(454793));
            Console.WriteLine(DashInsert(8675309));

            Console.ReadKey();
        }

        /// <summary>
        /// loop through set of ints. if int is divisible by 5, print "Fizz"; 3, print "Buzz"; both print "FizzBuzz"
        /// </summary>
        /// <param name="number">input integer</param>
        /// <returns>list of numbers, specifying those divisible by "5" and "3" with "Fizz" and "Buzz"</returns>
        public static string FizzBuzz(int number)
        {
            if ((number % 5 == 0) && (number % 3 == 0))
                {
                    return "FizzBuzz";
                }
                else if (number % 5 == 0)
                {
                    return "Fizz";
                }
                else if (number % 3 == 0)
                {
                    return "Buzz";
                }
                else 
                {
                    return number.ToString();
                }
        }

        /// <summary>
        /// reads string, prints words out backwards (separated by blank spaces)
        /// </summary>
        /// <param name="text">input string</param>
        /// <returns>backwards printed sentence</returns>
        public static string Yodaizer(string text)
        {
            //contain words (text between blank space) into an array
            string[] words = text.Split(' ');
            //reverse their order
            Array.Reverse(words);
            //return the string with the words in their now-reversed order
            return string.Join(" ", words);
        }

        /// <summary>
        /// loop through chars in a string, check for char count, word count, vowels, consonants, and specialChars
        /// </summary>
        /// <param name="input">input string parameter</param>
        public static void TextStats(string input)
        {
            //declare an int to contain the number of special chars in the input string   
            int chars = input.Length;
            //declare int to find words between spaces (using .Split()). count and add to list
            int words = input.Split(' ').ToList().Count;
            //declare ints to hold each type of char
            int vowels = 0;
            int consonants = 0;
            int specialChars = 0;

            //count the chars in the string
            for (int i = 0; i < input.Length; i++)
            {
                //grab current letter from the input (toLower to standardize)
                string letter = input[i].ToString().ToLower();

                //check for vowels
                if ("aeiou".Contains(letter))
                { 
                    //if it contains a vowel, add it
                    vowels++;
                }
                //check for specialChars
                else if (".,?".Contains(letter))
                {
                    //add to specialChars if letter is . , or ?
                    specialChars++;
                }
                //else it's a consonant
                else 
                { 
                    //add to consonant
                    consonants++;
                }
            }
            //loop through all letters, print output
            Console.WriteLine(input);
            Console.WriteLine("# Chars: " + chars);
            Console.WriteLine("# Words: " + words);
            Console.WriteLine("# Vowels: " + vowels);
            Console.WriteLine("# Consonants: " + consonants);
            Console.WriteLine("# Spec Chars: " + specialChars);
        }

        /// <summary>
        /// loop through set of numbers, check for primes
        /// </summary>
        /// <param name="number"></param>
        public static bool IsPrime(int number)
        {
            //even numbers can not be prime
            if (number % 2 == 0) { return false; }
            //check each number
            for (int i = 3; i < number; i += 2)
            {
                if (number % i == 0)
                {
                    //return prime as false
                    return false;
                }
            }
            //return prime as true
            return true;
        }

        /// <summary>
        /// insert dash between two odd numbers
        /// </summary>
        /// <param name="number">input integer</param>
        /// <returns>return printed number with dashes</returns>
        public static string DashInsert(int number)
        {
            //declare string to contain output
            string output = string.Empty;
            //declare string to hold number as a string (convert input number to a string)
            string numberString = number.ToString();
            //loop through each index in the string
            for (int i = 0; i < numberString.Length - 1; i++)
            {
                //get value of current index and the one after it
                int num1 = int.Parse(numberString[i].ToString());
                int num2 = int.Parse(numberString[i + 1].ToString());
                //check if they're odd
                if (num1 % 2 != 0 && num2 % 2 != 0)
                {
                    //if both are odd, add dash to output string
                    output += num1 + "-";
                }
                else
                {
                    //else just output numbers like normal
                    output += num1;
                }
            }
            //add the last digit to output
            output += numberString[numberString.Length - 1];
            //print output
            return output;
        }
    }
}