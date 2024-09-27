using Hesketh.MecatolArchives.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Hesketh.MecatolArchives.DB;

public sealed class MecatolArchivesDbContext : DbContext
{
    public const string UnknownName = "_Unknown_";

    public MecatolArchivesDbContext(DbContextOptions<MecatolArchivesDbContext> options) : base(options)
    {
    }

    public DbSet<Colour> Colours { get; set; } = null!;
    public DbSet<Expansion> Expansions { get; set; } = null!;
    public DbSet<Faction> Factions { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Play> Plays { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Variant> Variants { get; set; } = null!;
    public DbSet<Achievement> Achievements { get; set; } = null!;
    public DbSet<PlayerAchievement> PlayerAchievements { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedExpansions(modelBuilder);
        SeedColours(modelBuilder);
        SeedFactions(modelBuilder);
        SeedVariants(modelBuilder);
        SeedAchievements(modelBuilder);
    }

    private void SeedAchievements(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>().HasData(new Achievement
        {
            Identifier = Guid.Parse("92ea4713-8c2d-43a8-8be1-0b24a4d1dc72"),
            Name = "Dragon Hoard",
            Condition = "Win a game with 40 or more unspent trade goods"
        },new Achievement
        {
            Identifier = Guid.Parse("bd1cf513-c6ef-44e5-ac4d-02c17fd0b11c"),
            Name = "Not a Threat",
            Condition = "Score 6 VP in one game round"
        },new Achievement
        {
            Identifier = Guid.Parse("ac0da407-c6ef-44e5-ac4d-02c17fd0b11c"),
            Name = "Forever War",
            Condition = "Win a 1v1 Infantry-only combat that lasted longer than 8 rounds"
        },new Achievement
        {
            Identifier = Guid.Parse("bc8e2ebc-a3a6-4311-932e-f99f5093ef06"),
            Name = "Four Horsemen, or Not a Very Good Psychic",
            Condition = "Be on the losing side of an agenda in which at least 4 riders were contributed to the losing side"
        },new Achievement
        {
            Identifier = Guid.Parse("0e928bf1-9527-42ea-9f2f-c3844e5af89f"),
            Name = "I Made This",
            Condition = "Trade someone their own promissory note"
        },new Achievement
        {
            Identifier = Guid.Parse("b2427957-809f-48df-82cd-a3e68ec6acd9"),
            Name = "Interdimensional Highway",
            Condition = "Achieve a move value of 9 on a single ship"
        },new Achievement
        {
            Identifier = Guid.Parse("164130f9-04b2-4565-83e2-a6e447eeac1d"),
            Name = "It was Always Going to Be Me",
            Condition = "Score your 10th victory point from Become a Martyr"
        },new Achievement
        {
            Identifier = Guid.Parse("bca4b731-ed05-4a8d-a999-6d2691bd2910"),
            Name = "It's Probably Blue",
            Condition = "Research every technology of one colour"
        },new Achievement
        {
            Identifier = Guid.Parse("de70f3cb-055b-4e00-adad-a13a3fd389d3"),
            Name = "Not-Very-Secret Objective",
            Condition = "Score at least 5 secret objectives"
        },new Achievement
        {
            Identifier = Guid.Parse("f695d3ad-c45f-4ca1-a6b7-24eca4fc3f2c"),
            Name = "Mano-a-Mano",
            Condition = "Win a game without researching technology"
        },new Achievement
        {
            Identifier = Guid.Parse("ff07a297-5138-4833-bf5f-0d05c5b03714"),
            Name = "Materiel World",
            Condition = "Build all of your plastic units"
        },new Achievement
        {
            Identifier = Guid.Parse("d36b22df-ec6d-462c-bbad-5e4c1de7c31e"),
            Name = "OSHA Violation",
            Condition = "Lose 10 or more units at once to the Van Hague as the Yin Brotherhood"
        },new Achievement
        {
            Identifier = Guid.Parse("346cd853-985b-43fd-aef9-84f3ab191a84"),
            Name = "Rainbow Deluxe Ultra",
            Condition = "Have an Alliance promissory that belongs to each other player in a 6-8 player game"
        },new Achievement
        {
            Identifier = Guid.Parse("39671dae-9c18-48df-a553-97da3c274825"),
            Name = "Reduce, Reuse, Regret",
            Condition = "Lose 35 resources worth of units in one combat"
        },new Achievement
        {
            Identifier = Guid.Parse("9b6702fc-e324-477a-802d-d356641f22e2"),
            Name = "Rinfinity",
            Condition = "As Jol-Nar, have at least 12 technologies and replace them with 12 different technologies"
        },new Achievement
        {
            Identifier = Guid.Parse("199cac45-fb56-4a1d-b70e-b15e92e3295b"),
            Name = "ROYGBIV",
            Condition = "Have at least 1 promissory note that belongs to each other player in a 6-8 player game"
        },new Achievement
        {
            Identifier = Guid.Parse("296beeb1-3274-4bd3-aca4-0286aa56ea60"),
            Name = "Sincerely, Deleted",
            Condition = "Lose 10 or more units at once to the Van Hague, Nova Seed, Armageddon Relay, Stellar Converter, Ixthian Artifact, or Dimensional Anchor"
        },new Achievement
        {
            Identifier = Guid.Parse("7d4629c6-f7e9-447e-a782-af89ed6ce9fd"),
            Name = "Solitaire",
            Condition = "Win a game without initiating combat against or exchanging possessions with another player"
        },new Achievement
        {
            Identifier = Guid.Parse("3b4a3002-bde6-4987-9286-0657c9a3a855"),
            Name = "Someone Call and Ambulance",
            Condition = "As the Mahact, have at least 5 command tokens on your sheet that belong to other players"
        },new Achievement
        {
            Identifier = Guid.Parse("bdc26e9a-d83d-43f8-8bfd-31828e9341cf"),
            Name = "That's Illegal",
            Condition = "As a non-Creuss player, fire a PDS shot through the Hil Colish into another system"
        },new Achievement
        {
            Identifier = Guid.Parse("5b5904b4-43f8-4a5e-8135-bd16b940c3c5"),
            Name = "This Doesn't Seem Physically Possible",
            Condition = "Participate in a game that ends with Imperium Rex"
        },new Achievement
        {
            Identifier = Guid.Parse("fa69694d-1f7f-4e56-8a72-6dc6c1c37039"),
            Name = "This Hurts You",
            Condition = "Control 3 other players' home system at the same time"
        },new Achievement
        {
            Identifier = Guid.Parse("6925136c-5ab4-46cd-a056-10ae4954bf05"),
            Name = "We Trained Him Wrong, As a Joke",
            Condition = "Research Dacxive Animators, Magen Defense Grid, Infantry II, X-89 Bacterial Weapon, Psychoarchaeology and no other technologies"
        },new Achievement
        {
            Identifier = Guid.Parse("94a53e84-ad95-47c0-92c1-a69a0c3c60d0"),
            Name = "X Minus This",
            Condition = "Refresh no toehr player's commodities when resolving the primary ability of the Trade strategy card"
        },new Achievement
        {
            Identifier = Guid.Parse("8e9165ba-6f5e-4690-971f-ec62120f50a2"),
            Name = "49/59",
            Condition = "Completely wipe out a planet that had at least 3 infantry using the Plague action card"
        });
    }

    private void SeedVariants(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Variant>().HasData(new Variant
        {
            Identifier = Guid.Parse("4082a883-4c5f-44c7-abf6-0d4823698cb0"),
            Name = "Standard"
        }, new Variant
        {
            Identifier = Guid.Parse("f018f38e-85fd-4c5b-9036-d9c071aae506"),
            Name = "Competitive"
        }, new Variant
        {
            Identifier = Guid.Parse("c0db28a6-29e1-4463-a187-dd49d5416c0a"),
            Name = "Milty"
        }, new Variant
        {
            Identifier = Guid.Parse("b6125086-d6ae-4f4a-b981-5f4e63b15cc0"),
            Name = "Alliance"
        }, new Variant
        {
            Identifier = Guid.Parse("5b8c8301-b5e9-4c72-b6fa-b07cb30005be"),
            Name = "Pax Magnifica"
        });
    }

    private void SeedExpansions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expansion>().HasData(new Expansion
        {
            Identifier = Guid.Parse("fb08d4e6-5ac1-4cbf-8eb9-166f6c5e41f0"),
            Name = "Prophecy of Kings"
        }, new Expansion
        {
            Identifier = Guid.Parse("21fbcaf7-ae17-4db7-851a-dc65eb3ba60f"),
            Name = "Codex I: Ordinian"
        }, new Expansion
        {
            Identifier = Guid.Parse("9420502f-4ef0-4887-add4-3d8a4941016a"),
            Name = "Codex II: Affinity"
        }, new Expansion
        {
            Identifier = Guid.Parse("1eb732ba-74ac-4993-943e-cd6f3650d310"),
            Name = "Codex III: Vigil"
        }, new Expansion
        {
            Identifier = Guid.Parse("2b7c9cd6-a7d8-40f1-843d-8f10c7c45fb3"),
            Name = "Omega Initiative I"
        }, new Expansion
        {
            Identifier = Guid.Parse("0e886b80-9ef3-48c0-bfc5-8107ee183c1b"),
            Name = "Omega Initiative II"
        });
    }

    private void SeedFactions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faction>().HasData(new Faction
        {
            Identifier = Guid.Parse("11ee6931-58d5-4808-b2c5-e3d4b7bf4343"),
            Name = "The Arborec"
        }, new Faction
        {
            Identifier = Guid.Parse("e4d8ad5c-cf62-4001-9b81-f2a31bd87b0d"),
            Name = "The Barony of Letnev"
        }, new Faction
        {
            Identifier = Guid.Parse("b01aaa66-1888-4926-803e-95a864057219"),
            Name = "The Clan of Saar"
        }, new Faction
        {
            Identifier = Guid.Parse("fcae96dd-793a-4393-9f5f-f378ff167b12"),
            Name = "The Embers of Muaat"
        }, new Faction
        {
            Identifier = Guid.Parse("c9a5311a-4798-44c5-8b97-3a5bc4eaa01a"),
            Name = "The Emirates of Hacan"
        }, new Faction
        {
            Identifier = Guid.Parse("a386b3e8-683b-4e7e-9fba-3361bdbbeef1"),
            Name = "The Federation of Sol"
        }, new Faction
        {
            Identifier = Guid.Parse("2e017142-848a-4203-a109-1fa905a5db04"),
            Name = "The Ghosts of Creuss"
        }, new Faction
        {
            Identifier = Guid.Parse("4df36a67-6b3d-4966-ae0c-6ebdb6d0a97d"),
            Name = "The L1Z1X Mindnet"
        }, new Faction
        {
            Identifier = Guid.Parse("c765da52-404b-4073-8c0c-003537169b4c"),
            Name = "The Mentak Coalition"
        }, new Faction
        {
            Identifier = Guid.Parse("2002e0b3-603f-4b66-8268-2ca8ab2bfce4"),
            Name = "The Naalu Collective"
        }, new Faction
        {
            Identifier = Guid.Parse("79c4217c-dc20-46fe-9e0b-44e852dfc64b"),
            Name = "The Nekro Virus"
        }, new Faction
        {
            Identifier = Guid.Parse("1a5777dc-4106-46ec-8168-596c7c9edd36"),
            Name = "Sardakk N'orr"
        }, new Faction
        {
            Identifier = Guid.Parse("0cc14756-19f7-42ef-acd0-156fab6bcd2b"),
            Name = "The Universities of Jol-Nar"
        }, new Faction
        {
            Identifier = Guid.Parse("9b8cf62c-9c94-49aa-b55b-11a8f4f9a7c9"),
            Name = "The Winnu"
        }, new Faction
        {
            Identifier = Guid.Parse("279eefc5-4bd3-41be-93d0-b49bd6e9b7d6"),
            Name = "The Xxcha Kingdom"
        }, new Faction
        {
            Identifier = Guid.Parse("2c637584-cdbb-485e-8c3f-bc713eebaa03"),
            Name = "The Yin Brotherhood"
        }, new Faction
        {
            Identifier = Guid.Parse("5265b1f2-4422-4d0b-8711-582330d9afe4"),
            Name = "The Yssaril Tribes"
        }, new Faction
        {
            Identifier = Guid.Parse("be81d0fd-0ba8-4d55-ac65-4eb66d49028a"),
            Name = "The Argent Flight"
        }, new Faction
        {
            Identifier = Guid.Parse("f39815c4-b651-4ed4-86e0-5b4f5f6128ef"),
            Name = "The Empyrean"
        }, new Faction
        {
            Identifier = Guid.Parse("2fffa08d-40ab-4e29-8e4a-0cda97b664be"),
            Name = "The Mahact Gene-Sorcerers"
        }, new Faction
        {
            Identifier = Guid.Parse("26251032-94c9-4331-8ccf-697755213fad"),
            Name = "The Naaz-Rokha Alliance"
        }, new Faction
        {
            Identifier = Guid.Parse("4210c2bb-f773-4721-907b-1c3e1cd11357"),
            Name = "The Nomad"
        }, new Faction
        {
            Identifier = Guid.Parse("c4e77f65-5a61-404f-8793-b672ccdb29a4"),
            Name = "The Titans of UL"
        }, new Faction
        {
            Identifier = Guid.Parse("91da5e70-a3db-4168-b18d-61ae7b899b48"),
            Name = "The Vuil'Raith Cabal"
        }, new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres (The Mentak Coalition)"
        }, new Faction
        {
            Identifier = Guid.Parse("d819ecf0-3ccd-45d1-9f19-ba045d39fd65"),
            Name = "The Council Keleres (The Xxcha Kingdoms)"
        }, new Faction
        {
            Identifier = Guid.Parse("0747201a-f0ae-4c88-840f-00a3d6c618a0"),
            Name = "The Council Keleres (The Argent Flight)"
        }, new Faction
        {
            Identifier = Guid.Parse("609382d1-c969-4144-916a-ad4c13df1352"),
            Name = UnknownName,
            HideFromStatistics = true,
        });
    }

    private void SeedColours(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colour>().HasData(new Colour
        {
            Identifier = Guid.Parse("CBDFDDA9-13BF-4A45-BE5D-0882F6DCBAD8"),
            Hex = string.Empty,
            Name = UnknownName
        }, new Colour
        {
            Identifier = Guid.Parse("564F166E-33CB-45CC-BCA6-1B2D16B8BF60"),
            Hex = "#000000",
            Name = "Black"
        }, new Colour
        {
            Identifier = Guid.Parse("53BF36A1-669C-41ED-9CED-4FA94BA038EE"),
            Hex = "#FF0000",
            Name = "Red"
        }, new Colour
        {
            Identifier = Guid.Parse("E8CA7B27-00CD-4A2A-BC7F-17105E690E2D"),
            Hex = "#008000",
            Name = "Green"
        }, new Colour
        {
            Identifier = Guid.Parse("51B6CC96-0E35-48F9-8665-B50BBE3FDB44"),
            Hex = "#FFFF00",
            Name = "Yellow"
        }, new Colour
        {
            Identifier = Guid.Parse("A9C3B568-D781-452D-91AE-44B0CC8E7020"),
            Hex = "#800080",
            Name = "Purple"
        }, new Colour
        {
            Identifier = Guid.Parse("43C078A5-0561-40F0-8ADC-92AFA32EAEB0"),
            Hex = "#FFA500",
            Name = "Orange"
        }, new Colour
        {
            Identifier = Guid.Parse("DACEDA53-E450-4FCE-82D4-EF1CDD312E38"),
            Hex = "#FF00FF",
            Name = "Magenta"
        }, new Colour
        {
            Identifier = Guid.Parse("B5616B41-2821-4A27-85DC-FA81B899E578"),
            Hex = "#0000FF",
            Name = "Blue"
        });
    }
}