namespace Tracker.Classes;

public class Timer
{
    public TimeSpan Time { get; set; }

    public override string ToString()
    {
        return Time.ToString(@"hh\:mm\:ss");
    }
}