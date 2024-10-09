using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //Console.Clear();
        string path = @"C:/CSE210-Programming-with-Classes/cse210-projects/prove/Develop03/scriptures.txt";
        List<Scripture> scriptures = LoadScriptures(path);
        
        Console.WriteLine("Choose a scripture:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayText().Split('\n')[0]}");
        }

        int choice;
        while (true)
        {
            Console.Write("Enter the number of the scripture you want to: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= scriptures.Count)
            {
                break;
            }
            Console.WriteLine("Invalid choice, try again.");
        }

        Scripture selectedScripture = scriptures[choice - 1];

        while (true)
        {
            //Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());

            Console.WriteLine("\nPress enter to start hiding words or type 'quit' to finish it.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords();

            if (selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("The whole scripture is hidden!");
                break;
            }
        }
    }

    // Showing Creativity and Exceeding Requirements: This Method loads scriptures from a file.
    static List<Scripture> LoadScriptures(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            int id = int.Parse(parts[0]);
            string referenceText = parts[1];
            string text = parts[2];

            string[] referenceParts = referenceText.Split(new char[] { ' ', ':' });
            string book = referenceParts[0];
            int chapter = int.Parse(referenceParts[1]);
            string[] verseParts = referenceParts[2].Split('-');

            Reference reference;
            if (verseParts.Length == 1)
            {
                reference = new Reference(book, chapter, int.Parse(verseParts[0]));
            }
            else
            {
                reference = new Reference(book, chapter, int.Parse(verseParts[0]), int.Parse(verseParts[1]));
            }

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}