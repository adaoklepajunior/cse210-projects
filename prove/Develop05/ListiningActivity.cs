using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class ListingActivity : Activity
{
    private static readonly List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> usedPrompts = new List<string>();

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void PerformActivity()
    {
        StartActivity();
        int duration = GetDuration();
        Random random = new Random();

        if (usedPrompts.Count == prompts.Count)
            usedPrompts.Clear();

        string prompt = prompts.Except(usedPrompts).ElementAt(random.Next(prompts.Count - usedPrompts.Count));
        usedPrompts.Add(prompt);

        Console.WriteLine(prompt);
        ShowSpinner(3);
        Console.WriteLine("Start listing...");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }

        Console.WriteLine($"You listed {items.Count} items.");
        EndActivity();
    }
}