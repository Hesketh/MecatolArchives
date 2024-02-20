using Hesketh.MecatolArchives.DB;

namespace Hesketh.MecatolArchives.API.Helpers;

public static class DevelopmentDataSeedingHelper
{
    private const uint PlaysToGenerate = 25;
    private const int MinPlayersInPlay = 3;
    private const int MaxPlayersInPlay = 8;
    private const int MaxPoints = 10;
    private const int MinPoints = 0;
    private const int MaxDaysDifferenceInDate = 1000;

    private const uint DataFieldsToGenerate = 10;

    private static readonly Random Random = new Random(404);
    private static readonly NounHelper NounHelper = new NounHelper(Random);

    public static async Task Seed(MecatolArchivesDbContext db)
    {
        await GenerateDataFields(db);
        await GeneratePlays(db);

        await db.SaveChangesAsync();
    }

    private static async Task GeneratePlays(MecatolArchivesDbContext db)
    {
        for (int i = 0; i < PlaysToGenerate; i++)
        {
            var play = new DBM.Play()
            {
                Identifier = Guid.NewGuid(),
                UtcDate = GetRandomUtcDate(),
                PointGoal = 10,
                RulesVersion = 2.0,
                Map = null,
                Expansions = GetRandomExpansions(db),
                Variants = GetRandomVariants(db),
            };
            play.Players = GetRandomPlayers(db, play);
            await db.AddAsync(play);
        }
        await db.SaveChangesAsync();
    }

    private static DBM.Colour GetRandomColour(MecatolArchivesDbContext db, ICollection<Guid> invalid)
    {
        var index = Random.Next(0, db.Colours.Count(x => !invalid.Contains(x.Identifier)));
        return db.Colours.Where(x => !invalid.Contains(x.Identifier)).Skip(index - 1).First();
    }
    
    private static DBM.Faction GetRandomFaction(MecatolArchivesDbContext db, ICollection<Guid> invalid)
    {
        var index = Random.Next(0, db.Factions.Count(x => !invalid.Contains(x.Identifier)));
        return db.Factions.Where(x => !invalid.Contains(x.Identifier)).Skip(index - 1).First();
    }
    
    private static DBM.Person GetRandomPerson(MecatolArchivesDbContext db, ICollection<Guid> invalid)
    {
        var index = Random.Next(0, db.People.Count(x => !invalid.Contains(x.Identifier)));
        return db.People.Where(x => !invalid.Contains(x.Identifier)).Skip(index - 1).First();
    }
    
    private static ICollection<DBM.Player> GetRandomPlayers(MecatolArchivesDbContext db, DBM.Play play)
    {
        var res = new List<DBM.Player>();
        var playerCount = Random.Next(MinPlayersInPlay, MaxPlayersInPlay + 1);
        for (int i = 0; i < playerCount; i++)
        {
            var player = new DBM.Player
            {
                Identifier = Guid.NewGuid(),
                Person = GetRandomPerson(db, res.Select(x => x.Person.Identifier).ToList()),
                Faction =  GetRandomFaction(db, res.Select(x => x.Faction.Identifier).ToList()),
                Colour =  GetRandomColour(db, res.Select(x => x.Colour.Identifier).ToList()),
                Points = (uint)Random.Next(MinPoints, MaxPoints + 1),
                Eliminated = GetRandomBool(50),
            };
            
            db.Add(player);
            player.Play = play;
            res.Add(player);
        }

        var winner = res.OrderByDescending(x => x.Points).First();
        winner.Winner = !GetRandomBool(10);
        
        return res;
    }

    private static ICollection<DBM.Expansion> GetRandomExpansions(MecatolArchivesDbContext db)
    {
        var res = new List<DBM.Expansion>();
        foreach (var expansion in db.Expansions)
        {
            if (GetRandomBool(1))
            {
                res.Add(expansion);
            }
        }
        return res;
    }
    
    private static ICollection<DBM.Variant> GetRandomVariants(MecatolArchivesDbContext db)
    {
        var res = new List<DBM.Variant>();
        foreach (var variant in db.Variants)
        {
            if (GetRandomBool(3))
            {
                res.Add(variant);
            }
        }
        return res;
    }

    private static DateTime GetRandomUtcDate()
    {
        var modifier = Random.Next(-MaxDaysDifferenceInDate, MaxDaysDifferenceInDate);
        return DateTime.UtcNow.AddDays(modifier);
    }

    private static bool GetRandomBool(int chance)
    {
        return Random.Next(0, chance) == 0;
    }
    
    private static async Task GenerateDataFields(MecatolArchivesDbContext db)
    {
        for (int i = 0; i < DataFieldsToGenerate; i++)
        {
            var person = GeneratePerson();
            await db.AddAsync(person);
            
            var colour = GenerateColour();
            await db.AddAsync(colour);
            
            var faction = GenerateFaction();
            await db.AddAsync(faction);

            var variant = GenerateVariant();
            await db.AddAsync(variant);
        }
        
        await db.SaveChangesAsync();
    }

    private static DBM.Person GeneratePerson()
    {
        return new DBM.Person
        {
            Identifier = Guid.NewGuid(),
            Name = NounHelper.GetRandomNoun()
        };
    }
    
    private static DBM.Colour GenerateColour()
    {
        return new DBM.Colour
        {
            Identifier = Guid.NewGuid(),
            Name = NounHelper.GetRandomNoun(),
            Hex = NounHelper.GetRandomColour()
        };
    }

    private static DBM.Faction GenerateFaction()
    {
        return new DBM.Faction
        {
            Identifier = Guid.NewGuid(),
            Name = NounHelper.GetRandomNoun()
        };
    }
    
    private static DBM.Variant GenerateVariant()
    {
        return new DBM.Variant
        {
            Identifier = Guid.NewGuid(),
            Name = NounHelper.GetRandomNoun()
        };
    }
}