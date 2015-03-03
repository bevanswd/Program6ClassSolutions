using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        public static Random rng = new Random();
        static void Main(string[] args)
        {
            Hangman();
	        Console.ReadLine();
        }

        /// <summary>
        /// Hangman game flow
        /// </summary>
        static void Hangman()
        {
            //set max guesses to 6
            int maxGuesses = 10;
            //create string to store user input
            string userInput = string.Empty;
            //initialize playing = true
            bool playing = true;
            //create list of hangman words
            List<string> hangmanWords = new List<string>() { "softball", "tacos", "caribbean", "lady", "winnipeg", "laundry", "sanctuary", "loading", "enjoyable", "lovely", "happenstance", "sandwich", "accelerate", "fortify" };
            //create string to pick from the random assortment. this will be the secret word
            string correctWord = hangmanWords[rng.Next(0, hangmanWords.Count())];
            //write intro greeting to the console. ask for name
            Console.Write("Welcome to Hangman! What is your name? ");
            //create string to store userName
            string userName = Console.ReadLine();

            Console.WriteLine();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Okay, " + userName + ". Get ready to play!");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine();

            //while loop - game is playing
            while (playing)
            {
                //take-in guess data with specified parameters
                guessData(userInput, correctWord, maxGuesses);
                Console.WriteLine(@" 
                             _______
                            |/
                            |  
                            |     
                            |    
                            |     
                            |
                           _|___");
                //update data for each wrongly guessed word. write corresponding harrassment text
                if (maxGuesses == 9)
                {
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/ 
                            | 
                            | 
                            | 
                            |   
                            |
                           _|___");
                    Console.WriteLine("\nuh uh.");
                }
                if (maxGuesses == 8)
                {
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/      |
                            |
                            |   
                            |   
                            |    
                            |
                           _|___");
                    Console.WriteLine("\nnope. we're lowering the rope!");
                }
                if (maxGuesses == 7)
                {
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/      |
                            |      ( )
                            |    
                            |   
                            |    
                            |
                           _|___");
                    Console.WriteLine("\nthat's not right");
                }
                if (maxGuesses == 6)
                {
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/      |
                            |      (_)
                            |       
                            |   
                            |    
                            |
                           _|___");
                    Console.WriteLine("\nno again");
                }
                if (maxGuesses == 5)
                {
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/      |
                            |      (_)
                            |       |
                            |   
                            |    
                            |
                           _|___");
                    Console.WriteLine("\nuhh, that's not in here");
                }
                if (maxGuesses == 4)
                {
                    Console.Clear();
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/      |
                            |      (_)
                            |      \|
                            |   
                            |     
                            |
                           _|___");
                    Console.WriteLine("\nthat isn't either");
                }
                if (maxGuesses == 3)
                {
                    Console.Clear();
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/      |
                            |      (_)
                            |      \|/
                            |       
                            |   
                            |
                           _|___");
                    Console.WriteLine("\nnot even close!");
                }
                if (maxGuesses == 2)
                {
                    Console.Clear();
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/      |
                            |      (_)
                            |      \|/
                            |       |
                            |      
                            |
                           _|___");
                    Console.WriteLine("\n wrong.");
                }
                if (maxGuesses == 1)
                {
                    Console.Clear();
                    guessData(userInput, correctWord, maxGuesses);
                    Console.WriteLine(@" 
                             _______
                            |/      |
                            |      (_)
                            |      \|/
                            |       |
                            |      / 
                            |
                           _|___");
                    Console.WriteLine("\nha. you're almost dead");
                }
                Console.WriteLine();

                //create user input string from getUserInput function
                string inputString = getUserInput(userInput);
                if (inputString.Length == 1)
                {
                    //log inputString to userInput 
                    userInput = userInput + inputString;
                    //if input is a char (1-character string)
                    //if guessed correctly
                    if (correctWord.ToUpper().Contains(inputString.ToUpper()))
                    {
                        Console.Clear();
                        guessData(userInput, correctWord, maxGuesses);
                        //if the masked word no longer contans any "_"
                        if (!maskedWord(userInput, correctWord).Contains("_"))
                        {
                            //stop the game
                            playing = false;
                        }
                    }
                    else
                    {
                        //continue subtracting from maxGuesses until 0
                        maxGuesses--;
                        playing = (maxGuesses > 0);
                    }
                }

                else
                {
                    //if the correct word has been guessed
                    if (inputString.ToLower() == correctWord.ToLower())
                    {
                        //stop the game
                        playing = false;
                    }
                    else
                    {
                        //continue subtracting from maxGuesses until 0
                        maxGuesses--;
                        playing = (maxGuesses > 0);
                    }
                }
            }
            //if user guesses the correct word
            if (maxGuesses > 0 || userInput == correctWord)
            {
                //write congrats text
                Console.Clear();
                Console.WriteLine("the word was: " + correctWord);
                Console.WriteLine("\nnice job! you didn't die. that's a good word, yea?\n");
            }
            //if maxGuesses reaches 0
            else
            {
                //log data
                guessData(userInput, correctWord, maxGuesses);
                //game over
                Console.Clear();
                //write you suck
                Console.WriteLine(@" 
                             _______
                            |/      |
                            |      (_)
                            |      \|/
                            |       |
                            |      / \
                            |
                           _|___");
                Console.WriteLine("\noops, you're dead. you couldn't even guess what the word is.\n");
            }
            //reset
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine();
            Console.Write("(Y or N) ");
            string startOver = Console.ReadLine().ToUpper();
            if (startOver == "Y")
            {
                Console.Clear();
                Hangman();
            }
        }

        /// <summary>
        /// guessData function to store specified parameters
        /// </summary>
        /// <param name="userInput">user input</param>
        /// <param name="correctGuess">secret word to guess</param>
        /// <param name="maxGuesses">amount of guesses left before game over</param>
        static void guessData(string userInput, string correctGuess, int maxGuesses)
        {
            //clear console after each guess
            Console.Clear();
            Console.WriteLine();
            //write masked word to console
            Console.WriteLine(maskedWord(userInput, correctGuess));
            Console.WriteLine();
            //write guess data to console
            Console.WriteLine("# guesses left: " + maxGuesses + "\nletters guessed: " + userInput.ToUpper());
        }

        /// <summary>
        /// secret hidden hangman word function
        /// </summary>
        /// <param name="letterGuessed">user input</param>
        /// <param name="correctGuess">secret hangman word</param>
        /// <returns></returns>
        static string maskedWord(string letterGuessed, string correctGuess)
        {
            //create returnString to store masked letters
            string maskedString = string.Empty;
            //count through the letters of the secret hangman word
            for (int i = 0; i < correctGuess.Length; i++)
            {
                //create string to index through hangman word
                string correctLetter = correctGuess[i].ToString().ToUpper();
                //if user input is a correct letter
                if (letterGuessed.ToUpper().Contains(correctLetter))
                {
                    //add correctLetter to masked word
                    maskedString += correctLetter + " ";
                }
                else
                {
                    //keep it hidden with an underscore
                    maskedString += "_ ";
                }
            }
            //return it
            return maskedString;
        }

        /// <summary>
        /// function to read user input
        /// </summary>
        /// <param name="letters">letters to guess</param>
        /// <returns></returns>
        static string getUserInput(string lettersGuessing)
        {
            userInput = string.Empty;
            bool guessValidator = true;
            do
            {
                Console.WriteLine("Guess a letter: ");
                userInput = Console.ReadLine();
                if (userInput.Length > 1)
                {
                    //more than one character, the word check is elsewhere
                    Console.WriteLine();
                    Console.WriteLine("only one letter, please!");
                    guessValidator = false;
                }
                    //if one char, check for number
                else if (userInput.Length == 1)
                {
                    guessValidator = char.IsLetter(userInput[0]);
                    if (guessValidator)
                    {
                        //repeat letter
                        Console.WriteLine();
                        Console.WriteLine("you already guessed that. i even showed you up there.");
                        guessValidator = !(lettersGuessing.ToUpper().Contains(userInput.ToUpper()));
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("that's not a letter!");
                    }
                }
                    //no input
                else if (userInput.Length == 0)
                {
                    Console.WriteLine("you have to guess a letter or something.");
                    guessValidator = false;
                }
            }
            //return invalid
            while (guessValidator == false);
            Console.WriteLine("invalid");
            return userInput;
        }
        static string userInput = string.Empty;
    }
}