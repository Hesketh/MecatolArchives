using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MecatolArchives.DataAccess.Migrations.Mssql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hex = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Expansions",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expansions", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RulesVersion = table.Column<double>(type: "float", nullable: false),
                    PointGoal = table.Column<long>(type: "bigint", nullable: false),
                    Map = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DefaultColourIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_People_Colours_DefaultColourIdentifier",
                        column: x => x.DefaultColourIdentifier,
                        principalTable: "Colours",
                        principalColumn: "Identifier");
                });

            migrationBuilder.CreateTable(
                name: "FactionVariants",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FactionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionVariants", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_FactionVariants_Factions_FactionIdentifier",
                        column: x => x.FactionIdentifier,
                        principalTable: "Factions",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentPlay",
                columns: table => new
                {
                    ExpansionsIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaysIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPlay", x => new { x.ExpansionsIdentifier, x.PlaysIdentifier });
                    table.ForeignKey(
                        name: "FK_ContentPlay_Expansions_ExpansionsIdentifier",
                        column: x => x.ExpansionsIdentifier,
                        principalTable: "Expansions",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentPlay_Plays_PlaysIdentifier",
                        column: x => x.PlaysIdentifier,
                        principalTable: "Plays",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayVariant",
                columns: table => new
                {
                    PlaysIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariantsIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayVariant", x => new { x.PlaysIdentifier, x.VariantsIdentifier });
                    table.ForeignKey(
                        name: "FK_PlayVariant_Plays_PlaysIdentifier",
                        column: x => x.PlaysIdentifier,
                        principalTable: "Plays",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayVariant_Variants_VariantsIdentifier",
                        column: x => x.VariantsIdentifier,
                        principalTable: "Variants",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Points = table.Column<long>(type: "bigint", nullable: false),
                    Winner = table.Column<bool>(type: "bit", nullable: false),
                    Eliminated = table.Column<bool>(type: "bit", nullable: false),
                    DraftOrder = table.Column<long>(type: "bigint", nullable: false),
                    PersonIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FactionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColourIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Players_Colours_ColourIdentifier",
                        column: x => x.ColourIdentifier,
                        principalTable: "Colours",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Factions_FactionIdentifier",
                        column: x => x.FactionIdentifier,
                        principalTable: "Factions",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_People_PersonIdentifier",
                        column: x => x.PersonIdentifier,
                        principalTable: "People",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Plays_PlayIdentifier",
                        column: x => x.PlayIdentifier,
                        principalTable: "Plays",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Identifier", "Hex", "Name" },
                values: new object[,]
                {
                    { new Guid("08ddef19-bd82-4eda-b245-5e84e8da38d9"), "#FFFFFF", "White" },
                    { new Guid("43c078a5-0561-40f0-8adc-92afa32eaeb0"), "#FFA500", "Orange" },
                    { new Guid("51b6cc96-0e35-48f9-8665-b50bbe3fdb44"), "#FFFF00", "Yellow" },
                    { new Guid("53bf36a1-669c-41ed-9ced-4fa94ba038ee"), "#FF0000", "Red" },
                    { new Guid("564f166e-33cb-45cc-bca6-1b2d16b8bf60"), "#000000", "Black" },
                    { new Guid("a9c3b568-d781-452d-91ae-44b0cc8e7020"), "#800080", "Purple" },
                    { new Guid("b5616b41-2821-4a27-85dc-fa81b899e578"), "#0000FF", "Blue" },
                    { new Guid("cbdfdda9-13bf-4a45-be5d-0882f6dcbad8"), "", "_Unknown_" },
                    { new Guid("daceda53-e450-4fce-82d4-ef1cdd312e38"), "#FF00FF", "Magenta" },
                    { new Guid("e8ca7b27-00cd-4a2a-bc7f-17105e690e2d"), "#008000", "Green" }
                });

            migrationBuilder.InsertData(
                table: "Expansions",
                columns: new[] { "Identifier", "Name" },
                values: new object[,]
                {
                    { new Guid("1eb732ba-74ac-4993-943e-cd6f3650d310"), "Codex III: Vigil" },
                    { new Guid("21fbcaf7-ae17-4db7-851a-dc65eb3ba60f"), "Codex I: Ordinian" },
                    { new Guid("5615f96a-cce5-41a6-90d8-91aed8cd1645"), "Thunder's Edge" },
                    { new Guid("69996b68-7083-43db-ba63-efffb80df833"), "Absol's Agendas & Relics" },
                    { new Guid("7606e091-1f8d-4e58-8d48-8c93dc65b9ad"), "Discordant Stars" },
                    { new Guid("9420502f-4ef0-4887-add4-3d8a4941016a"), "Codex II: Affinity" },
                    { new Guid("dfaeec44-34c8-4bad-94c2-0f69b9e27f87"), "Uncharted Space" },
                    { new Guid("f77349c8-dc28-424a-b0bc-16057f15d18e"), "Codex IV: Liberation" },
                    { new Guid("fb08d4e6-5ac1-4cbf-8eb9-166f6c5e41f0"), "Prophecy of Kings" }
                });

            migrationBuilder.InsertData(
                table: "Factions",
                columns: new[] { "Identifier", "Active", "Name", "Url" },
                values: new object[,]
                {
                    { new Guid("081a94e6-f713-4536-4467-233445566778"), true, "The Free Systems of Compacts", "https://twilight-imperium.fandom.com/wiki/Free_Systems_Compact_(UNOFFICIAL)" },
                    { new Guid("0a1a4536-f709-4506-4a47-839405162738"), true, "The Vaylerian Scourge", "https://twilight-imperium.fandom.com/wiki/The_Vaylerian_Scourge_(UNOFFICIAL)" },
                    { new Guid("0cc14756-19f7-42ef-acd0-156fab6bcd2b"), true, "The Universities of Jol-Nar", "https://twilight-imperium.fandom.com/wiki/The_Universities_of_Jol-Nar" },
                    { new Guid("11ee6931-58d5-4808-b2c5-e3d4b7bf4343"), true, "The Arborec", "https://twilight-imperium.fandom.com/wiki/The_Arborec" },
                    { new Guid("192ba5f7-081a-4637-5568-344556667889"), true, "The Ghemina Raiders", "https://twilight-imperium.fandom.com/wiki/Ghemina_Raiders_(UNOFFICIAL)" },
                    { new Guid("1a5777dc-4106-46ec-8168-596c7c9edd36"), true, "Sardakk N'orr", "https://twilight-imperium.fandom.com/wiki/Sardakk_N%27orr" },
                    { new Guid("1b2b5647-0a1a-4607-5b58-940516273849"), true, "The Veldyr Sovereignty", "https://twilight-imperium.fandom.com/wiki/The_Veldyr_Sovereignty_(UNOFFICIAL)" },
                    { new Guid("2002e0b3-603f-4b66-8268-2ca8ab2bfce4"), true, "The Naalu Collective", "https://twilight-imperium.fandom.com/wiki/The_Naalu_Collective" },
                    { new Guid("26251032-94c9-4331-8ccf-697755213fad"), true, "The Naaz-Rokha Alliance", "https://twilight-imperium.fandom.com/wiki/The_Naaz-Rokha_Alliance" },
                    { new Guid("279eefc5-4bd3-41be-93d0-b49bd6e9b7d6"), true, "The Xxcha Kingdom", "https://twilight-imperium.fandom.com/wiki/The_Xxcha_Kingdom" },
                    { new Guid("2a3cb608-192b-4738-6669-45566778899a"), true, "The Augurs of Ilyxum", "https://twilight-imperium.fandom.com/wiki/Augurs_of_Ilyxum_(UNOFFICIAL)" },
                    { new Guid("2c3c6758-1b2b-4708-6c69-a4051627384a"), true, "The Zelian Purifier", "https://twilight-imperium.fandom.com/wiki/Zelian_Purifier_(UNOFFICIAL)" },
                    { new Guid("2c637584-cdbb-485e-8c3f-bc713eebaa03"), true, "The Yin Brotherhood", "https://twilight-imperium.fandom.com/wiki/The_Yin_Brotherhood" },
                    { new Guid("2e017142-848a-4203-a109-1fa905a5db04"), true, "The Ghosts of Creuss", "https://twilight-imperium.fandom.com/wiki/The_Ghosts_of_Creuss" },
                    { new Guid("2fffa08d-40ab-4e29-8e4a-0cda97b664be"), true, "The Mahact Gene-Sorcerers", "https://twilight-imperium.fandom.com/wiki/The_Mahact_Gene-Sorcerers" },
                    { new Guid("3b4dc719-2a3c-4839-777a-566778899a0b"), true, "The Kollecc Society", "https://twilight-imperium.fandom.com/wiki/Kollecc_Society_(UNOFFICIAL)" },
                    { new Guid("3d4d7869-2c3c-4809-7d7a-b5162738495b"), true, "The Bentor Conglomerate", "https://twilight-imperium.fandom.com/wiki/Bentor_Conglomerate_(UNOFFICIAL)" },
                    { new Guid("4210c2bb-f773-4721-907b-1c3e1cd11357"), true, "The Nomad", "https://twilight-imperium.fandom.com/wiki/The_Nomad" },
                    { new Guid("4c5ed82a-3b4d-493a-888b-6778899a0b1c"), true, "The Kortali Tribunal", "https://twilight-imperium.fandom.com/wiki/Kortali_Tribunal_(UNOFFICIAL)" },
                    { new Guid("4df36a67-6b3d-4966-ae0c-6ebdb6d0a97d"), true, "The L1Z1X Mindnet", "https://twilight-imperium.fandom.com/wiki/The_L1Z1X_Mindnet" },
                    { new Guid("4e5e897a-3d4d-490a-8e8b-c62738495c6c"), true, "The Cheiran Hordes", "https://twilight-imperium.fandom.com/wiki/Cheiran_Hordes_(UNOFFICIAL)" },
                    { new Guid("51ee1c82-279b-444c-a6aa-a8cd475612fd"), true, "The Council Keleres", "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres" },
                    { new Guid("5265b1f2-4422-4d0b-8711-582330d9afe4"), true, "The Yssaril Tribes", "https://twilight-imperium.fandom.com/wiki/The_Yssaril_Tribes" },
                    { new Guid("5d6fe93b-4c5e-4a3b-999c-78899a0b1c2d"), true, "The Li-Zho Dynasty", "https://twilight-imperium.fandom.com/wiki/Li-Zho_Dynasty_(UNOFFICIAL)" },
                    { new Guid("5f6f9a8b-4e5e-4a0b-9f9c-d738495c6d7d"), true, "The Edyn Mandate", "https://twilight-imperium.fandom.com/wiki/Edyn_Mandate_(UNOFFICIAL)" },
                    { new Guid("6070ab9c-5f6f-4b1c-a0ad-e8495c6d7e8e"), true, "The Ghoti Wayfarers", "https://twilight-imperium.fandom.com/wiki/Ghoti_Wayfarers_(UNOFFICIAL)" },
                    { new Guid("609382d1-c969-4144-916a-ad4c13df1352"), true, "_Unknown_", null },
                    { new Guid("6e70fa4c-5d6f-4b4c-a0ad-899a0b1c2d3e"), true, "The L'tokk Khrask", "https://twilight-imperium.fandom.com/wiki/L%27tokk_Khrask_(UNOFFICIAL)" },
                    { new Guid("7181bcad-6070-4c2d-b1be-f95c6d7e8f9f"), true, "The GLEdge Union", "https://twilight-imperium.fandom.com/wiki/Gledge_Union_(UNOFFICIAL)" },
                    { new Guid("79c4217c-dc20-46fe-9e0b-44e852dfc64b"), true, "The Nekro Virus", "https://twilight-imperium.fandom.com/wiki/The_Nekro_Virus" },
                    { new Guid("7f81ab5d-6e70-4c5d-b1be-9a0b1c2d3e4f"), true, "The Mirveda Protectorate", "https://twilight-imperium.fandom.com/wiki/Mirveda_Protectorate_(UNOFFICIAL)" },
                    { new Guid("8092bc6e-7f81-4d6e-c2cf-0b1c2d3e4f50"), true, "The Glimmer of Mortheus", "https://twilight-imperium.fandom.com/wiki/Glimmer_of_Mortheus_(UNOFFICIAL)" },
                    { new Guid("8292cdbe-7181-4d3e-c2cf-0a6d7e8f9010"), true, "The Berserkers of Kjalengard", "https://twilight-imperium.fandom.com/wiki/Berserkers_of_Kjalengard_(UNOFFICIAL)" },
                    { new Guid("8d975e74-efc4-4297-a7c0-85c2bbe5d55d"), true, "The Firmament / The Obsidian", "https://twilight-imperium.fandom.com/wiki/The_Firmament_/_The_Obsidian" },
                    { new Guid("91a3cd7f-8092-4e7f-d3d0-1c2d3e4f5061"), true, "The Myko-Mentori", "https://twilight-imperium.fandom.com/wiki/Myko-Mentori_(UNOFFICIAL)" },
                    { new Guid("91bd2e7f-80ab-4e2f-df30-5c6d7e8f9011"), true, "Last Bastion", "https://twilight-imperium.fandom.com/wiki/Last_Bastion" },
                    { new Guid("91da5e70-a3db-4168-b18d-61ae7b899b48"), true, "The Vuil'Raith Cabal", "https://twilight-imperium.fandom.com/wiki/The_Vuil%27Raith_Cabal" },
                    { new Guid("93a3decf-8292-4e4f-d3e0-1b7e8f901121"), true, "The Monks of Kolume", "https://twilight-imperium.fandom.com/wiki/Monks_of_Kolume_(UNOFFICIAL)" },
                    { new Guid("981e095a-55e0-4f35-8105-614eaa9cda43"), true, "The Deepwrought Scholarate", "https://twilight-imperium.fandom.com/wiki/The_Deepwrought_Scholarate" },
                    { new Guid("9b8cf62c-9c94-49aa-b55b-11a8f4f9a7c9"), true, "The Winnu", "https://twilight-imperium.fandom.com/wiki/The_Winnu" },
                    { new Guid("a2b4de80-91a3-4f80-e4e1-2d3e4f506172"), true, "The Nivyn Star Kings", "https://twilight-imperium.fandom.com/wiki/Nivyn_Star_Kings_(UNOFFICIAL)" },
                    { new Guid("a2ce3f80-91bc-4f30-ef41-6d7e8f901122"), true, "The Ral Nel Consortium", "https://twilight-imperium.fandom.com/wiki/The_Ral_Nel_Consortium" },
                    { new Guid("a386b3e8-683b-4e7e-9fba-3361bdbbeef1"), true, "The Federation of Sol", "https://twilight-imperium.fandom.com/wiki/The_Federation_of_Sol" },
                    { new Guid("a4b4ef00-93a3-4f50-e4f1-2c8f90112132"), true, "The Kyro Sodality", "https://twilight-imperium.fandom.com/wiki/Kyro_Sodality_(UNOFFICIAL)" },
                    { new Guid("b01aaa66-1888-4926-803e-95a864057219"), true, "The Clan of Saar", "https://twilight-imperium.fandom.com/wiki/The_Clan_of_Saar" },
                    { new Guid("b3c5ef91-a2b4-4091-f5f2-3e4f50617283"), true, "The Olradin League", "https://twilight-imperium.fandom.com/wiki/Olradin_League_(UNOFFICIAL)" },
                    { new Guid("b3df4091-a2cd-4031-f052-7e8f90112233"), true, "The Shipwrights of Axis", "https://twilight-imperium.fandom.com/wiki/Shipwrights_of_Axis_(UNOFFICIAL)" },
                    { new Guid("b5c50111-a4b4-5051-f502-3d9011213243"), true, "The Lanefir Remnants", "https://twilight-imperium.fandom.com/wiki/Lanefir_Remnants_(UNOFFICIAL)" },
                    { new Guid("be81d0fd-0ba8-4d55-ac65-4eb66d49028a"), true, "The Argent Flight", "https://twilight-imperium.fandom.com/wiki/The_Argent_Flight" },
                    { new Guid("c4d60102-b3c5-4102-0603-4f5061728394"), true, "The Zealots of Rhodun", "https://twilight-imperium.fandom.com/wiki/Zealots_of_Rhodun_(UNOFFICIAL)" },
                    { new Guid("c4e050a2-b3de-4132-0063-8f9011223344"), true, "The Celdauri Trade Confederation", "https://twilight-imperium.fandom.com/wiki/Celdauri_Trade_Confederation_(UNOFFICIAL)" },
                    { new Guid("c4e77f65-5a61-404f-8793-b672ccdb29a4"), true, "The Titans of UL", "https://twilight-imperium.fandom.com/wiki/The_Titans_of_Ul" },
                    { new Guid("c6d61222-b5c5-5162-0603-4e1121324354"), true, "The Nokar Sellships", "https://twilight-imperium.fandom.com/wiki/Nokar_Sellships_(UNOFFICIAL)" },
                    { new Guid("c765da52-404b-4073-8c0c-003537169b4c"), true, "The Mentak Coalition", "https://twilight-imperium.fandom.com/wiki/The_Mentak_Coalition" },
                    { new Guid("c9a5311a-4798-44c5-8b97-3a5bc4eaa01a"), true, "The Emirates of Hacan", "https://twilight-imperium.fandom.com/wiki/The_Emirates_of_Hacan" },
                    { new Guid("d5e71213-c4d6-4203-1714-506172839405"), true, "Roh'Dhna Mechatronics", "https://twilight-imperium.fandom.com/wiki/Roh%27Dhna_Mechatronics_(UNOFFICIAL)" },
                    { new Guid("d5f161b3-c4e0-4233-1164-901122334455"), true, "The Savages of Cymiae", "https://twilight-imperium.fandom.com/wiki/Savages_of_Cymiae_(UNOFFICIAL)" },
                    { new Guid("e4d8ad5c-cf62-4001-9b81-f2a31bd87b0d"), true, "The Barony of Letnev", "https://twilight-imperium.fandom.com/wiki/The_Barony_of_Letnev" },
                    { new Guid("e60272c4-d5f1-4334-2265-011223344556"), true, "The Dih-Mohn Flotilla", "https://twilight-imperium.fandom.com/wiki/Dih-Mohn_Flotilla_(UNOFFICIAL)" },
                    { new Guid("e6f82324-d5e7-4304-2825-617283940516"), true, "The Tnelis Syndicate", "https://twilight-imperium.fandom.com/wiki/The_Tnelis_Syndicate_(UNOFFICIAL)" },
                    { new Guid("f39815c4-b651-4ed4-86e0-5b4f5f6128ef"), true, "The Empyrean", "https://twilight-imperium.fandom.com/wiki/The_Empyrean" },
                    { new Guid("f7093425-e6f8-4405-3936-728394051627"), true, "The Vaden Banking Clans", "https://twilight-imperium.fandom.com/wiki/The_Vaden_Banking_Clans_(UNOFFICIAL)" },
                    { new Guid("f71383d5-e602-4435-3366-122334455667"), true, "The Florzen Profiteers", "https://twilight-imperium.fandom.com/wiki/Florzen_Profiteers_(UNOFFICIAL)" },
                    { new Guid("fcae96dd-793a-4393-9f5f-f378ff167b12"), true, "The Embers of Muaat", "https://twilight-imperium.fandom.com/wiki/The_Embers_of_Muaat" },
                    { new Guid("fcbf11ee-afe1-44aa-abd0-497d0baa1ee8"), true, "The Crimson Rebellion", "https://twilight-imperium.fandom.com/wiki/The_Crimson_Rebellion" }
                });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "Identifier", "Name" },
                values: new object[,]
                {
                    { new Guid("2367d7be-98ca-4f64-85f1-efb433f9c582"), "Rule - Public Objectives Visible" },
                    { new Guid("27267f67-8243-4448-b71f-8e6c366e2fc8"), "Setup - Cooperative" },
                    { new Guid("3e2f6313-8387-4010-a5f0-abb6adc5db61"), "Rule - No Support Swaps" },
                    { new Guid("4c0e5036-8a98-4729-ade2-48fded663369"), "Mode - Pax Magnifica" },
                    { new Guid("7f1c0478-b6c1-4ca6-bc79-78912315e947"), "Setup - Competitive" },
                    { new Guid("84ee1c98-9b0c-467c-9c6d-b7cdd2e4a9c9"), "Mode - Alliance" },
                    { new Guid("8e0c451b-5137-4dee-b212-7077e8487c23"), "Rule - 4/4/4" },
                    { new Guid("b28554aa-f0a4-4fd0-adc1-37480b2be570"), "Setup - Prebuilt" },
                    { new Guid("eaed8375-d283-49ee-9224-93460c91be31"), "Setup - Milty" }
                });

            migrationBuilder.InsertData(
                table: "FactionVariants",
                columns: new[] { "Identifier", "FactionIdentifier", "Name" },
                values: new object[,]
                {
                    { new Guid("3852bc1c-57d8-44fc-932f-9216c8eebdba"), new Guid("51ee1c82-279b-444c-a6aa-a8cd475612fd"), "The Mentak Coalition" },
                    { new Guid("9c01e321-475d-447e-9d5a-e8d6b11ea828"), new Guid("51ee1c82-279b-444c-a6aa-a8cd475612fd"), "The Xxcha Kingdom" },
                    { new Guid("f487ab41-107f-4a08-8a3c-5f8eade06e2c"), new Guid("51ee1c82-279b-444c-a6aa-a8cd475612fd"), "The Argent Flight" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentPlay_PlaysIdentifier",
                table: "ContentPlay",
                column: "PlaysIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_FactionVariants_FactionIdentifier",
                table: "FactionVariants",
                column: "FactionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_People_DefaultColourIdentifier",
                table: "People",
                column: "DefaultColourIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ColourIdentifier",
                table: "Players",
                column: "ColourIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Players_FactionIdentifier",
                table: "Players",
                column: "FactionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PersonIdentifier",
                table: "Players",
                column: "PersonIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayIdentifier",
                table: "Players",
                column: "PlayIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PlayVariant_VariantsIdentifier",
                table: "PlayVariant",
                column: "VariantsIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentPlay");

            migrationBuilder.DropTable(
                name: "FactionVariants");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayVariant");

            migrationBuilder.DropTable(
                name: "Expansions");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Colours");
        }
    }
}
