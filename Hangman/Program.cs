using System.Diagnostics;
using System;
using System.Collections.Generic;


public class HangMan
{
    public static void Main(string[] args)
    {
        Console.WriteLine("----------PLAY Hangman--------");
        //   choose a rand word from this array
        string[] secretWords = { "House", "Man", "Yes", "Water", "car", "when", "crypto" };
        Random rnd = new Random();
        int index = rnd.Next(0, secretWords.Length);
        string secretWord = secretWords[index];
        // define the dashes the same length as the word to show the user
        string secretDash = new string('-', secretWord.Length);
        char[] DashChar = secretDash.ToCharArray();
        // define the list of the recent gueses of the user
        List<string> guesses = new List<string>();
        // give the user input guesses 10 times to the user
        for (int i = 0; i < 10; i++)
        {
            string state = "not_repeat"; 
            
            Console.WriteLine("Enter your guess: " + secretDash);
            string userGuess = Console.ReadLine();
            // condition1: if user inserts empty array, don't count guess
            if (userGuess == "")
            {
                Console.WriteLine("You inserted an empty string, please try again with a valid input");
                i--;
                continue;
            }
            // the process of comparing guesses with the word
            string secretLower = secretWord.ToLower();
            string guessLower = userGuess.ToLower();
            // condition2: if user inserts repetitive word, don't count the guesses
            for (int k = 0; k < guesses.Count; k++)
            {
                if (guesses[k] == guessLower)
                {
                    Console.WriteLine("You have guessed this before, please insert a new guess");
                    i--;
                    state = "repeat";

                }
            }
            if (state == "repeat")
            {
                continue;
            }

            guesses.Add(guessLower);
            String[] str = guesses.ToArray();
            Console.WriteLine("Your recent guesses: " + string.Join(", ", guesses));



            // condition3: if the user input is a letter, use this logic
            if (guessLower.Length == 1)
            {
                for (int j = 0; j < secretLower.Length; j++)
                {
                    if (secretLower[j] == guessLower[0])
                    {
                        DashChar[j] = guessLower[0];
                        secretDash = new String(DashChar);

                        if (new String(DashChar) == secretLower)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You won, the secret word is :" + secretDash);
                            return;
                        }
                    }

                }
            }
            // condition4 : if user inserts a word, use this logic
            else
            {
                if (guessLower == secretLower)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You won, the secret word is :" + secretWord);
                    return;
                }
            }



        }
        // if user can't guess the word in 10 guess, they will lose
        Console.WriteLine("You Lost");
        return;

    }
}

