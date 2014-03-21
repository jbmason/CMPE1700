//*************************************************************************************************************
//Program:      Lab1
//Description:  Encrypting and decrypting files
//Lab:          1
//Date:         February 28, 2014
//Author:       James Mason
//Course:       CMPE1600
//Class:        2D
//Instructor:   JD Silver
//*************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JamesMason_Lab1
{
    class Program
    {
        static StreamWriter write; // Writes to a designated file
        static StreamReader read; // Reads a designated file

        static void Main(string[] args)
        {
            string fileName; //Stores the file's name
            string key; //Stores the encryption key that the user selects
            List<char> fileContents; //Stores a list of each character contained within the user selected file
            List<char> encryptedContents; //Stores a list of all the characters after being encrypted ot decrypted.

            FileName(out fileName, out fileContents); //Calls to a method and outs the variables fileName and fileContents
            Key(out key); //Calls to a method and outs the user selected key
            
            Cryption(fileContents, key, out encryptedContents); //Calls to a method and sends the file contents, key, and outs the encrypted contents

            write = new StreamWriter(fileName); //Opens a streamwriter with the file name selected
            
            foreach (char c in encryptedContents) //For every character in the encryptedContents list it performs the following actions
                write.Write(c); //Writes each character one by one as it is sent in by the foreach loop to the file
            write.Close();  //Closes the streamwriter
        }


        //***********************************************************************************************************************
        //Method:       private static void FileName(out string fileName, out List<char> fileContents)
        //Purpose:      Obtains the file name from the user and checks to see if it exists. If it doesn't, displays an error message. If it does,
        //              the stream reader reads the file to the end and stores it in a temporary string which gets transferred into a character list.
        //Parameters:   bool success - lets us know if the filename was successfully read to the end
        //              string fileName - stores the filename
        //              string temp - stores the contents of the file after it has been transferred in
        //              List<char> fileContents - contains a list of characters from the temp string
        //              Streamreader read - streamreader variable
        //Returns:      Method returns fileName, and fileContents as out type variables
        //***********************************************************************************************************************
        private static void FileName(out string fileName, out List<char> fileContents)
        {

            bool success = false; //Stores whether or not reading the file was successful
            fileName = ""; //Initializes the fileName string
            string temp = ""; //Initializes the temp string
            fileContents = new List<char> { }; //Stores a list of characters that are found in the file

            do //Do loop that continues while success is not true
            {
                try // trys to perform the following
                {
                    Console.Write("File to encrypt or decrypt: "); // Asks the user for the file name
                    fileName = Console.ReadLine(); // Reads what the user types and stores it in the string fileName
                    read = new StreamReader(fileName); // Starts a streamreader 
                    temp = read.ReadToEnd(); // Reads the entire file and stores it in the temp string variable
                    success = true; // Changes success to true
                    read.Close(); // Closes the Streamreader

                }
                catch (System.IO.FileNotFoundException) // if the file is not found, the program will throw an exception, this catch stops it from causing problems
                {
                    Console.WriteLine("File '{0}' not found.", fileName); // Informs the user that the file was not found
                    success = false; // Changes success to false
                }
                catch (Exception) // Catches all other exceptions
                {
                    Console.WriteLine("Invalid input."); // Informs the user their input was invalid
                    success = false; // Changes success to false
                }
            } while (!success); // Repeats the above do loop while success = false;

            foreach (char c in temp) // Runs a foreach loop that cycles through each character in the string temp
                fileContents.Add(c); // Adds each character to the list fileContents
        }

        //***********************************************************************************************************************
        //Method:       private static void Key(out string key)
        //Purpose:      Obtains the key from the user
        //Parameters:   string key - stores the string the user inputs as the encryption key
        //Returns:      Method returns the key as an out type variable
        //***********************************************************************************************************************
        private static void Key(out string key)
        {
            key = ""; //Initializing the key string

                Console.Write("Encryption key: "); // Asks the use for an encryption key
                key = Console.ReadLine(); // Stores the key in the string variable 
           

        }

        //***********************************************************************************************************************
        //Method:       private static void Cryption(List<char> fileContents, string key, out List<char> encryptedContents)
        //Purpose:      Encrypts the file
        //Parameters:   string key - stores the string the user inputs as the encryption key
        //              List<char> fileContents - contains a list of characters from the temp string
        //              List<char> encryptedContents - stores the list of encrypted characters
        //Returns:      Method returns the key as an out type variable
        //***********************************************************************************************************************
        private static void Cryption(List<char> fileContents, string key, out List<char> encryptedContents)
        {
            encryptedContents = new List<char>(); // Initializes the character list encryptedContents

            for (int i = 0, x = 0; i < fileContents.Count; i++, x++) // Runs a for loop the amount of times equal to the length of the character list
            {
                if (x > key.Length - 1) // if the variable x is greater than the length of the key - 1, it resets x to 0
                    x = 0; // resets x to 0 if the above condition is met
                encryptedContents.Add((char)(fileContents[i] ^ key[x])); // Adds each character to the encrypted list after it gets encrypted using the key
                
            }
        }
    }
}
