using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARING VARIABLES
            // 1. Declare a string variable called "myName" and set it equal to your name
            string myName = "Brandon Evans";
            // 2. Declare a number varible called "myAge" and set it equal to your age
            int myAge = 23;
            // 3. Declare a boolean value called "myBool" and set it equal to true or false;
            bool myBool = true;
            // 4. Declare a new list of strings called "productsList" and set it equal to "basketball", "baseball glove", "tennis shoes", "hockey puck"
            // List<string> productList = new List<string>() {"basketball", "baseball glove", "tennis shoes", "hockey puck"};
            // productList.Add();
            string[] productList = { "basketball", "baseball glove", "tennis shoes", "hockey puck" };

            // PRINTING VARIABLES TO THE CONSOLE USING CONSOLE.WRITELINE()
            // 1. Print your name to the console using the format: "My name is <myName> and I'm a beast of a programmer"
            Console.WriteLine("My name is " + myName + " and I'm a beast of a programmer");
            // 2. Print out your age to the console using the format: "I am <myAge> years awesome."
            Console.WriteLine("I am " + myAge + " years awesome.");
            // 3. Print out your boolean value using the format: "I set my boolean value equal to <myBool>"
            Console.WriteLine("I set my boolean value equal to " + myBool);
            // 4. Using a For loop, print out each value in productsList.
            for (int i = 0; i < productList.Count; i++)
            {
                //////////////////productList.ElementAt(i)
                Console.WriteLine(productList[i]);
            }

            // FOR LOOP PRACTICE
            // 1. Create a for loop that prints out the numbers 1 to 10.
            for (int i = 1; i <= 10; i++) 
            {
                Console.WriteLine(i);
            }
            // 2. Create a for loop that prints out the numbers 10 to 1.
            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
            // 3. Create a for loop that prints out the numbers 10 to 30, only printing the even numbers
            for (int i = 10; i <= 30; i++)
            {
                if (i == 10 || i == 12 || i == 14 || i == 16 || i == 18 || i == 20 || i == 22 || i == 24 || i == 26 || i == 28 || i == 30) 
                {
                Console.WriteLine(i);
                }
            }
            // 4. Create a for loop that prints out the numbers 100 to 75, only printing every 5th number (100, 95, 90, 85, 80, 75)
            for (int i = 100; i >= 75; i--)
            {
                if (i == 100 || i == 95 || i == 90 || i == 85 || i == 80 || i == 75)
                {
                    Console.WriteLine(i);
                }
            }

            // WHILE LOOP PRACTICE
            // 1. Create a while loop that prints out the numbers from 1 to 10.
            int j = 0;
            while (j <= 10) 
            {
                Console.Write(j);
                j++;
            }
            // 2. Create a while loop that prints out the numbers from 10 to 1.
            int k = 10;
            while (k >= 1)
            {
                Console.Write(k);
                k--;
            }
            // 3. Create a while loop that prints out the numbers from 15 to 30, only printing the even numbers
            int g = 15;
            while (g <= 30)
            {
                g++;
                if (g == 16 || g == 18 || g == 20 || g == 22 || g == 24 || g == 26 || g == 28 || g == 30)
                {
                    Console.Write(g);
                }
            }
            // 4. Create a while loop that prints out the numbers from 100 to 75, only printing every 5th number (100, 95, 90, 85, 80, 75)
            //counter = 100;
            //while (counter >= 75)
            //{
            //Console.WriteLine(counter);
            //counter -= 5;
            //}
            int f = 100;
            while (f >= 75)
            {
                f++;
                if (f == 100 || f == 95 || f == 90 || f == 85 || f == 80 || f == 75)
                {
                    Console.Write(f);
                }
            }
            // 5. Create a while loop that prints out the numbers from 1 to 10 until it reaches one that is divisible by 4.
            //counter = 1;
            //while (counter % 4 != 0)
            //{
            //Console.WriteLine(counter);
            //counter++;
            //}
            int d = 1;
            while ((d <=10) && (d % 4 == 0))
            {
                d++;
                Console.Write(d);
            }

            // PUTTING IT TOGETHER
            // Use either FOR or WHILE loops to accomplish the following:
            // 1. Print out the number of letters in your name using the format: "My name, <myName>, has <number of letters> in it."
            int nameLetters = 0;
            for (int i = 0; i < myName.Length; i++)
            {
                nameLetters++;
            }
            Console.WriteLine("My name, " + myName + " has " + nameLetters + " letters in it");
            // 2. Print out the number of items in your list using the format: "My product list has <number of items> in it."
            Console.WriteLine("My product list has " + productList.Length + " items in it");
            // 3. Print out the number of letters of each item in productsList using the format: "<product> has <number of letters> in it."
            Console.WriteLine(productList[0] + " has " + productList[0].Length + " letters in it");
            Console.WriteLine(productList[1] + " has " + (productList[1].Length - 1) + " letters in it");
            Console.WriteLine(productList[2] + " has " + (productList[2].Length - 1) + " letters in it");
            Console.WriteLine(productList[3] + " has " + (productList[3].Length - 1) + " letters in it");


            //FUNCTION CALL MADNESS!
            // 1. Call your SuperLoop function using the following parameters:
            //      startNum = Call RealMultiply with the parameters 1, 5
            //      endNum = Call TripleIt with the parameter myAge
            //      increment = Call TripleIt with the parameter of myAge minus 10

            int myAge = 23;
            SuperLoop(RealMultiply(1, 5), TripleIt(myAge), TripleIt(myAge - 10));
            // 2. Call your SuperLoop function using the following parameters:
            //      startNum = Call RealMultiply with the parameters 1, and TripleIt with the parameter of 3.
            //      endNum = Call TripleIt with the parameter RealMultiply with the parameters: myAge, 7
            //      increment = Call TripleIt with the parameter of myAge minus RealMultiply with the parameters 2, 4.
            SuperLoop(RealMultiply(1, TripleIt(3)), TripleIt((RealMultiply(myAge, 7))), TripleIt(myAge - (RealMultiply(2, 4))));

            //keep window open
            Console.ReadKey();

        }
            // DECLARING AND CALLING FUNCTIONS
            // 1. Create a function called "Greeting" that takes one string parameter called "name".  This function will print "Hello <name>"
        
            static string Greeting (string name) 
            {
                return ("Hello " + name);
            // 2. Call the Greeting function by passing in "Geronimo Jackson" as your parameter.
                Console.WriteLine(Greeting("Geronimo Jackson"));
            // 3. Call the Greeting function by passing in myName as your parameter.
                string myName = "Brandon";
                Console.WriteLine(Greeting(myName));
            }
            
            // 4. Create a function called "DoubleIt" that takes one integer parameter called "number".  This function will print "<number> doubled is <number * 2>"
            static string DoubleIt(int number)
            {
                return (number + " doubled is " + (number*2));
                
            // 5. Call your DoubleIt Function by passing in 1337 as your parameter.
                Console.WriteLine(DoubleIt(1337));
            // 6. Call your DoubleIt function by passing in myAge as your parameter.
                int myAge = 23;
                Console.WriteLine(DoubleIt(myAge));
            }
            // 7. Create a function called "Multiply" that takes two integer parameters called "num1" and "num2".  This function will print "<num1> times <num2> is <num1 * num2>"
            static string Multiply(int num1, int num2)
            {
                return (num1 + " times " + num2 + " is " + (num1*num2));
            // 8. Call your Multiply function by passing in 2 and 8 as your parameters.
                Console.WriteLine(Multiply(2,8));
            // 9. Call your Multiply function by passing in 3 and myAge as your parameters.
                int myAge = 23;
                Console.WriteLine(Multiply(3,myAge));

            }
            // 10. Create a function called "LoopThis" that takes two integer parameters called "startNum" and "endNum".  
            //      This function will print out: 
            //          a. "I'm looping from <startNum> to <endNum>."  
            //          b. The numbers from startNum to endNum, one per line.  
            static string LoopThis(int startNum, int endNum)
            {
                return ("I'm looping from " + startNum + " to " + endNum);
                for (int i = startNum; i <= endNum ; i++) 
                {
                    Console.WriteLine(i);
                }
            // 11. Call your LoopThis function by passing in 20 and 30 as your parameters.
                Console.WriteLine(LoopThis(20,30));
            // 12. Call your LoopThis function by passing in 0 and myAge as your parameters.
                int myAge = 23;
                Console.WriteLine(LoopThis(0,myAge));

            }
            // 13. Create a function called "SuperLoop" that takes three integer parameters called "startNum", "endNum", and "increment".  
            //      You will need to track how many times the loop has been executed in a variable called "loopCount".
            //      This function will print out: 
            //          a. "I'm looping from <startNum> to <endNum>, incrementing <increment> each time"  
            //          b. The numbers from startNum to endNum, one per line.
            //          c. "That loop was craaaaaazy, we looped X times"
            static string SuperLoop(int startNum, int endNum, int increment)
            {
                int loopCount = 0;
                return ("I'm looping from " + startNum + " to " + endNum + ", incrementing by " + increment + " each time");
                for (int i = startNum; i <= endNum ; i++) 
                {
                    Console.WriteLine(i);
                    loopCount = loopCount + 1;
                }
                return ("That loop was craaaaaazy, we looped " + loopCount + "times");
                
            
            // 14. Call your SuperLoop function by passing in 0, 100, and 15 as your parameters.
                SuperLoop(0, 100, 15);
            // 15. Call your SuperLoop function by passing in 0, 200, and myAge as your parameters.
                int myAge = 23;
                SuperLoop(0, 200, myAge);
            }
            //DECLARING AND CALLING RETURN FUNCTIONS
            // 1. Create a function called "NewGreeting" that takes one string parameter called "name".  This function will return a string in the format of "Hello, <name>"
            static string NewGreeting(string name)
            { 
                return ("Hello, " + name);
        
            // 2. Using your NewGreeting function as the parameter for Console.WriteLine(), call your NewGreeting function using the parameter "Neil deGrasse-Tyson"
            Console.WriteLine(NewGreeting("Neil deGrasse-Tyson"));
            // 3. Using your NewGreeting function as the parameter for Console.WriteLine(), call your NewGreeting function using the parameter myName.
            string myName = "Brandon";
            Console.WriteLine(NewGreeting(myName));
            }
            // 4. Create a function called "TripleIt" that takes one integer parameter called "number".  This function will return the number times 3.
            static int TripleIt(int number) 
            {
                return (number * 3);
            
            // 5. Using your TripleIt function as part of the parameter for Console.WriteLine(), 
            //      call your TripleIt function using the parameter of 10 to print out "10 tripled is <TripleIt Function Call>"
                Console.WriteLine(number + " tripled is " + TripleIt(10));
            // 6. Using your TripleIt function as part of the parameter for Console.WriteLine(), 
            //      call your TripleIt function using the parameter of myAge to print out "<myAge> tripled is <TripleIt Function Call>"
                int myAge = 23;
                Console.WriteLine(myAge + " tripled is " + TripleIt(myAge));
            }
            // 7. Create a function called "RealMultiply" that takes two integer parameters called "num1", and "num2".  This function will return the num1 * num2.
            static int RealMultiply(int num1, int num2)
            {
                return (num1 * num2);
            // 8. Using your RealMultiply function as part of the parameter for Console.WriteLine(), 
            //      call your RealMultiply function using the parameter of 5 and 10 to print out the returned value from your function.
                Console.WriteLine(RealMultiply(5, 10));
            // 9. Using your RealMultiply function as part of the parameter for Console.WriteLine(), 
                //      call your RealMultiply function using the parameter of 2 and myAge to print out the returned value from your function.
                int myAge = 23;
                Console.WriteLine(RealMultiply(2, myAge));
            }
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            static void Multiply(int num1, int num2)
            {
                Console.WriteLine("{0} multiplied by {1} equals {2}", num1, num2, (num1 * num2));
            }

            static void LoopThis(int startNum, int endNum)
            {
                Console.WriteLine("I'm looping from {0} to {1}");
                for (int i = startNum; i <= endNum; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }