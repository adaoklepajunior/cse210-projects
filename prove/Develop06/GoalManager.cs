using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals;
    private int score;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            score += goals[goalIndex].Points;
            if (goals[goalIndex] is ChecklistGoal checklistGoal && checklistGoal.IsComplete)
            {
                score += checklistGoal.BonusPoints;
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetails()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score: {score}");
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"ChecklistGoal|{goal.Name}|{goal.Description}|{goal.Points}|{checklistGoal.TargetCount}|{checklistGoal.CurrentCount}|{checklistGoal.BonusPoints}|{goal.IsComplete}");
                }
                else if (goal is SimpleGoal)
                {
                    writer.WriteLine($"SimpleGoal|{goal.Name}|{goal.Description}|{goal.Points}|{goal.IsComplete}");
                }
                else if (goal is EternalGoal)
                {
                    writer.WriteLine($"EternalGoal|{goal.Name}|{goal.Description}|{goal.Points}");
                }
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                score = int.Parse(reader.ReadLine());
                goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    if (type == "SimpleGoal")
                    {
                        bool isComplete = bool.Parse(parts[4]);
                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                        simpleGoal.IsComplete = isComplete;
                        goals.Add(simpleGoal);
                    }
                    else if (type == "EternalGoal")
                    {
                        EternalGoal eternalGoal = new EternalGoal(name, description, points);
                        goals.Add(eternalGoal);
                    }
                    else if (type == "ChecklistGoal")
                    {
                        int targetCount = int.Parse(parts[4]);
                        int currentCount = int.Parse(parts[5]);
                        int bonusPoints = int.Parse(parts[6]);
                        bool isComplete = bool.Parse(parts[7]);
                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                        checklistGoal.CurrentCount = currentCount;
                        checklistGoal.IsComplete = isComplete;
                        goals.Add(checklistGoal);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}