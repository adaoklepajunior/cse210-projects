public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override string GetDetails()
    {
        return _isComplete 
            ? $"[X] {Name} ({Description}): {Points} points"
            : $"[ ] {Name} ({Description}): {Points} points";
    }
}