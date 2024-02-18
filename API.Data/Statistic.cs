namespace Hesketh.MecatolArchives.API.Data;

public class Statistic
{
    public Guid? LinkedIdentifier { get; set; }
    public string Name { get; }
    public int Wins { get; set; } = 0;
    public int Plays { get; set; } = 0;
    public int Losses => Plays - Wins;
    public double WinPercentage => Plays > 0 ? (double)Wins / Plays * 100 : 0;

    // The point percentage is the total percentage of Points earned in each game
    // So if you earned 4/5 points in one game and 10/10 in another. That is 180% total
    // But it is in the range 0...1
    public double PointPercentSum { get; set; }
    public double PointPercentage => Plays > 0 ? (double)PointPercentSum / Plays * 100 : 0;

    public Statistic(string name, Guid? linkedIdentifier)
    {
        Name = name;
        LinkedIdentifier = linkedIdentifier;
    }
}