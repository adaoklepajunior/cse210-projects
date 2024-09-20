using System;

class Program
{
    static void Main(string[] args)
    {
        // For Parts 1 and 2, user specified the number:
        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());
        // Console.Write("What is your guess? ");
        // guess = int.Parse(Console.ReadLine());
        
        // Part 3, magic number generate by computer and added loop asking player
        // if he/she wants to play again.

        while (true)
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
    
        Console.Write("Would you like to play again? (yes/no) ");
        string keepPlaying = Console.ReadLine();

        if (keepPlaying != "yes")
        {
            Console.WriteLine("Ok. See you next time!");
            break;
        }
        }         
    }
}