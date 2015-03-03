using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            //calling the function with $4.19.  
            //Notice that when using the decimal format you must end numbers with an 'm'
            CashAmount(209.49);
            ChangeAmount(209.49m);

            Console.ReadKey();
        }

        public static Change CashAmount(int amount)
        {
            //this is our object that will hold the data of how many coins of each type to return
            Change amountAsCash = new Change();

            //TODO: Fill in the the code to make this function work
            ///////////////////////////////////////////////////////
            //for loop to decrement the int for whole bills
            for (int i = amount; i >= 1; i--)
            {
                //check if amount is $100.00 or over
                while (amount >= 100)
                {
                    //add 100 dollars to dollar100 value
                    amountAsCash.dollar100++;
                    //subtract 100 dollars from total amount
                    amount -= 100;
                }
                //check if amount is $50.00 or over
                while (amount >= 50)
                {
                    //add 50 dollars to dollar50 value
                    amountAsCash.dollar50++;
                    //subtract 50 dollars from total amount
                    amount -= 50;
                }
                //check if amount is $20.00 or over
                while (amount >= 20)
                {
                    //add 20 dollars to dollar20 value
                    amountAsCash.dollar20++;
                    //subtract 20 dollars from total amount
                    amount -= 20;
                }
                //check if amount is $10.00 or over
                while (amount >= 10)
                {
                    //add 10 dollars to dollar10 value
                    amountAsCash.dollar10++;
                    //subtract 10 dollars from total amount
                    amount -= 10;
                }
                //check if amount is $5.00 or over
                while (amount >= 5)
                {
                    //add5 dollars to dollar5 value
                    amountAsCash.dollar5++;
                    //subtract 5 dollars from total amount
                    amount -= 5;
                }
                //check if amount is $1.00 or over
                while (amount >= 1)
                {
                    //add a dollar to dollar1 value
                    amountAsCash.dollar1++;
                    //subtract 1 dollar from total amount
                    amount -= 1;
                }

                //write output to console
                Console.WriteLine("Cash($100): " + amountAsCash.dollar100);
                Console.WriteLine("Cash($50): " + amountAsCash.dollar50);
                Console.WriteLine("Cash($20): " + amountAsCash.dollar20);
                Console.WriteLine("Cash($10): " + amountAsCash.dollar10);
                Console.WriteLine("Cash($5): " + amountAsCash.dollar5);
                Console.WriteLine("Cash($1): " + amountAsCash.dollar1);

            }
        
        }

        public static Change ChangeAmount(decimal amount)
        {

            //for loop to decrement the decimal, starting from the change amount and ending at 0
            for (decimal i = amount; i > 0m; i--)
            {
                //check if amount is $0.25 or over
                while (amount >= .25m)
                {
                    //add a quarter to quarter value
                    amountAsChange.Quarters++;
                    //subtract 25 cents from total amount
                    amount -= .25m;
                }
                //check if amount is $0.10 or over
                while (amount >= .10m)
                {
                    //add a dime to dime value
                    amountAsChange.Dimes++;
                    //subtract 10 cents from total amount
                    amount -= .10m;
                }
                //check if amount is $0.05 or over
                while (amount >= .05m)
                {
                    //add a nickle to nickle value
                    amountAsChange.Nickles++;
                    //subtract 05 cents from total amount
                    amount -= .05m;
                }
                //check if amount is $0.01 or over
                while (amount >= .01m)
                {
                    //add a penny to penny value
                    amountAsChange.Pennies++;
                    //subtract 01 cents from total amount
                    amount -= .01m;
                }

                //write output to console
                Console.WriteLine("Quarters: " + amountAsChange.Quarters);
                Console.WriteLine("Dimes: " + amountAsChange.Dimes);
                Console.WriteLine("Nickles: " + amountAsChange.Nickles);
                Console.WriteLine("Pennies: " + amountAsChange.Pennies);

                //return our Change Object
                return amountAsChange;
            }
        }

        /// <summary>
        /// Example using the Change class to store data
        /// </summary>
        public static Change Example(decimal amount)
        {
            //creating a new object of our class Change
            Change amountAsChange = new Change();

            //increasing the number of quarters
            amountAsChange.Quarters++;
            amountAsChange.Quarters += 1;
            amountAsChange.Quarters = amountAsChange.Quarters + 1;


            //outputting to the console
            Console.WriteLine("Quarters: " + amountAsChange.Quarters);

            //returning the object
            return amountAsChange;
        }

    }

    public class Change
    {
        public int dollar100 { get; set; }

        public int dollar50 { get; set; }

        public int dollar20 { get; set; }

        public int dollar10 { get; set; }

        public int dollar5 { get; set; }

        public int dollar1 { get; set; }

        /// <summary>
        /// This is property to hold the number of Quarters to be returned as change
        /// </summary>
        public int Quarters { get; set; }

        /// <summary>
        /// This is property to hold the number of Dimes to be returned as change
        /// </summary>
        public int Dimes { get; set; }

        /// <summary>
        /// This is property to hold the number of Nickles to be returned as change
        /// </summary>
        public int Nickles { get; set; }

        /// <summary>
        /// This is property to hold the number of Pennies to be returned as change
        /// </summary>public int Nickles { get; set; }
        public int Pennies { get; set; }

        /// <summary>
        /// This is a constructor, it initializes a new instance of the class (called an object).  This sets it's default values.
        /// </summary>
        public Change()
        {
            this.dollar100 = 0;
            this.dollar50 = 0;
            this.dollar20 = 0;
            this.dollar10 = 0;
            this.dollar5 = 0;
            this.dollar1 = 0;
            this.Quarters = 0;
            this.Dimes = 0;
            this.Nickles = 0;
            this.Pennies = 0;
        }
    }
}
