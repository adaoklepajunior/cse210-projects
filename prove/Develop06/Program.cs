

// Exeeding Requirements:
// As soon the program starts, it shows an option to use a list of defaut goals.
// I add a RecordCount to keep track of the achievements of EternalGoals.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        GoalManager goalManager = new GoalManager();
        InitializeGoals(goalManager);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Show Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show current Score");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Add New Goal");
            Console.WriteLine("7. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.DisplayGoals();
                    break;
                case "2":
                    goalManager.DisplayGoals();
                    Console.Write("Enter the index of the goal: ");
                    int goalIndex = int.Parse(Console.ReadLine()) -1;
                    goalManager.RecordEvent(goalIndex);
                    break;
                case "3":
                    goalManager.DisplayScore();
                    break;
                case "4":
                    Console.Write("Enter the txt filename to save goals: ");
                    string saveFilename = Console.ReadLine();
                    goalManager.SaveToFile(saveFilename);
                    break;
                case "5":
                    Console.Write("Enter the txt filename to load goals: ");
                    string loadFilename = Console.ReadLine();
                    goalManager.LoadFromFile(loadFilename);
                    break;
                case "6":
                    AddNewGoal(goalManager);
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }

    static void InitializeGoals(GoalManager goalManager)
    {
        Console.WriteLine("We have a default list of goals. Do you want to try it? (y/n)");
        string choice = Console.ReadLine();
        if (choice.ToLower() == "y")
        {
            // Add initial set of goals
            goalManager.AddGoal(new SimpleGoal("Plant a tree", "Plant a tree in your backyard", 10));
            goalManager.AddGoal(new SimpleGoal("Read a book", "Read a book for 30 minutes", 5));
            goalManager.AddGoal(new SimpleGoal("Exercise", "Exercise for 20 minutes", 15));
            goalManager.AddGoal(new SimpleGoal("Meditate", "Meditate for 10 minutes", 8));
            goalManager.AddGoal(new SimpleGoal("Call a friend", "Call a friend to catch up", 12));

            goalManager.AddGoal(new EternalGoal("Daily Prayer", "Pray daily", 3));
            goalManager.AddGoal(new EternalGoal("Drink Water", "Drink 8 cups of water", 2));
            goalManager.AddGoal(new EternalGoal("Sleep Well", "Get 8 hours of sleep", 4));
            goalManager.AddGoal(new EternalGoal("Healthy Eating", "Eat healthy meals", 5));
            goalManager.AddGoal(new EternalGoal("Gratitude Journal", "Write in gratitude journal", 6));

            goalManager.AddGoal(new ChecklistGoal("Attend Temple", "Attend the temple 6 times", 20, 6, 50));
            goalManager.AddGoal(new ChecklistGoal("Read Scriptures", "Read scriptures 30 times", 10, 30, 100));
            goalManager.AddGoal(new ChecklistGoal("Family Home Evening", "Hold Family Home Evening 4 times", 15, 4, 30));
            goalManager.AddGoal(new ChecklistGoal("Service Projects", "Complete 5 service projects", 25, 5, 75));
            goalManager.AddGoal(new ChecklistGoal("Missionary Discussions", "Have 10 missionary discussions", 18, 10, 45));
        }
    }

    static void AddNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("What kind of goal?:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string goalType = Console.ReadLine();

        Console.Write("Type a name to this goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("Establish the goal score: ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            goalManager.AddGoal(new SimpleGoal(name, description, points));
        }
        else if (goalType == "2")
        {
            goalManager.AddGoal(new EternalGoal(name, description, points));
        }
        else if (goalType == "3")
        {
            Console.Write("Enter the target count: ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("Enter the bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            goalManager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
        }
    }
}