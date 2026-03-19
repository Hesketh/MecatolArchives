using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace MecatolArchives.Domain.Services;

public sealed class PlayManagementService(MecatolArchivesDbContext dbContext)
    : CRUDManagementServiceBase<DataAccess.Models.Play, Play, PlayCreateRequest, PlayUpdateRequest>(dbContext), IPlayManagementService
{
    protected override async Task<Play> MapToDto(DataAccess.Models.Play dbModel)
    {
        var players = await DbContext.Players
            .Where(p => EF.Property<Guid>(p, "PlayIdentifier") == dbModel.Identifier)
            .Include(p => p.Person)
            .Include(p => p.Faction).ThenInclude(f => f.Variants)
            .Include(p => p.Colour)
            .AsNoTracking()
            .ToListAsync();

        var expansions = await DbContext.Expansions
            .Where(e => e.Plays.Any(p => p.Identifier == dbModel.Identifier))
            .AsNoTracking()
            .ToListAsync();

        var variants = await DbContext.Variants
            .Where(v => v.Plays.Any(p => p.Identifier == dbModel.Identifier))
            .AsNoTracking()
            .ToListAsync();

        return new Play
        {
            Identifier = dbModel.Identifier,
            UtcDate = dbModel.UtcDate,
            RulesVersion = dbModel.RulesVersion,
            PointGoal = dbModel.PointGoal,
            Map = dbModel.Map,
            Players = new(players.Select(MapToDto).ToArray()),
            Expansions = new(expansions.Select(e => new Content { Identifier = e.Identifier, Name = e.Name }).ToArray()),
            Variants = new(variants.Select(v => new Variant { Identifier = v.Identifier, Name = v.Name }).ToArray()),
        };
    }

    private Player MapToDto(DataAccess.Models.Player player)
    {
        return new Player
        {
            Identifier = player.Identifier,
            Points = player.Points,
            Winner = player.Winner,
            Eliminated = player.Eliminated,
            DraftOrder = player.DraftOrder,
            Person = new Person { Identifier = player.Person.Identifier, Name = player.Person.Name },
            Faction = new Faction
            {
                Identifier = player.Faction.Identifier,
                Name = player.Faction.Name,
                Url = player.Faction.Url ?? string.Empty,
                Variants = new(player.Faction.Variants.Select(v => new FactionVariant { Identifier = v.Identifier, Name = v.Name }).ToArray()),
            },
            Colour = new Colour { Identifier = player.Colour.Identifier, Name = player.Colour.Name, Hex = player.Colour.Hex },
        };
    }

    protected override async Task<DataAccess.Models.Play> MapToDb(PlayCreateRequest create)
    {
        var expansions = await DbContext.Expansions
            .Where(e => create.Expansions.Items.Contains(e.Identifier))
            .ToListAsync();

        var variants = await DbContext.Variants
            .Where(v => create.Variants.Items.Contains(v.Identifier))
            .ToListAsync();

        var players = new List<DataAccess.Models.Player>();
        foreach (var playerRequest in create.Players.Items)
        {
            var person = await DbContext.People.FindAsync(playerRequest.PersonIdentifier);
            var faction = await DbContext.Factions.FindAsync(playerRequest.FactionIdentifier);
            var colour = await DbContext.Colours.FindAsync(playerRequest.ColourIdentified);

            players.Add(new DataAccess.Models.Player
            {
                Identifier = Guid.NewGuid(),
                Points = playerRequest.Points,
                Winner = playerRequest.Winner,
                Eliminated = playerRequest.Eliminated,
                DraftOrder = playerRequest.DraftOrder,
                Person = person!,
                Faction = faction!,
                Colour = colour!,
            });
        }

        return new DataAccess.Models.Play
        {
            Identifier = Guid.NewGuid(),
            UtcDate = create.UtcDate,
            RulesVersion = create.RulesVersion,
            PointGoal = create.PointGoal,
            Map = create.Map,
            Players = players,
            Expansions = expansions,
            Variants = variants,
        };
    }

    protected override async Task<DataAccess.Models.Play> MapToDb(DataAccess.Models.Play dbModel, PlayUpdateRequest update)
    {
        if (update.UtcDate.HasValue)
            dbModel.UtcDate = update.UtcDate.Value;

        if (update.RulesVersion.HasValue)
            dbModel.RulesVersion = update.RulesVersion.Value;

        if (update.PointGoal.HasValue)
            dbModel.PointGoal = update.PointGoal.Value;

        if (update.Map != null)
            dbModel.Map = update.Map;

        if (update.Expansions != null)
        {
            await DbContext.Entry(dbModel).Collection(p => p.Expansions).LoadAsync();
            var expansions = await DbContext.Expansions
                .Where(e => update.Expansions.Items.Contains(e.Identifier))
                .ToListAsync();
            dbModel.Expansions = expansions;
        }

        if (update.Variants != null)
        {
            await DbContext.Entry(dbModel).Collection(p => p.Variants).LoadAsync();
            var variants = await DbContext.Variants
                .Where(v => update.Variants.Items.Contains(v.Identifier))
                .ToListAsync();
            dbModel.Variants = variants;
        }

        return dbModel;
    }
}
