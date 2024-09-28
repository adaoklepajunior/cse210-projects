
using System;
using System.Collections.Generic;

public class Program
{
    private static Journal journal = new Journal();

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Journal Options");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file and exit");
            Console.WriteLine("5. Exit without saving");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEntry();
                    break;
                case "2":
                    DisplayTheJournal();
                    break;
                case "3":
                    DisplayFromJournal();
                    break;
                case "4":
                    SaveAndExit();
                    return;
                case "5":
                    ExitWithoutSaving();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press 1-5 to try again.");
                    break;
            }
        }
    }

    private static void AddEntry()
    {
        string prompt = Utility.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        Entry entry = new Entry(prompt, response);
        Console.WriteLine("Type your entry:");
        Console.WriteLine(entry.ToString());
        Console.Write("Do you confirm it? (yes/edit/cancel): ");
        string confirmation = Console.ReadLine().ToLower();

        switch (confirmation)
        {
            case "yes":
                journal.AddEntry(entry);
                Console.WriteLine("Entry registered!");
                break;
            case "edit":
                Console.Write("Type your entry again: ");
                response = Console.ReadLine();
                entry = new Entry(prompt, response);
                journal.AddEntry(entry);
                Console.WriteLine("Entry registered.");
                break;
            case "cancel":
                Console.WriteLine("Entry canceled.");
                break;
            default:
                Console.WriteLine("Invalid choice. Entry canceled.");
                break;
        }
        Console.WriteLine("Returning to the menu...");
    }

    private static void DisplayTheJournal()
    {
        var entries = journal.GetEntries();
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries in the current session, press any key to return to the menu...");
            return;
        }
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
        Console.WriteLine("Returning to the menu...");
    }

    private static void DisplayFromJournal()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        DisplayTheJournal();
    }

    private static void SaveAndExit()
    {
        Console.Write("Enter filename to save as: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Your diary has been saved successfully. Press any key to exit.");
    }

    private static void ExitWithoutSaving()
    {
        
        Console.WriteLine("Exiting without saving. All entries will be lost.");
        Console.Write("Type 'confirm' to exit without saving: ");
        string confirmation = Console.ReadLine().ToLower();
        if (confirmation == "confirm")
        {
            Console.WriteLine("Exiting without saving. Press any key to exit.");
        }
    }
}