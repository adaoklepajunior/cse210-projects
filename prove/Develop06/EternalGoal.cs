public class EternalGoal : Goal
{
    public int RecordCount { get; private set; }
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        RecordCount++;
    }

    public override string GetDetails()
    {
        return $"[Recorded {RecordCount} times] {Name} ({Description}): {Points} points";
    }
}