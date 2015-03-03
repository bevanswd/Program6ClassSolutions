using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingCoins
{
    class Program
    {
        static Random randomNumberGenerator = new Random();

        static void Main(string[] args)
        {
            //flip a coin 10 times
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(flipACoin());
            }
            //stop flipping coin when getting heads (return number of tries)
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(flipForHeads());
            }
            //keep window open
            Console.ReadKey();
        }

        /// <summary>
        /// Flips a "coin"
        /// </summary>
        /// <returns>returns a string of either heads or tails</returns>
        static string flipACoin()
        {
            int theFlip = randomNumberGenerator.Next(0, 2);
            if (theFlip == 0)
            {
                return "Heads";
            }
            return "Tails";
        }

        /// <summary>
        /// Flips a coin until heads
        /// </summary>
        /// <returns>number of tries it takes to flip heads</returns>
        static int flipForHeads()
        {
            //a "flag" to tell us when to escape the loop
            bool headsWasNotFlipped = true;
            //a counter to hold how many flips we've done
            int howManyFlips = 0;
            while (headsWasNotFlipped)
            {
                //the flip
                string theFlip = flipACoin();
                //counting the most recent coin flip
                howManyFlips++;
                if (theFlip == "Heads")
                {
                    //if it's a head, kill the loop
                    headsWasNotFlipped = false;
                }
            }
            return howManyFlips;
        }
    }
}