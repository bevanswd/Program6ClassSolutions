using System;
using System.Collections.Generic;
using System.Linq;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        /// <summary>
        /// A function that calculates the starting value of the longest Collatz sequence.
        /// This function will start at 1 million and look at which value generates the
        /// longest sequence.
        /// </summary>
        /// <returns>Starting value of the longest sequence</returns>
        public static long LongestCollatzSequence()
        {
            //set output vars
            int maxCount = 0;
            int maxNumber = 0;

            //loop sequence through 999999 digits
            for (int i = 1; i < 999999; i++)
            {
                //set iteration to long variable to count through
                long n = i;
                //set count to 1
                int count = 1;
                while (n != 1)
                {
                    if (n % 2 == 0)
                    {
                        //check if even
                        n = n / 2;
                    }
                    else
                    {
                        //check if odd
                        n = n * 3 + 1;
                    }
                    //add to count
                    count++;
                }
                //check if count is higher than maxCount
                if (maxCount < count)
                {
                    //set maxCount to count and maxNumber current number in iteration
                    maxCount = count;
                    maxNumber = i;
                }
            }
            return maxNumber;
        }

        /// <summary>
        /// A Function that adds up each even number in a Fibonacci Sequence until the maxValue
        /// then prints the sum of those numbers to the console
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns>The sum of every even number for the given number of Fibonacci digits</returns>
        public static long EvenFibonacciSequencer(long maxValue)
        {
            long thisNumber = 2;
            long lastNumber = 1;
            long totalEvenNumbers = 2;
            long fibonacciNumber = lastNumber + thisNumber;

            while (fibonacciNumber < maxValue)
            {
                if (fibonacciNumber % 2 == 0) 
                {
                    totalEvenNumbers += fibonacciNumber;
                }
                lastNumber = thisNumber;
                thisNumber = fibonacciNumber;
                fibonacciNumber = lastNumber + thisNumber;
            }
            return totalEvenNumbers; // Default return value, replace this
        }

        /// <summary>
        /// Function that finds the n'th prime indicated by the parameter
        /// </summary>
        /// <param name="maxPrime"></param>
        /// <returns>The prime number which is the n'th found</returns>
        public static int FindNPrimes(int maxPrime)
        {
            //start with initial prime number
            int prime = 3;
            //determine current number in the sequence
            int currentNumber = 2;
            //
            while (currentNumber < maxPrime)
            {
                //skip even numbers
                prime += 2;
                //find prime
                if (IsPrime(prime)) 
                {
                    //add to current number
                    currentNumber++; 
                }
            }
            return prime; // Default return value, replace this
        }

        /// <summary>
        /// distinguishes prime numbers
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrime(int number)
        {
            bool currentPrime = true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    currentPrime = false;
                    break;
                }
            }
            return currentPrime;
        }
    }
}
