using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hesketh.MecatolArchives.DB.Migrations.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AchievementsPerPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerAchievements");

            migrationBuilder.CreateTable(
                name: "PersonAchievements",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    PersonIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    AchievementIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateAccomplished = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAchievements", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_PersonAchievements_Achievements_AchievementIdentifier",
                        column: x => x.AchievementIdentifier,
                        principalTable: "Achievements",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAchievements_People_PersonIdentifier",
                        column: x => x.PersonIdentifier,
                        principalTable: "People",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonAchievements_AchievementIdentifier",
                table: "PersonAchievements",
                column: "AchievementIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAchievements_PersonIdentifier",
                table: "PersonAchievements",
                column: "PersonIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAchievements");

            migrationBuilder.CreateTable(
                name: "PlayerAchievements",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    AchievementIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlayerIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateAccomplished = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAchievements", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_PlayerAchievements_Achievements_AchievementIdentifier",
                        column: x => x.AchievementIdentifier,
                        principalTable: "Achievements",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerAchievements_Players_PlayerIdentifier",
                        column: x => x.PlayerIdentifier,
                        principalTable: "Players",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAchievements_AchievementIdentifier",
                table: "PlayerAchievements",
                column: "AchievementIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAchievements_PlayerIdentifier",
                table: "PlayerAchievements",
                column: "PlayerIdentifier");
        }
    }
}
