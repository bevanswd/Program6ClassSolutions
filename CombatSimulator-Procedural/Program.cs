using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSim
{
    class Program
    {
        static void Main(string[] args)
        {
            //write welcome greeting to the console
            System.Threading.Thread.Sleep(00);
            Console.WriteLine("Welcome to Combat Simulator!");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("You are facing a dangerous foe.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nThis foe is Bruce Lee.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("He is twice as resiliant as you.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nbut you have an advantage...");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("You have a cold!");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("and it is contagious!!");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nSneeze on your enemy to strike EVERY time.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nOtherwise, you can try to pimp smack him.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("but be warned, he is fast and can dodge your attack!");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nDrink some tussin to heal you up. but don't get too healed.");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("You're gonna need that Rhinovirus to take down Master Lee!");
            Console.WriteLine();

            //keep console open (wait for user to press key)
            Console.ReadKey();
            //clear console
            Console.Clear();
            //Play Game
            CombatSim();

            //wait for user input
            Console.ReadKey();
        }

        /// <summary>
        /// main game function
        /// </summary>
        static void CombatSim()
        {
            //declare initial variables
            int playerHP = 100;
            int enemyHP = 200;

            //create random number generator
            Random rng = new Random();

            //main loop will continue the game for as long as players still have HP
            while (playerHP > 0 && enemyHP > 0)
            {
                //display HP stats to the user
                Console.WriteLine("Your HP: " + playerHP);
                Console.WriteLine("Bruce's HP: " + enemyHP);
                Console.WriteLine();

                //call attackChoice function in a string (will take-in user input to determine attack choice)
                string attack = attackChoice();

                //player text color
                Console.ForegroundColor = ConsoleColor.Cyan;

                //attack choices
                if (attack == "1")
                {
                    //pimp smack (hits 70% of the time for 15-20 damage)
                    if (rng.Next(1, 11) > 3)
                    {
                        //hit
                        int damage = rng.Next(15, 21);
                        Console.WriteLine("\nYou pimp smacked Bruce Lee for " + damage + " damage. He didn't see that one coming!");
                        enemyHP -= damage;
                    }
                    else
                    {
                        //miss
                        Console.WriteLine("\nHe dodged! how embarassing. Looks like Bruce Lee is more of a pimp than you.");
                    }
                }
                else if (attack == "2")
                {
                    //sneeze (hits for 10-15 damage)
                    int damage = rng.Next(10, 16);
                    Console.WriteLine("\nA CRITICAL HIT! You sneezed on Bruce Lee, he took " + damage + " damage.");
                    enemyHP -= damage;
                }
                else if (attack == "3")
                {
                    //drink tussin (heals 10-15 hp)
                    int heal = rng.Next(10, 16);
                    Console.WriteLine("\nYou drink some tussin. How vitalizing! +" + heal + "HP restored");
                    playerHP += heal;
                }

                //reset text color
                Console.ResetColor();

                //continue to enemy attack
                Console.ReadKey(true);

                //enemy text color
                Console.ForegroundColor = ConsoleColor.Red;

                //enemy attack (80% chance to hit, for 10-15 damage)
                if (rng.Next(1, 5) > 1)
                {
                    //hit
                    int damage = rng.Next(10, 16);
                    Console.WriteLine("\nBruce Lee roundhouse-kicked your face! you take " + damage + " damage! \nbut your sinuses do seem to be clearing up. What a considerate man.");
                    playerHP -= damage;
                }
                else
                {
                    //miss
                    Console.WriteLine("\nYou dodged Bruce Lee's attack! He seems distracted by a sniffly nose!");
                }
                
                //reset text color
                Console.ResetColor();
                //wait for user input
                Console.ReadKey();
                //clear console for game over message
                Console.Clear();

            }

            //end game
            if (playerHP > 0)
            {
                //win
                Console.WriteLine("You killed Bruce Lee!");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("wait, Bruce Lee is already dead...");
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("so who is this guy?\n");
            }
            else
            {
                //lose
                Console.WriteLine("Bruce Lee put you out of your misery.");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("You never really stood a chance anyway.");
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("At least you don't have a cold anymore.\n");
            }

            //wait for user input to quit game
            Console.ReadKey();
        }

        /// <summary>
        /// player's 3 attack choice options
        /// </summary>
        /// <returns></returns>
        static string attackChoice()
        {
            int attackChoice = 0;
            //display attack choices to the user
            Console.WriteLine("Choose your next move:");
            Console.WriteLine("1. pimp-smack");
            Console.WriteLine("2. sneeze");
            Console.WriteLine("3. drink tussin");
            Console.WriteLine();

            //assign string variable to store user input
            string input;
            input = Console.ReadLine();
            int.TryParse(input, out attackChoice);
            //return updated input string value if it's a '1', '2' or '3'
            if (attackChoice == 1 || attackChoice == 2 || attackChoice == 3)
            {
                return input;
            }
            else 
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                Console.WriteLine("oops! looks like you tripped.");
                return "what?";
            }
        }

    }
}