using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hesketh.MecatolArchives.DB.Migrations
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
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Hex = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    UtcDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RulesVersion = table.Column<double>(type: "REAL", nullable: false),
                    PointGoal = table.Column<uint>(type: "INTEGER", nullable: false),
                    Map = table.Column<string>(type: "TEXT", nullable: true),
                    VariantIdentifier = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Plays_Variants_VariantIdentifier",
                        column: x => x.VariantIdentifier,
                        principalTable: "Variants",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expansions",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PlayIdentifier = table.Column<Guid>(type: "TEXT", nullable: true)
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
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    Points = table.Column<uint>(type: "INTEGER", nullable: false),
                    Winner = table.Column<bool>(type: "INTEGER", nullable: false),
                    Eliminated = table.Column<bool>(type: "INTEGER", nullable: false),
                    PersonIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    FactionIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    ColourIdentifier = table.Column<Guid>(type: "TEXT", nullable: false)
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
                name: "IX_Plays_VariantIdentifier",
                table: "Plays",
                column: "VariantIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expansions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.DropTable(
                name: "Variants");
        }
    }
}
