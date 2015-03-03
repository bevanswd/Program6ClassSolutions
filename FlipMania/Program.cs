using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public static Random rng = new Random();
        static void Main(string[] args)
        {
            FlipCoins(10000);
            FlipForHeads(10000);
        }

        static void FlipCoins(int numberOfFlips)
        { 
            //check for valid input
            if (numberOfFlips > 0)
            {
                int numberOfHeads = 0;
                int numberOfTails = 0;
                Random rng = new Random();

                //Flip a number of times
                for (int i = 0; i < numberOfFlips; i++)
                {
                    //determine heads or tails and log it
                    if (rng.Next(0, 2) == 0)
                    {
                        //heads
                        numberOfHeads++;
                    }
                    else
                    {
                        //tails
                        numberOfTails++;
                    }
                }

                //write the results to the console
                Console.WriteLine("we flipped a coin " + numberOfFlips + " times");
                Console.WriteLine("number of heads: " + numberOfHeads);
                Console.WriteLine("number of tails: " + numberOfTails);
            }
        }

        static void FlipForHeads(int numberOfHeads)
        { 
            //check for valid input
            if (numberOfHeads > 0)
            {
                int numberOfHeadsFlipped = 0;
                int totalFlips = 0;

                //flip until there are enough heads found
                while (numberOfHeadsFlipped <= numberOfHeads)
                { 
                    //incrementing if there is a head found
                    if (rng.Next(0, 2) == 0)
                    { 
                        //heads
                        numberOfHeadsFlipped++;
                    }
                    totalFlips++;
                }

                //write the output to the console
                Console.WriteLine("We are flipping a coin until we find " + numberOfHeads + " heads");
                Console.WriteLine("it took " + totalFlips  +  " flips to find " + numberOfHeads + " heads");
            }
        }
    }
}
