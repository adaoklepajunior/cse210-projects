// As it says in the Exceeding Requirements instructions: "Make sure no random prompts/questions are selected
// until they have all been used at least once in that session."
// Saving and loading a log file.

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose one of the activity options by respective number:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Log");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.PerformActivity();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.PerformActivity();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.PerformActivity();
                    break;
                case "4":
                    ActivityLog activityLog = new ActivityLog();
                    activityLog.LoadLog("activityLog.txt");
                    activityLog.DisplayLog();
                    Console.WriteLine("Press Enter Key to continue...");
                    Console.ReadKey();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}