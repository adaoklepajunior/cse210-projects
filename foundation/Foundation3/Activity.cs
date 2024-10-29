using System;

public abstract class Activity
{
    private string date;
    private int minutes;

    protected Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{date} {GetType().Name} ({minutes} min): Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per kilometer";
    }

    public int GetMinutes() => minutes;
}