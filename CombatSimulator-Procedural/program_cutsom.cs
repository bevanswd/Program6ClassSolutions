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
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Welcome to Combat Simulator! You are facing a dangerous foe.");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("This foe is Bruce Lee. He is twice as resiliant as you, but you have an advantage...");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("You have a cold! and it is contagious!! sneeze on your enemy to strike EVERY time");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Otherwise, you can try to pimp smack him. but be warned, he is fast and can dodge your attack!");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Drink some tussin to heal you up. but don't get too healed. You're gonna need that rhinovirus to take down Master Lee!");

            Console.ReadKey();
            //Play Game
            CombatSim();
            Console.ReadKey();
        }

        static void CombatSim()
        { 
            //declare initial variables
            int playerHP = 100;
            int enemyHP = 200;
            Random rng = new Random();

            //main while loop will continue the game for as long as players still have HP
            while (playerHP > 0 && enemyHP > 0)
            { 
                //display HP stats to the user
                Console.WriteLine("Your HP: " + playerHP);
                Console.WriteLine("Bruce's HP: " + enemyHP);
                Console.WriteLine();

                //call attackChoice function in a string, prompt user to choose an attack
                string attack = attackChoice();

                //attack choices
                if (attack == "1")
                {
                    //pimp smack (hits 70% of the time for 15-20 damage)
                    if (randomNumberGenerator.Next(1, 11) > 3)
                    {
                        //hit
                        int damage = randomNumberGenerator.Next(15, 21);
                        Console.WriteLine("You pimp smacked Bruce Lee for " + damage + " damage. He didn't see that one coming!");
                        enemyHP -= damage;
                    }
                    else
                    {
                        //miss
                        Console.WriteLine("He dodged! how embarassing. Looks like Bruce Lee is more of a pimp than you.");
                    }
                }
                else if (attack == "2")
                {
                    //sneeze (hits for 10-15 damage)
                    int damage = randomNumberGenerator.Next(10, 16);
                    Console.WriteLine("A CRITICAL HIT! You sneezed on Bruce Lee, he took " + damage + " damage.");
                    enemyHP -= damage;
                }
                else
                {
                    //drink tussin (heals 10-15 hp)
                    int heal = randomNumberGenerator.Next(10, 16);
                    Console.WriteLine("You drink some tussin. How vitalizing! +" + heal + "HP restored");
                    playerHP += heal;
                }

                //enemy attack
                // 80% chance to hit, for 10-15 damage
                if (randomNumberGenerator.Next(1, 5) > 1)
                {
                    //hit
                    int damage = randomNumberGenerator.Next(10, 16);
                    Console.WriteLine("Bruce Lee roundhouse-kicked your face! you take " + damage + " damage! but your sinuses do seem to be clearing up. What a considerate man.");
                    playerHP -= damage;
                }
            }

            //end game
            if (playerHP > 0)
            {
                //win
                Console.WriteLine("You killed Bruce Lee! wait, bruce lee is already dead. so who is this guy?");
            }
            else
            {
                //lose
                Console.WriteLine("Bruce Lee put you out of your misery. You never really stood a chance anyway. At least you don't have a cold anymore.");
            }
        }

        /// <summary>
        /// player's 3 choice options
        /// </summary>
        /// <returns></returns>
        static string GetUserAttackChoice()
        {
            Console.WriteLine(@"Choose your next move:
1. pimp-smack
2. sneeze
3. drink tussin");
            string input;
            do
            {
                //get user input
                input = Console.ReadLine();
            } while (input != "1" && input != "2" && input != "3");
            //have valid input
            return input;
        }
    }
}