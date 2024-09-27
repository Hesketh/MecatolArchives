using AutoMapper;
using Hesketh.MecatolArchives.DB;
using Hesketh.MecatolArchives.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hesketh.MecatolArchives.API.Controllers;

[ApiController]
[Route("people/{playerIdentifier}/achievements")]
[Authorize]
public sealed class PersonAchievementController(MecatolArchivesDbContext db, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ICollection<Data.PersonAchievement>>> Get(Guid playerIdentifier)
    {
        var player = await db.People
            .Include(x => x.Achievements)
            .ThenInclude(personAchievement => personAchievement.Achievement)
            .FirstOrDefaultAsync(x => x.Identifier == playerIdentifier);
        if (player == null)
            return NotFound();

        var achievements = await db.Achievements.ToListAsync();

        var returnAchievements = new Dictionary<Guid, Data.PersonAchievement>();
        foreach (var playerAchievement in player.Achievements)
        {
            var mapped = mapper.Map<Data.PersonAchievement>(playerAchievement);
            returnAchievements[mapped.Achievement.Identifier] = mapped;
        }

        foreach (var achievement in achievements)
        {
            if (!returnAchievements.ContainsKey(achievement.Identifier))
            {
                returnAchievements[achievement.Identifier] = new Data.PersonAchievement
                {
                    Achievement = mapper.Map<Data.Achievement>(achievement)
                };
            }
        }

        return Ok(returnAchievements.Values.OrderBy(x => x.Achievement.Name).ToList());
    }

    [HttpPost("{achievementIdentifier}")]
    public async Task<ActionResult<Data.PersonAchievement>> Grant(Guid playerIdentifier, Guid achievementIdentifier)
    {
        var player = await db.People
            .Include(x => x.Achievements)
            .ThenInclude(personAchievement => personAchievement.Achievement)
            .FirstOrDefaultAsync(x => x.Identifier == playerIdentifier);
        if (player == null)
            return NotFound();

        var achievement = await db.Achievements.FirstOrDefaultAsync(x => x.Identifier == achievementIdentifier);
        if (achievement == null)
            return NotFound();

        var personAchievement =
            player.Achievements.FirstOrDefault(x => x.Achievement.Identifier == achievement.Identifier);
        if (personAchievement == null)
        {
            personAchievement = new PersonAchievement
            {
                Achievement = achievement,
                DateAccomplished = DateTime.UtcNow,
                Person = player
            };
            db.PersonAchievements.Add(personAchievement);

            await db.SaveChangesAsync();
        }

        return mapper.Map<Data.PersonAchievement>(personAchievement);
    }

    [HttpDelete("{achievementIdentifier}")]
    public async Task<IActionResult> Delete(Guid playerIdentifier, Guid achievementIdentifier)
    {
        var player = await db.People
            .Include(x => x.Achievements)
            .ThenInclude(personAchievement => personAchievement.Achievement)
            .FirstOrDefaultAsync(x => x.Identifier == playerIdentifier);
        if (player == null)
            return NotFound();

        var achievement = await db.Achievements.FirstOrDefaultAsync(x => x.Identifier == achievementIdentifier);
        if (achievement == null)
            return NotFound();

        var personAchievement =
            player.Achievements.FirstOrDefault(x => x.Achievement.Identifier == achievement.Identifier);
        if (personAchievement != null)
        {
            db.PersonAchievements.Remove(personAchievement);
            await db.SaveChangesAsync();
        }

        return NoContent();
    }
}