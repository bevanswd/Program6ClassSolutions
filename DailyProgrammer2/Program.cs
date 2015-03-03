using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //test classes need to have the using statement

///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: 
///     Challenge Name: Accronym Expander
///     Challenge #: 193
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/2ptrmp/20141219_challenge_193_easy_acronym_expander/
///     Brief Description of Challenge: input an accronym, output the full text string
///
/// 
///
///     What was difficult about this challenge?
///     It was not difficult. I'm tight on time.
///
///     
///
///     What was easier than expected about this challenge?
///     it was very very easy. i'd like to do more challenging ones when I have the time.
///
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.

namespace DailyProgrammer_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting = "enter an accronym!";
            Console.WriteLine(greeting);
            AcronymAnalyzer(Console.ReadLine().ToLower());
            Console.ReadLine();
        }

        public static string AcronymAnalyzer(string text)
        {
            string fullWord;
            if (text.Contains("html"))
            {
                Console.WriteLine();
                fullWord = "HyperText Markup Language";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("css"))
            {
                Console.WriteLine();
                fullWord = "cascading style sheet";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("js"))
            {
                Console.WriteLine();
                fullWord = "javascript";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("mvc"))
            {
                Console.WriteLine();
                fullWord = "model view controller";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("lol"))
            {
                Console.WriteLine();
                fullWord = "laughing out loud";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("lmao"))
            {
                Console.WriteLine();
                fullWord = "laughing my ass off";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("dw"))
            {
                Console.WriteLine();
                fullWord = "don't worry";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("hf"))
            {
                Console.WriteLine();
                fullWord = "have fun";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("gg"))
            {
                Console.WriteLine();
                fullWord = "good game";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("brb"))
            {
                Console.WriteLine();
                fullWord = "be right back";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("g2g"))
            {
                Console.WriteLine();
                fullWord = "got to go";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("wtf"))
            {
                Console.WriteLine();
                fullWord = "what the fuck";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("wp"))
            {
                Console.WriteLine();
                fullWord = "well played";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("gl"))
            {
                Console.WriteLine();
                fullWord = "good luck";
                Console.WriteLine(fullWord);
            }
            else if (text.Contains("imo"))
            {
                Console.WriteLine();
                fullWord = "in my opinion";
                Console.WriteLine(fullWord);
            }
            else
            {
                Console.WriteLine();
                fullWord = "not an appropriate accronym, sorry";
                Console.WriteLine(fullWord);
            }
            return fullWord;
        }
    }


#region " TEST CLASS "

    //We need to use a Data Annotation [ ] to declare that this class is a Test class
    [TestFixture]
    class Test
    {
        //Test classes are declared with a return type of void.  Test classes also need a data annotation to mark them as a Test function
        [Test]
        public void MyValidTest()
        {
            //inside of the test, we can declare any variables that we'll need to test.  Typically, we will reference a function in your main program to test.
            string result = Program.AcronymAnalyzer("brb");  // this function should return 15 if it is working correctly
            //now we test for the result.
            Assert.IsTrue(result == "be right back", "This is the message that displays if it does not pass");
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
        }

        [Test]
        public void MyInvalidTest()
        {
            string result = Program.AcronymAnalyzer("brb");  // this function should return 15 if it is working correctly
            Assert.IsFalse(result == "");
        }
    }
#endregion
}