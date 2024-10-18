using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectionActivity : Activity
{
    private static readonly List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> usedPrompts = new List<string>();
    private List<string> usedQuestions = new List<string>();

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void PerformActivity()
    {
        StartActivity();
        int duration = GetDuration();
        Random random = new Random();

        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            string prompt = prompts.Except(usedPrompts).ElementAt(random.Next(prompts.Count - usedPrompts.Count));
            usedPrompts.Add(prompt);
            Console.WriteLine(prompt);
            ShowSpinner(3);

            DateTime promptEndTime = DateTime.Now.AddSeconds(duration - 3);

            while (DateTime.Now < promptEndTime && DateTime.Now < endTime)
            {
                foreach (string question in questions.Except(usedQuestions))
                {
                    Console.WriteLine(question);
                    if (DateTime.Now >= endTime)
                        break;
                    ShowSpinner(8);
                    usedQuestions.Add(question);

                    if (DateTime.Now >= endTime)
                        break;
                }

                if (usedQuestions.Count == questions.Count)
                    usedQuestions.Clear();
            }
        }
        EndActivity();
    }
}