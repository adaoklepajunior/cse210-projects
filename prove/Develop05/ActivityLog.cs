using System;
using System.Collections.Generic;
using System.IO;

public class ActivityLog
{
    private List<string> logs = new List<string>();

    // Method created to add a log entry
    public void AddLog(string activityName, int duration)
    {
        string log = $"{DateTime.Now}: {activityName} for {duration} seconds.";
        logs.Add(log);
    }

    // Method created to save the log to a file
    public void SaveLog(string filePath)
    {
        File.WriteAllLines(filePath, logs);
    }

    // Method created to load the log from a file
    public void LoadLog(string filePath)
    {
        if (File.Exists(filePath))
        {
            logs = new List<string>(File.ReadAllLines(filePath));
        }
    }

    // Method created to display the activity log
    public void DisplayLog()
    {
        Console.WriteLine("Activity Log:");
        foreach (string log in logs)
        {
            Console.WriteLine(log);
        }
    }
}