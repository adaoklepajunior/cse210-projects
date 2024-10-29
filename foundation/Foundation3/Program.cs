using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of activities
        List<Activity> activities = new List<Activity>
        {
            // Create activities
            new Running("28 Sep 2024", 60, 10.0),
            new Cycling("29 Sep 2024", 30, 20.0),
            new Swimming("30 Sep 2024", 90, 60),
            new Running("01 Oct 2024", 30, 4.8),
            new Cycling("02 Oct 2024", 45, 25.0),
            new Swimming("03 Oct 2024", 60, 40)
        };

        // Display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}