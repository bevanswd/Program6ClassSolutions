using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 21; i++)
            {
            Console.WriteLine(FizzBuzz());
            }
            Console.ReadKey();

        }
        public static string FizzBuzz(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                {
                    return "FizzBuzz";
                }
            else if (number % 3 == 0)
                {
                    return "Buzz";
                }
            else if (number % 5 == 0)
                {
                    return "Fizz";
                }
                else
                {
                    return number.ToString();
                }
        }
    }
}
