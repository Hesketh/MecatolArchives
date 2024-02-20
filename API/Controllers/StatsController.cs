using Hesketh.MecatolArchives.API.Data;
using Hesketh.MecatolArchives.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("stats")]
public sealed class StatsController : ControllerBase
{
    private readonly MecatolArchivesDbContext _db;

    public StatsController(MecatolArchivesDbContext db)
    {
        _db = db;
    }

    [HttpGet("factions/person={personIdentifier}")]
    public ActionResult<Statistics> GetPlayersFactions(Guid personIdentifier)
    {
        var overall = new Statistics();
        
        var statsLookup = new Dictionary<Guid, Statistic>();
        foreach (var faction in _db.Factions.Where(x => x.Name != MecatolArchivesDbContext.UnknownName))
        {
            statsLookup[faction.Identifier] = new Statistic(faction.Name, faction.Identifier);
        }

        foreach (var play in _db.Plays.Include(x => x.Players)
                     .ThenInclude(x => x.Faction)
                     .Include(x => x.Players).ThenInclude(x => x.Person)
                     .Where(x => x.Players.Any(y => y.Winner)))
        {
            foreach (var player in play.Players.Where(x => x.Person.Identifier == personIdentifier))
            {
                if (!statsLookup.TryGetValue(player.Faction.Identifier, out var stats))
                {
                    stats = new Statistic(player.Faction.Name, player.Faction.Identifier);
                    statsLookup[player.Faction.Identifier] = stats;
                }

                stats.Plays += 1;

                if (player.Winner)
                {
                    stats.Wins += 1;
                }

                var pointPercentage = (double)player.Points / play.PointGoal;
                stats.PointPercentSum += pointPercentage;
            }
        }

        foreach (var (id, stat) in statsLookup)
        {
            overall.AddStatistic(stat);
        }

        return Ok(overall);
    }

    [HttpGet("factions")]
    public ActionResult<Statistics> GetFactionStats()
    {
        var overall = new Statistics();

        var statsLookup = new Dictionary<Guid, Statistic>();
        foreach (var faction in _db.Factions.Where(x => x.Name != MecatolArchivesDbContext.UnknownName))
        {
            statsLookup[faction.Identifier] = new Statistic(faction.Name, faction.Identifier);
        }

        foreach (var play in _db.Plays.Include(x => x.Players)
                     .ThenInclude(x => x.Faction)
                     .Where(x => x.Players.Any(y => y.Winner)))
        {
            foreach (var player in play.Players)
            {
                if (!statsLookup.TryGetValue(player.Faction.Identifier, out var stats))
                {
                    stats = new Statistic(player.Faction.Name, player.Faction.Identifier);
                    statsLookup[player.Faction.Identifier] = stats;
                }

                stats.Plays += 1;

                if (player.Winner)
                {
                    stats.Wins += 1;
                }

                var pointPercentage = (double)player.Points / play.PointGoal;
                stats.PointPercentSum += pointPercentage;
            }
        }

        foreach (var (id, stat) in statsLookup)
        {
            overall.AddStatistic(stat);
        }

        return Ok(overall);
    }

    [HttpGet("people")]
    public ActionResult<Statistics> GetPeopleStats()
    {
        var overall = new Statistics();

        var statsLookup = new Dictionary<Guid, Statistic>();
        foreach (var play in _db.Plays.Include(x => x.Players)
                     .ThenInclude(x => x.Person)
                     .Where(x => x.Players.Any(y => y.Winner)))
        {
            foreach (var player in play.Players)
            {
                if (!statsLookup.TryGetValue(player.Person.Identifier, out var stats))
                {
                    stats = new Statistic(player.Person.Name, player.Person.Identifier);
                    statsLookup[player.Person.Identifier] = stats;
                }

                stats.Plays += 1;

                if (player.Winner)
                {
                    stats.Wins += 1;
                }

                var pointPercentage = (double)player.Points / play.PointGoal;
                stats.PointPercentSum += pointPercentage;
            }
        }

        foreach (var (id, stat) in statsLookup)
        {
            overall.AddStatistic(stat);
        }

        return Ok(overall);
    }

    [HttpGet("people/faction={factionIdentifier}")]
    public ActionResult<Statistics> GetFactionPeopleStats(Guid factionIdentifier)
    {
        var overall = new Statistics();

        var statsLookup = new Dictionary<Guid, Statistic>();
        foreach (var play in _db.Plays.Include(x => x.Players)
                     .ThenInclude(x => x.Person)
                     .Include(x => x.Players).ThenInclude(x => x.Faction)
                     .Where(x => x.Players.Any(y => y.Winner)))
        {
            foreach (var player in play.Players.Where(x => x.Faction.Identifier == factionIdentifier))
            {
                if (!statsLookup.TryGetValue(player.Person.Identifier, out var stats))
                {
                    stats = new Statistic(player.Person.Name, player.Person.Identifier);
                    statsLookup[player.Person.Identifier] = stats;
                }

                stats.Plays += 1;

                if (player.Winner)
                {
                    stats.Wins += 1;
                }

                var pointPercentage = (double)player.Points / play.PointGoal;
                stats.PointPercentSum += pointPercentage;
            }
        }

        foreach (var (id, stat) in statsLookup)
        {
            overall.AddStatistic(stat);
        }

        return Ok(overall);
    }
}