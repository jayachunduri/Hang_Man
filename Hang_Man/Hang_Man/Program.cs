using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Hangman
    {
        //Below are the member variables for the class Hangman

        public static int noOfLives = 7;
        public static List<string> wordBank = new List<string>() 
        {"apple", "nickeback", "computer", "seedpaths", 
        "mountain", "sky", "river", "chair", "boy", "afternoon", "watermelon", "television", "bus", "water", "glass"};
        public static string randomWord;
        public static Random rng = new Random();
        public static string lettersGuessed = string.Empty;
        public static string usersGuess;
        public static bool won = false;
        public static string userName;

        static void Main(string[] args)
        {
            //generated a random word
            randomWord = wordBank[rng.Next(1, 16)];

            //Geeting the user and explaing the rules by calling below function
            Greet();

            //Playing the game. 
            //Divided each task into it's own function, so that code will be easy to manage and main looks clean
            PlayGame();
        }

        //function to greet the user and display rules
        static void Greet()
        {
            Console.WriteLine("Enter your name");
            userName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("\nWelcome to Hangman, " + userName);
            Console.WriteLine("\ntype \"HELP\" for the introduction \n or Press enter to skip the introduction:");
            string temp = Console.ReadLine();

            if (temp == "")
                return;
            else if (temp.ToLower() == "help")
            {
                Console.WriteLine(@"Handman Rules:You need to guess the whole word 
Or a single letter in the word
You will win, if you guess the whole word or all the letters in the word
You only have 7 lives to guess
If you can't guess in 7 lives, you will lose.

            Good luck!");
            }

        }


        //function to display Masked word
        static int MaskedWord(string randomWord)
        {
            int count = 0;
            for (int i = 0; i < randomWord.Length; i++)
            {
                if (lettersGuessed.Contains(randomWord[i]))
                {
                    Console.Write(randomWord[i]);
                }
                else
                {
                    Console.Write(" _ ");
                    count++;
                }
            }
            return count;

        }

        //function contains the logic for the game
        static void PlayGame()
        {
            int count;

            while (won != true)
            {
                //Console.Clear();
                count = MaskedWord(randomWord);
                if (count == 0)
                {
                 
                    Console.WriteLine("\nCongratulations, " + userName + " you won!");
                    Console.WriteLine("The word is: " + randomWord);
                    Console.ReadKey();
                    won = true;
                }

                else
                {
                    //get user's guess
                    
                    Console.WriteLine("\n\nYou have " + noOfLives + " lives left\nEnter your guess");
                    usersGuess = Console.ReadLine();
                    UsersGuessVerify(usersGuess);
                    if ((noOfLives == 0) && (won == false))
                    {
                        Console.WriteLine("\nSorry " + userName + " you ran out of lives. Game over");
                        Console.WriteLine("The word is: " + randomWord);
                        Console.ReadKey();
                        won = true;
                    }
                }
                Console.Clear();
            }

        }

        //function to verify users guess
        static void UsersGuessVerify(string guess)
        {
            //verify if user entered a letter or word
            if (guess.Length > 1) //means user entered a word
            {
                if (guess.ToLower() == randomWord)
                {
                    Console.WriteLine("Congratulations, " + userName + " you won!");
                    //Console.WriteLine(randomWord);
                    won = true;
                    noOfLives = 0;
                    return;
                }
                else
                {
                    noOfLives--;
                    Console.WriteLine("You guessed wrong. You have " + noOfLives + " lives left");
                    Console.WriteLine("You have guessed: " + lettersGuessed);
                    return;
                }
            }
            else //he entered a letter
            {
                
                //verify if the word to be guessed has the letter entered by user
                if (lettersGuessed.Contains(guess))
                {
                    Console.WriteLine("You already guessed that letter");
                    //add that letter to the guessed letters
                    lettersGuessed = lettersGuessed + guess;
                    return;
                }
                else if (randomWord.Contains(guess))
                {
                    //add that letter to the guessed letters
                    lettersGuessed = lettersGuessed + guess;

                    return;
                }
                else
                {
                    noOfLives--;
                    //add that letter to the guessed letters
                    lettersGuessed = lettersGuessed + guess;
                    Console.WriteLine("You guessed wrong. You have " + noOfLives + " lives left");
                    Console.WriteLine("You have guessed: " + lettersGuessed);
                    return;
                }

            }
        }


    }
}
