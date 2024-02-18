namespace Hesketh.MecatolArchives.API.Data;

public class Statistics
{
    public Statistic Overall { get; set; } = new("Overall", null);
    public List<Statistic> Stats { get; set; } = new();

    public void AddStatistic(Statistic statistic)
    {
        Stats.Add(statistic);

        Overall.Plays += statistic.Plays;
        Overall.Wins += statistic.Wins;
        Overall.PointPercentSum += statistic.PointPercentSum;
    }
}
