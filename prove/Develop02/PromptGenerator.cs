using System;
using System.Collections.Generic;

public static class Utility
{
    private static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What is something I learned today?",
        "What do I wish I had more time for?",
        "What am I grateful for today?",
        "What was the most challenging part of my day?",
        "Did I serve someone today?",
        "What did you learn from the scriptures today?"
    };

    public static string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}