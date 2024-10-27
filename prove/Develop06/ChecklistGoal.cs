public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        Console.WriteLine($"You recorded an event for {Name}. You earned {Points} points.");
        if (CurrentCount >= TargetCount)
        {
            IsComplete = true;
            Console.WriteLine($"Congratulations! You've completed {Name} and earned a bonus of {BonusPoints} points!");
        }
    }

    public override string GetDetails()
    {
        return $"{(IsComplete ? "[X]" : "[ ]")} {Name} - {Description} (Completed {CurrentCount}/{TargetCount} times)";
    }
}