using Hesketh.MecatolArchives.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Hesketh.MecatolArchives.DB;

public sealed class MecatolArchivesDbContext : DbContext
{
    private const string UnknownName = "_Unknown_";

    public MecatolArchivesDbContext(DbContextOptions<MecatolArchivesDbContext> options) : base(options) { }

    public DbSet<Colour> Colours { get; set; } = null!;
    public DbSet<Expansion> Expansions { get; set; } = null!;
    public DbSet<Faction> Factions { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Play> Plays { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Variant> Variants { get; set; } = null!;

    public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEntity
    {
        if (typeof(TEntity) == typeof(Colour)) return Colours as DbSet<TEntity>;
        if (typeof(TEntity) == typeof(Expansion)) return Expansions as DbSet<TEntity>;
        if (typeof(TEntity) == typeof(Faction)) return Factions as DbSet<TEntity>;
        if (typeof(TEntity) == typeof(Person)) return People as DbSet<TEntity>;
        if (typeof(TEntity) == typeof(Play)) return Plays as DbSet<TEntity>;
        if (typeof(TEntity) == typeof(Player)) return Players as DbSet<TEntity>;
        if (typeof(TEntity) == typeof(Variant)) return Variants as DbSet<TEntity>;

        throw new InvalidOperationException($"No DbSet is registered for type {typeof(TEntity).FullName}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedExpansions(modelBuilder);
        SeedColours(modelBuilder);
        SeedFactions(modelBuilder);
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
            Name = UnknownName
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