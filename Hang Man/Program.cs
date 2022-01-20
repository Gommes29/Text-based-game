using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            string happyMan = "";
            happyMan += "       \\O/\n";
            happyMan += "         T\n";
            happyMan += "        / \\ \n";

            string[] wordBank = { "Mare", "Birch", "Tempature", "Lucky", "Blacksmith", "Bandit", "Mexico", "Eagle", "Snake", "Oil", "Hinge", "Revolver", "Pea", "Shooter", "Market", "Auction", "Mountain", "Medicine", "Whiskey", "Devil", "Coins", "Nugget", "Donkey", "Eastwood", "Parlor", "River", "Shuteye", "Deuce", "Lasso", "Livestock", "Longhorn", "Lawless", "Ranch", "Justice", "Howdy", "Yearning", "Fortune", "Ricochet", "Mount", "Outlaw", "Leather", "Campfire", "Cavalry", "Bandanna", "Jealousy", "Foothills", "Fortitude", "Exhaustion", "Indians", "Observant", "Tendency", "Peacemaker", "Crash", "Deuce", "Annex", "Apple", "Auger", "Grease", "Robber" };

            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 7;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.Write("Guess them letters partner: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                    lives--;
                    Console.WriteLine(GallowView(lives));
                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (won)
                Console.WriteLine($"You won!\n {happyMan}");
            
           
            


            else
                Console.WriteLine("You lost! It was '{0}'", wordToGuess);

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
            static string GallowView(int livesLeft)
            {

                string drawHangman = "";

                if (livesLeft < 7)
                {
                    
                    drawHangman += "--------\n";
                }

                if (livesLeft < 6)
                {
                    
                    drawHangman += "       |\n";
                }

                if (livesLeft < 5)
                {
                    drawHangman += "       O\n";
                }

                if (livesLeft < 4)
                {
                    drawHangman += "      /";
                }
                if (livesLeft < 3)
                {

                    drawHangman += "|";
                }
                if (livesLeft < 2)
                {
                    drawHangman += "\\ \n";
                }

                if (livesLeft < 1)
                {
                    drawHangman += "      / ";
                }
                if (livesLeft == 0)
                {
                    drawHangman += "\\ \n";
                }

                return drawHangman;

            }

        }
    }
}




