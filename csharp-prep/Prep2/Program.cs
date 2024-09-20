using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is you grade percentage? ");
        string gradePercentage = Console.ReadLine();
        int number = int.Parse(gradePercentage);
        string letter = "";

        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80 && number < 90)
        {
            letter = "B";
        }
        else if (number >= 70 && number < 80)
        {
            letter = "C";
        }
        else if (number >= 60 && number < 70)
        {
            letter = "D";
        }
        else if (number < 60)
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is: {letter}");

        if (number >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Wish you a better luck next time!");
        }



    }
}