using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hesketh.MecatolArchives.DB.Migrations.Mssql.Migrations
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
                    Hex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UtcDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RulesVersion = table.Column<double>(type: "float", nullable: false),
                    PointGoal = table.Column<long>(type: "bigint", nullable: false),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Expansions",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expansions", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Expansions_Plays_PlayIdentifier",
                        column: x => x.PlayIdentifier,
                        principalTable: "Plays",
                        principalColumn: "Identifier");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Points = table.Column<long>(type: "bigint", nullable: false),
                    Winner = table.Column<bool>(type: "bit", nullable: false),
                    Eliminated = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Variants_Plays_PlayIdentifier",
                        column: x => x.PlayIdentifier,
                        principalTable: "Plays",
                        principalColumn: "Identifier");
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Identifier", "Hex", "Name" },
                values: new object[,]
                {
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
                columns: new[] { "Identifier", "Name", "PlayIdentifier" },
                values: new object[,]
                {
                    { new Guid("0e886b80-9ef3-48c0-bfc5-8107ee183c1b"), "Omega Initiative II", null },
                    { new Guid("1eb732ba-74ac-4993-943e-cd6f3650d310"), "Codex III: Vigil", null },
                    { new Guid("21fbcaf7-ae17-4db7-851a-dc65eb3ba60f"), "Codex I: Ordinian", null },
                    { new Guid("2b7c9cd6-a7d8-40f1-843d-8f10c7c45fb3"), "Omega Initiative I", null },
                    { new Guid("9420502f-4ef0-4887-add4-3d8a4941016a"), "Codex II: Affinity", null },
                    { new Guid("fb08d4e6-5ac1-4cbf-8eb9-166f6c5e41f0"), "Prophecy of Kings", null }
                });

            migrationBuilder.InsertData(
                table: "Factions",
                columns: new[] { "Identifier", "Name" },
                values: new object[,]
                {
                    { new Guid("0747201a-f0ae-4c88-840f-00a3d6c618a0"), "The Council Keleres (The Argent Flight)" },
                    { new Guid("0cc14756-19f7-42ef-acd0-156fab6bcd2b"), "The Universities of Jol-Nar" },
                    { new Guid("11ee6931-58d5-4808-b2c5-e3d4b7bf4343"), "The Arborec" },
                    { new Guid("1a5777dc-4106-46ec-8168-596c7c9edd36"), "Sardakk N'orr" },
                    { new Guid("2002e0b3-603f-4b66-8268-2ca8ab2bfce4"), "The Naalu Collective" },
                    { new Guid("26251032-94c9-4331-8ccf-697755213fad"), "The Naaz-Rokha Alliance" },
                    { new Guid("279eefc5-4bd3-41be-93d0-b49bd6e9b7d6"), "The Xxcha Kingdom" },
                    { new Guid("2c637584-cdbb-485e-8c3f-bc713eebaa03"), "The Yin Brotherhood" },
                    { new Guid("2e017142-848a-4203-a109-1fa905a5db04"), "The Ghosts of Creuss" },
                    { new Guid("2fffa08d-40ab-4e29-8e4a-0cda97b664be"), "The Mahact Gene-Sorcerers" },
                    { new Guid("4210c2bb-f773-4721-907b-1c3e1cd11357"), "The Nomad" },
                    { new Guid("4df36a67-6b3d-4966-ae0c-6ebdb6d0a97d"), "The L1Z1X Mindnet" },
                    { new Guid("51ee1c82-279b-444c-a6aa-a8cd475612fd"), "The Council Keleres (The Mentak Coalition)" },
                    { new Guid("5265b1f2-4422-4d0b-8711-582330d9afe4"), "The Yssaril Tribes" },
                    { new Guid("609382d1-c969-4144-916a-ad4c13df1352"), "_Unknown_" },
                    { new Guid("79c4217c-dc20-46fe-9e0b-44e852dfc64b"), "The Nekro Virus" },
                    { new Guid("91da5e70-a3db-4168-b18d-61ae7b899b48"), "The Vuil'Raith Cabal" },
                    { new Guid("9b8cf62c-9c94-49aa-b55b-11a8f4f9a7c9"), "The Winnu" },
                    { new Guid("a386b3e8-683b-4e7e-9fba-3361bdbbeef1"), "The Federation of Sol" },
                    { new Guid("b01aaa66-1888-4926-803e-95a864057219"), "The Clan of Saar" },
                    { new Guid("be81d0fd-0ba8-4d55-ac65-4eb66d49028a"), "The Argent Flight" },
                    { new Guid("c4e77f65-5a61-404f-8793-b672ccdb29a4"), "The Titans of UL" },
                    { new Guid("c765da52-404b-4073-8c0c-003537169b4c"), "The Mentak Coalition" },
                    { new Guid("c9a5311a-4798-44c5-8b97-3a5bc4eaa01a"), "The Emirates of Hacan" },
                    { new Guid("d819ecf0-3ccd-45d1-9f19-ba045d39fd65"), "The Council Keleres (The Xxcha Kingdoms)" },
                    { new Guid("e4d8ad5c-cf62-4001-9b81-f2a31bd87b0d"), "The Barony of Letnev" },
                    { new Guid("f39815c4-b651-4ed4-86e0-5b4f5f6128ef"), "The Empyrean" },
                    { new Guid("fcae96dd-793a-4393-9f5f-f378ff167b12"), "The Embers of Muaat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expansions_PlayIdentifier",
                table: "Expansions",
                column: "PlayIdentifier");

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
                name: "IX_Variants_PlayIdentifier",
                table: "Variants",
                column: "PlayIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expansions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Plays");
        }
    }
}
