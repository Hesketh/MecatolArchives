﻿// <auto-generated />
using System;
using Hesketh.MecatolArchives.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hesketh.MecatolArchives.DB.Migrations.Mssql.Migrations
{
    [DbContext(typeof(MecatolArchivesDbContext))]
    [Migration("20240927210327_AchievementsPerPerson")]
    partial class AchievementsPerPerson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExpansionPlay", b =>
                {
                    b.Property<Guid>("ExpansionsIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaysIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExpansionsIdentifier", "PlaysIdentifier");

                    b.HasIndex("PlaysIdentifier");

                    b.ToTable("ExpansionPlay");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Achievement", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Identifier");

                    b.ToTable("Achievements");

                    b.HasData(
                        new
                        {
                            Identifier = new Guid("92ea4713-8c2d-43a8-8be1-0b24a4d1dc72"),
                            Condition = "Win a game with 40 or more unspent trade goods",
                            Name = "Dragon Hoard"
                        },
                        new
                        {
                            Identifier = new Guid("bd1cf513-c6ef-44e5-ac4d-02c17fd0b11c"),
                            Condition = "Score 6 VP in one game round",
                            Name = "Not a Threat"
                        },
                        new
                        {
                            Identifier = new Guid("ac0da407-c6ef-44e5-ac4d-02c17fd0b11c"),
                            Condition = "Win a 1v1 Infantry-only combat that lasted longer than 8 rounds",
                            Name = "Forever War"
                        },
                        new
                        {
                            Identifier = new Guid("bc8e2ebc-a3a6-4311-932e-f99f5093ef06"),
                            Condition = "Be on the losing side of an agenda in which at least 4 riders were contributed to the losing side",
                            Name = "Four Horsemen, or Not a Very Good Psychic"
                        },
                        new
                        {
                            Identifier = new Guid("0e928bf1-9527-42ea-9f2f-c3844e5af89f"),
                            Condition = "Trade someone their own promissory note",
                            Name = "I Made This"
                        },
                        new
                        {
                            Identifier = new Guid("b2427957-809f-48df-82cd-a3e68ec6acd9"),
                            Condition = "Achieve a move value of 9 on a single ship",
                            Name = "Interdimensional Highway"
                        },
                        new
                        {
                            Identifier = new Guid("164130f9-04b2-4565-83e2-a6e447eeac1d"),
                            Condition = "Score your 10th victory point from Become a Martyr",
                            Name = "It was Always Going to Be Me"
                        },
                        new
                        {
                            Identifier = new Guid("bca4b731-ed05-4a8d-a999-6d2691bd2910"),
                            Condition = "Research every technology of one colour",
                            Name = "It's Probably Blue"
                        },
                        new
                        {
                            Identifier = new Guid("de70f3cb-055b-4e00-adad-a13a3fd389d3"),
                            Condition = "Score at least 5 secret objectives",
                            Name = "Not-Very-Secret Objective"
                        },
                        new
                        {
                            Identifier = new Guid("f695d3ad-c45f-4ca1-a6b7-24eca4fc3f2c"),
                            Condition = "Win a game without researching technology",
                            Name = "Mano-a-Mano"
                        },
                        new
                        {
                            Identifier = new Guid("ff07a297-5138-4833-bf5f-0d05c5b03714"),
                            Condition = "Build all of your plastic units",
                            Name = "Materiel World"
                        },
                        new
                        {
                            Identifier = new Guid("d36b22df-ec6d-462c-bbad-5e4c1de7c31e"),
                            Condition = "Lose 10 or more units at once to the Van Hague as the Yin Brotherhood",
                            Name = "OSHA Violation"
                        },
                        new
                        {
                            Identifier = new Guid("346cd853-985b-43fd-aef9-84f3ab191a84"),
                            Condition = "Have an Alliance promissory that belongs to each other player in a 6-8 player game",
                            Name = "Rainbow Deluxe Ultra"
                        },
                        new
                        {
                            Identifier = new Guid("39671dae-9c18-48df-a553-97da3c274825"),
                            Condition = "Lose 35 resources worth of units in one combat",
                            Name = "Reduce, Reuse, Regret"
                        },
                        new
                        {
                            Identifier = new Guid("9b6702fc-e324-477a-802d-d356641f22e2"),
                            Condition = "As Jol-Nar, have at least 12 technologies and replace them with 12 different technologies",
                            Name = "Rinfinity"
                        },
                        new
                        {
                            Identifier = new Guid("199cac45-fb56-4a1d-b70e-b15e92e3295b"),
                            Condition = "Have at least 1 promissory note that belongs to each other player in a 6-8 player game",
                            Name = "ROYGBIV"
                        },
                        new
                        {
                            Identifier = new Guid("296beeb1-3274-4bd3-aca4-0286aa56ea60"),
                            Condition = "Lose 10 or more units at once to the Van Hague, Nova Seed, Armageddon Relay, Stellar Converter, Ixthian Artifact, or Dimensional Anchor",
                            Name = "Sincerely, Deleted"
                        },
                        new
                        {
                            Identifier = new Guid("7d4629c6-f7e9-447e-a782-af89ed6ce9fd"),
                            Condition = "Win a game without initiating combat against or exchanging possessions with another player",
                            Name = "Solitaire"
                        },
                        new
                        {
                            Identifier = new Guid("3b4a3002-bde6-4987-9286-0657c9a3a855"),
                            Condition = "As the Mahact, have at least 5 command tokens on your sheet that belong to other players",
                            Name = "Someone Call and Ambulance"
                        },
                        new
                        {
                            Identifier = new Guid("bdc26e9a-d83d-43f8-8bfd-31828e9341cf"),
                            Condition = "As a non-Creuss player, fire a PDS shot through the Hil Colish into another system",
                            Name = "That's Illegal"
                        },
                        new
                        {
                            Identifier = new Guid("5b5904b4-43f8-4a5e-8135-bd16b940c3c5"),
                            Condition = "Participate in a game that ends with Imperium Rex",
                            Name = "This Doesn't Seem Physically Possible"
                        },
                        new
                        {
                            Identifier = new Guid("fa69694d-1f7f-4e56-8a72-6dc6c1c37039"),
                            Condition = "Control 3 other players' home system at the same time",
                            Name = "This Hurts You"
                        },
                        new
                        {
                            Identifier = new Guid("6925136c-5ab4-46cd-a056-10ae4954bf05"),
                            Condition = "Research Dacxive Animators, Magen Defense Grid, Infantry II, X-89 Bacterial Weapon, Psychoarchaeology and no other technologies",
                            Name = "We Trained Him Wrong, As a Joke"
                        },
                        new
                        {
                            Identifier = new Guid("94a53e84-ad95-47c0-92c1-a69a0c3c60d0"),
                            Condition = "Refresh no toehr player's commodities when resolving the primary ability of the Trade strategy card",
                            Name = "X Minus This"
                        },
                        new
                        {
                            Identifier = new Guid("8e9165ba-6f5e-4690-971f-ec62120f50a2"),
                            Condition = "Completely wipe out a planet that had at least 3 infantry using the Plague action card",
                            Name = "49/59"
                        });
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Colour", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Hex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifier");

                    b.ToTable("Colours");

                    b.HasData(
                        new
                        {
                            Identifier = new Guid("cbdfdda9-13bf-4a45-be5d-0882f6dcbad8"),
                            Hex = "",
                            Name = "_Unknown_"
                        },
                        new
                        {
                            Identifier = new Guid("564f166e-33cb-45cc-bca6-1b2d16b8bf60"),
                            Hex = "#000000",
                            Name = "Black"
                        },
                        new
                        {
                            Identifier = new Guid("53bf36a1-669c-41ed-9ced-4fa94ba038ee"),
                            Hex = "#FF0000",
                            Name = "Red"
                        },
                        new
                        {
                            Identifier = new Guid("e8ca7b27-00cd-4a2a-bc7f-17105e690e2d"),
                            Hex = "#008000",
                            Name = "Green"
                        },
                        new
                        {
                            Identifier = new Guid("51b6cc96-0e35-48f9-8665-b50bbe3fdb44"),
                            Hex = "#FFFF00",
                            Name = "Yellow"
                        },
                        new
                        {
                            Identifier = new Guid("a9c3b568-d781-452d-91ae-44b0cc8e7020"),
                            Hex = "#800080",
                            Name = "Purple"
                        },
                        new
                        {
                            Identifier = new Guid("43c078a5-0561-40f0-8adc-92afa32eaeb0"),
                            Hex = "#FFA500",
                            Name = "Orange"
                        },
                        new
                        {
                            Identifier = new Guid("daceda53-e450-4fce-82d4-ef1cdd312e38"),
                            Hex = "#FF00FF",
                            Name = "Magenta"
                        },
                        new
                        {
                            Identifier = new Guid("b5616b41-2821-4a27-85dc-fa81b899e578"),
                            Hex = "#0000FF",
                            Name = "Blue"
                        });
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Expansion", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifier");

                    b.ToTable("Expansions");

                    b.HasData(
                        new
                        {
                            Identifier = new Guid("fb08d4e6-5ac1-4cbf-8eb9-166f6c5e41f0"),
                            Name = "Prophecy of Kings"
                        },
                        new
                        {
                            Identifier = new Guid("21fbcaf7-ae17-4db7-851a-dc65eb3ba60f"),
                            Name = "Codex I: Ordinian"
                        },
                        new
                        {
                            Identifier = new Guid("9420502f-4ef0-4887-add4-3d8a4941016a"),
                            Name = "Codex II: Affinity"
                        },
                        new
                        {
                            Identifier = new Guid("1eb732ba-74ac-4993-943e-cd6f3650d310"),
                            Name = "Codex III: Vigil"
                        },
                        new
                        {
                            Identifier = new Guid("2b7c9cd6-a7d8-40f1-843d-8f10c7c45fb3"),
                            Name = "Omega Initiative I"
                        },
                        new
                        {
                            Identifier = new Guid("0e886b80-9ef3-48c0-bfc5-8107ee183c1b"),
                            Name = "Omega Initiative II"
                        });
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Faction", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HideFromStatistics")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifier");

                    b.ToTable("Factions");

                    b.HasData(
                        new
                        {
                            Identifier = new Guid("11ee6931-58d5-4808-b2c5-e3d4b7bf4343"),
                            HideFromStatistics = false,
                            Name = "The Arborec"
                        },
                        new
                        {
                            Identifier = new Guid("e4d8ad5c-cf62-4001-9b81-f2a31bd87b0d"),
                            HideFromStatistics = false,
                            Name = "The Barony of Letnev"
                        },
                        new
                        {
                            Identifier = new Guid("b01aaa66-1888-4926-803e-95a864057219"),
                            HideFromStatistics = false,
                            Name = "The Clan of Saar"
                        },
                        new
                        {
                            Identifier = new Guid("fcae96dd-793a-4393-9f5f-f378ff167b12"),
                            HideFromStatistics = false,
                            Name = "The Embers of Muaat"
                        },
                        new
                        {
                            Identifier = new Guid("c9a5311a-4798-44c5-8b97-3a5bc4eaa01a"),
                            HideFromStatistics = false,
                            Name = "The Emirates of Hacan"
                        },
                        new
                        {
                            Identifier = new Guid("a386b3e8-683b-4e7e-9fba-3361bdbbeef1"),
                            HideFromStatistics = false,
                            Name = "The Federation of Sol"
                        },
                        new
                        {
                            Identifier = new Guid("2e017142-848a-4203-a109-1fa905a5db04"),
                            HideFromStatistics = false,
                            Name = "The Ghosts of Creuss"
                        },
                        new
                        {
                            Identifier = new Guid("4df36a67-6b3d-4966-ae0c-6ebdb6d0a97d"),
                            HideFromStatistics = false,
                            Name = "The L1Z1X Mindnet"
                        },
                        new
                        {
                            Identifier = new Guid("c765da52-404b-4073-8c0c-003537169b4c"),
                            HideFromStatistics = false,
                            Name = "The Mentak Coalition"
                        },
                        new
                        {
                            Identifier = new Guid("2002e0b3-603f-4b66-8268-2ca8ab2bfce4"),
                            HideFromStatistics = false,
                            Name = "The Naalu Collective"
                        },
                        new
                        {
                            Identifier = new Guid("79c4217c-dc20-46fe-9e0b-44e852dfc64b"),
                            HideFromStatistics = false,
                            Name = "The Nekro Virus"
                        },
                        new
                        {
                            Identifier = new Guid("1a5777dc-4106-46ec-8168-596c7c9edd36"),
                            HideFromStatistics = false,
                            Name = "Sardakk N'orr"
                        },
                        new
                        {
                            Identifier = new Guid("0cc14756-19f7-42ef-acd0-156fab6bcd2b"),
                            HideFromStatistics = false,
                            Name = "The Universities of Jol-Nar"
                        },
                        new
                        {
                            Identifier = new Guid("9b8cf62c-9c94-49aa-b55b-11a8f4f9a7c9"),
                            HideFromStatistics = false,
                            Name = "The Winnu"
                        },
                        new
                        {
                            Identifier = new Guid("279eefc5-4bd3-41be-93d0-b49bd6e9b7d6"),
                            HideFromStatistics = false,
                            Name = "The Xxcha Kingdom"
                        },
                        new
                        {
                            Identifier = new Guid("2c637584-cdbb-485e-8c3f-bc713eebaa03"),
                            HideFromStatistics = false,
                            Name = "The Yin Brotherhood"
                        },
                        new
                        {
                            Identifier = new Guid("5265b1f2-4422-4d0b-8711-582330d9afe4"),
                            HideFromStatistics = false,
                            Name = "The Yssaril Tribes"
                        },
                        new
                        {
                            Identifier = new Guid("be81d0fd-0ba8-4d55-ac65-4eb66d49028a"),
                            HideFromStatistics = false,
                            Name = "The Argent Flight"
                        },
                        new
                        {
                            Identifier = new Guid("f39815c4-b651-4ed4-86e0-5b4f5f6128ef"),
                            HideFromStatistics = false,
                            Name = "The Empyrean"
                        },
                        new
                        {
                            Identifier = new Guid("2fffa08d-40ab-4e29-8e4a-0cda97b664be"),
                            HideFromStatistics = false,
                            Name = "The Mahact Gene-Sorcerers"
                        },
                        new
                        {
                            Identifier = new Guid("26251032-94c9-4331-8ccf-697755213fad"),
                            HideFromStatistics = false,
                            Name = "The Naaz-Rokha Alliance"
                        },
                        new
                        {
                            Identifier = new Guid("4210c2bb-f773-4721-907b-1c3e1cd11357"),
                            HideFromStatistics = false,
                            Name = "The Nomad"
                        },
                        new
                        {
                            Identifier = new Guid("c4e77f65-5a61-404f-8793-b672ccdb29a4"),
                            HideFromStatistics = false,
                            Name = "The Titans of UL"
                        },
                        new
                        {
                            Identifier = new Guid("91da5e70-a3db-4168-b18d-61ae7b899b48"),
                            HideFromStatistics = false,
                            Name = "The Vuil'Raith Cabal"
                        },
                        new
                        {
                            Identifier = new Guid("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
                            HideFromStatistics = false,
                            Name = "The Council Keleres (The Mentak Coalition)"
                        },
                        new
                        {
                            Identifier = new Guid("d819ecf0-3ccd-45d1-9f19-ba045d39fd65"),
                            HideFromStatistics = false,
                            Name = "The Council Keleres (The Xxcha Kingdoms)"
                        },
                        new
                        {
                            Identifier = new Guid("0747201a-f0ae-4c88-840f-00a3d6c618a0"),
                            HideFromStatistics = false,
                            Name = "The Council Keleres (The Argent Flight)"
                        },
                        new
                        {
                            Identifier = new Guid("609382d1-c969-4144-916a-ad4c13df1352"),
                            HideFromStatistics = true,
                            Name = "_Unknown_"
                        });
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Person", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DefaultColourIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HideFromStatistics")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifier");

                    b.HasIndex("DefaultColourIdentifier");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.PersonAchievement", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AchievementIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAccomplished")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PersonIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Identifier");

                    b.HasIndex("AchievementIdentifier");

                    b.HasIndex("PersonIdentifier");

                    b.ToTable("PersonAchievements");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Play", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Map")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PointGoal")
                        .HasColumnType("bigint");

                    b.Property<double>("RulesVersion")
                        .HasColumnType("float");

                    b.Property<DateTime>("UtcDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Identifier");

                    b.ToTable("Plays");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Player", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColourIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("DraftOrder")
                        .HasColumnType("bigint");

                    b.Property<bool>("Eliminated")
                        .HasColumnType("bit");

                    b.Property<Guid>("FactionIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Points")
                        .HasColumnType("bigint");

                    b.Property<bool>("Winner")
                        .HasColumnType("bit");

                    b.HasKey("Identifier");

                    b.HasIndex("ColourIdentifier");

                    b.HasIndex("FactionIdentifier");

                    b.HasIndex("PersonIdentifier");

                    b.HasIndex("PlayIdentifier");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Variant", b =>
                {
                    b.Property<Guid>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identifier");

                    b.ToTable("Variants");

                    b.HasData(
                        new
                        {
                            Identifier = new Guid("4082a883-4c5f-44c7-abf6-0d4823698cb0"),
                            Name = "Standard"
                        },
                        new
                        {
                            Identifier = new Guid("f018f38e-85fd-4c5b-9036-d9c071aae506"),
                            Name = "Competitive"
                        },
                        new
                        {
                            Identifier = new Guid("c0db28a6-29e1-4463-a187-dd49d5416c0a"),
                            Name = "Milty"
                        },
                        new
                        {
                            Identifier = new Guid("b6125086-d6ae-4f4a-b981-5f4e63b15cc0"),
                            Name = "Alliance"
                        },
                        new
                        {
                            Identifier = new Guid("5b8c8301-b5e9-4c72-b6fa-b07cb30005be"),
                            Name = "Pax Magnifica"
                        });
                });

            modelBuilder.Entity("PlayVariant", b =>
                {
                    b.Property<Guid>("PlaysIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VariantsIdentifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlaysIdentifier", "VariantsIdentifier");

                    b.HasIndex("VariantsIdentifier");

                    b.ToTable("PlayVariant");
                });

            modelBuilder.Entity("ExpansionPlay", b =>
                {
                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Expansion", null)
                        .WithMany()
                        .HasForeignKey("ExpansionsIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Play", null)
                        .WithMany()
                        .HasForeignKey("PlaysIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Person", b =>
                {
                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Colour", "DefaultColour")
                        .WithMany()
                        .HasForeignKey("DefaultColourIdentifier");

                    b.Navigation("DefaultColour");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.PersonAchievement", b =>
                {
                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Achievement", "Achievement")
                        .WithMany("People")
                        .HasForeignKey("AchievementIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Person", "Person")
                        .WithMany("Achievements")
                        .HasForeignKey("PersonIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Player", b =>
                {
                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Colour", "Colour")
                        .WithMany()
                        .HasForeignKey("ColourIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Play", "Play")
                        .WithMany("Players")
                        .HasForeignKey("PlayIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colour");

                    b.Navigation("Faction");

                    b.Navigation("Person");

                    b.Navigation("Play");
                });

            modelBuilder.Entity("PlayVariant", b =>
                {
                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Play", null)
                        .WithMany()
                        .HasForeignKey("PlaysIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hesketh.MecatolArchives.DB.Models.Variant", null)
                        .WithMany()
                        .HasForeignKey("VariantsIdentifier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Achievement", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Person", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("Hesketh.MecatolArchives.DB.Models.Play", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
