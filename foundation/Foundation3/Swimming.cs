public class Swimming : Activity
{
    private int laps;
    private const double lapDistance = 50.0 / 1000;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * lapDistance;
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}