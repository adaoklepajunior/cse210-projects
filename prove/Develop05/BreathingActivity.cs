using System;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing. Take 10 seconds or more.")
    {
    }

    public override void PerformActivity()
    {
        StartActivity();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < GetDuration())
        {
            Console.Clear();
            Console.Write("Breathe in... ");
            ShowCountdown(5);
            Console.Clear();
            Console.Write("Breathe out... ");
            ShowCountdown(5);
        }
        stopwatch.Stop();
        Console.Clear();
        EndActivity();
    }
}