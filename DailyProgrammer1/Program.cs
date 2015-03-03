using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //test classes need to have the using statement

///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: Brandon Evans
///     Challenge Name: Word Counting
///     Challenge #: 191
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/2nynip/2014121_challenge_191_easy_word_counting/
///     Brief Description of Challenge: Count the number of words in a string of text
///
/// 
///
///     What was difficult about this challenge?
///     was not difficult, i'm tight on time.
///
///     
///
///     What was easier than expected about this challenge?
///     yes it was very easy. would like to do more challenging exercises time permitting
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
            int tempCount = GetWord("the");
            Console.ReadLine();
        }

        public static int GetWord(string word)
        {
            string text = "When Apollo reveals himself to Achilles, the Trojans had retreated into the city, all except for Hector, who, having twice ignored the counsels of Polydamas, feels the shame of rout and resolves to face Achilles, in spite of the pleas of Priam and Hecuba, his parents. When Achilles approaches, Hector's will fails him, and he is chased around the city by Achilles. Finally, Athena tricks him to stop running, and he turns to face his opponent. After a brief duel, Achilles stabs Hector through the neck. Before dying, Hector reminds Achilles that he is fated to die in the war as well. Achilles takes Hector's body and dishonours it.";
            word = "the";
            int count = 0;
            string[] splitWords = text.Split(' ');
            for (int i = 0; i < splitWords.Length; i++)
            {
                if (splitWords[i] == word)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            return count;
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
            int count = Program.GetWord("the");  // this function should return 15 if it is working correctly
            //now we test for the result.
            Assert.IsTrue(count == 8, "This is the message that displays if it does not pass");
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
        }

        [Test]
        public void MyInvalidTest()
        {
            int count = Program.GetWord("the"); 
            Assert.IsFalse(count == 6);
        }
    }
#endregion
}
