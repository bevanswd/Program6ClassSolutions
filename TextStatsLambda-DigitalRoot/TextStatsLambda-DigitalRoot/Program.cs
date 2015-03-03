using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsLambda_DigitalRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            //digitalRoot call
            DigitalRoot("31337");
            DigitalRoot("45734");

            //digital root lambda
            Console.WriteLine(DigitalRootLambda("13885"));

            //inputString calls
            NumberOfWords("Mike's favorite color is blue.");
            NumberOfVowels("Mike's favorite color is blue.");
            NumberOfConsonants("Mike's favorite color is blue.");
            NumberOfSpecialCharacters("Mike's favorite color is blue.");
            LongestWord("Mike's favorite color is blue.");
            ShortestWord("Mike's favorite color is blue.");
        }

        public static int DigitalRoot(string rootThisNumber)
        {
            //while root number has more than 1 digit 
            while (rootThisNumber.Length > 1)
            {                //declare counting variable (INSIDE OF WHILE LOOP)
                int sum = 0;
                //loop through each digit
                foreach (char number in rootThisNumber)
                {
                    //add the sum of each digit to the sum variable
                    sum = sum + int.Parse(number.ToString());
                }
                //update rootThisNumber to total sum value (OUTSIDE OF FOREACH LOOP)
                rootThisNumber = sum.ToString();
            }
                //else write single digit value (OUTSIDE OF WHILE LOOP)
                Console.WriteLine(rootThisNumber);
                return int.Parse(rootThisNumber);
        }

        //LAMBDA VERSION
        public static int DigitalRootLambda(string root)
        {
            int totalSum = 0;
            while (root.Length > 1)
            {
                totalSum = root.Sum(x => int.Parse(x.ToString()));

                root = totalSum.ToString();
            }
            return totalSum;
        }

        public static int NumberOfWords(string inputString)
        {
            Console.WriteLine("# of Words: {0}", inputString.Split(' ').Length);
            return inputString.Replace("  ", " ").Split(' ').Length;
        }
        public static int NumberOfVowels(string inputString)
        {
            Console.WriteLine("# of Vowels: {0}", inputString.Count(x => "aeiou".Contains(char.ToLower(x))));
            return inputString.Count(x => "aeiou".Contains(x.ToString().ToLower()));
        }

        public static int NumberOfConsonants(string inputString)
        {
            Console.WriteLine("# of Consonants: {0}", inputString.Count(x => "bcdfghjklmnpqrstvwxyz".Contains(char.ToLower(x))));
            return inputString.Count(x => "bcdfghjklmnpqrstvwxyz".Contains(char.ToLower(x)));
        }

        public static int NumberOfSpecialCharacters(string inputString)
        {
            // .,?;'!@#$%^&*() and spaces are considered special characters
            Console.WriteLine("# of Spec Chars: {0}", inputString.Count(x => !char.IsLetter(x)));
            return inputString.Count(x => !char.IsLetter(x));
        }

        public static string LongestWord(string inputString)
        {
            Console.WriteLine("Longest Word: {0}", inputString.Replace("  ", " ").Split(' ').OrderByDescending(x => x.Length).First());
            return inputString.Replace("  ", " ").Split(' ').OrderByDescending(x => x.Length).First();
        }

        public static string ShortestWord(string inputString)
        {
            Console.WriteLine("Shortest Word: {0}", inputString.Replace("  ", " ").Split(' ').OrderBy(x => x.Length).First());
            return inputString.Replace("  ", " ").Split(' ').OrderBy(x => x.Length).First();
        }

    }
}
