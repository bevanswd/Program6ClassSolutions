using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cypher
{
    class Program
    {
        static void Main(string[] args)
        {
            Encrypt(3, "nickleback");
        }

        //encrypt function
        static string Encrypt(int numberOfLines, string textToEncrypt)
        {
            //create list of strings
            List<string> listOfStrings = new List<string>();
            for (int i = 0; i < numberOfLines; i++)
            {
                listOfStrings.Add(string.Empty);

            }

            //keep track of current line
            int currentLine = 0;
            //keep track of direction
            string direction = "down";
            //loop through each char
            foreach (char letter in textToEncrypt)
            { 
                //add letter to current line
                listOfStrings[currentLine] += letter;

                //increment line
                if (currentLine == listOfStrings.Count - 1)
                {
                    //check if we're at the last line
                    direction = "up";
                }
                else if (currentLine == 0)
                { 
                    //specify direction going down
                    direction = "down";
                }

                //increment counter
                if (direction == "down")
                {
                    currentLine++;
                }
                else
                {
                    //going up
                    currentLine--;
                }
            }
            string returnString = string.Empty;
            /*foreach (string line in listOfString)
            { 
                return returnstring += line;
            }*/
            return string.Join(" ", listOfStrings);
        }
        static string Decrypt(int numberOfLines, string texttoDecrypt)
        { 
            //step1: figure out how many chars in each line

            {
                //create list of strings
                List<string> CharsPerLine = new List<string>();
                List<string>
                for (int i = 0; i < numberOfLines; i++)
                {
                    CharsPerLine.Add(string.Empty);

                }

                //keep track of current line
                int currentLine = 0;
                //keep track of direction
                string direction = "down";
                //loop through each char
                foreach (char letter in textToEncrypt)
                {
                    //add letter to current line
                    listOfStrings[currentLine] += letter;

                    //increment line
                    if (currentLine == listOfStrings.Count - 1)
                    {
                        //check if we're at the last line
                        direction = "up";
                    }
                    else if (currentLine == 0)
                    {
                        //specify direction going down
                        direction = "down";
                    }

                    //increment counter
                    if (direction == "down")
                    {
                        currentLine++;
                    }
                    else
                    {
                        //going up
                        currentLine--;
                    }
                }

                    string returnString = string.Empty;
                    /*foreach (string line in listOfString)
                    { 
                        return returnstring += line;
                    }*/
                return string.Join(" ", listOfStrings);
            }

            //step2: take substring of chars from text to decrypt, put into list
            //populate listofstringstodecrypt
            //loop through the charsperline to populate listofstringtodecryot
            foreach (string line in CharsPerLine)
            {
                int numberOfCharacters = line.Length;
                int currentLineToPopulate;
                string originalLettersInLine = texttoDecrypt.Substring(0, numberOfCharacters);
                startIndex += numberOfCharacters;

                listOfStringsToDecrypt = originalLettersInTheLine;
                currentLineToPopulate++;
            }

            //our list of strings to decrypt has the proper chars in the correct lines as when encrypted
            //step3: walk through list using zig/zag pattern to reconstruct
        }
    }
}
