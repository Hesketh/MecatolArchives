using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hesketh.MecatolArchives.DB.Migrations.Mssql.Migrations
{
    /// <inheritdoc />
    public partial class Achievements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "PlayerAchievements",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AchievementIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAccomplished = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Identifier", "Condition", "Name" },
                values: new object[,]
                {
                    { new Guid("0e928bf1-9527-42ea-9f2f-c3844e5af89f"), "Trade someone their own promissory note", "I Made This" },
                    { new Guid("164130f9-04b2-4565-83e2-a6e447eeac1d"), "Score your 10th victory point from Become a Martyr", "It was Always Going to Be Me" },
                    { new Guid("199cac45-fb56-4a1d-b70e-b15e92e3295b"), "Have at least 1 promissory note that belongs to each other player in a 6-8 player game", "ROYGBIV" },
                    { new Guid("296beeb1-3274-4bd3-aca4-0286aa56ea60"), "Lose 10 or more units at once to the Van Hague, Nova Seed, Armageddon Relay, Stellar Converter, Ixthian Artifact, or Dimensional Anchor", "Sincerely, Deleted" },
                    { new Guid("346cd853-985b-43fd-aef9-84f3ab191a84"), "Have an Alliance promissory that belongs to each other player in a 6-8 player game", "Rainbow Deluxe Ultra" },
                    { new Guid("39671dae-9c18-48df-a553-97da3c274825"), "Lose 35 resources worth of units in one combat", "Reduce, Reuse, Regret" },
                    { new Guid("3b4a3002-bde6-4987-9286-0657c9a3a855"), "As the Mahact, have at least 5 command tokens on your sheet that belong to other players", "Someone Call and Ambulance" },
                    { new Guid("5b5904b4-43f8-4a5e-8135-bd16b940c3c5"), "Participate in a game that ends with Imperium Rex", "This Doesn't Seem Physically Possible" },
                    { new Guid("6925136c-5ab4-46cd-a056-10ae4954bf05"), "Research Dacxive Animators, Magen Defense Grid, Infantry II, X-89 Bacterial Weapon, Psychoarchaeology and no other technologies", "We Trained Him Wrong, As a Joke" },
                    { new Guid("7d4629c6-f7e9-447e-a782-af89ed6ce9fd"), "Win a game without initiating combat against or exchanging possessions with another player", "Solitaire" },
                    { new Guid("8e9165ba-6f5e-4690-971f-ec62120f50a2"), "Completely wipe out a planet that had at least 3 infantry using the Plague action card", "49/59" },
                    { new Guid("92ea4713-8c2d-43a8-8be1-0b24a4d1dc72"), "Win a game with 40 or more unspent trade goods", "Dragon Hoard" },
                    { new Guid("94a53e84-ad95-47c0-92c1-a69a0c3c60d0"), "Refresh no toehr player's commodities when resolving the primary ability of the Trade strategy card", "X Minus This" },
                    { new Guid("9b6702fc-e324-477a-802d-d356641f22e2"), "As Jol-Nar, have at least 12 technologies and replace them with 12 different technologies", "Rinfinity" },
                    { new Guid("ac0da407-c6ef-44e5-ac4d-02c17fd0b11c"), "Win a 1v1 Infantry-only combat that lasted longer than 8 rounds", "Forever War" },
                    { new Guid("b2427957-809f-48df-82cd-a3e68ec6acd9"), "Achieve a move value of 9 on a single ship", "Interdimensional Highway" },
                    { new Guid("bc8e2ebc-a3a6-4311-932e-f99f5093ef06"), "Be on the losing side of an agenda in which at least 4 riders were contributed to the losing side", "Four Horsemen, or Not a Very Good Psychic" },
                    { new Guid("bca4b731-ed05-4a8d-a999-6d2691bd2910"), "Research every technology of one colour", "It's Probably Blue" },
                    { new Guid("bd1cf513-c6ef-44e5-ac4d-02c17fd0b11c"), "Score 6 VP in one game round", "Not a Threat" },
                    { new Guid("bdc26e9a-d83d-43f8-8bfd-31828e9341cf"), "As a non-Creuss player, fire a PDS shot through the Hil Colish into another system", "That's Illegal" },
                    { new Guid("d36b22df-ec6d-462c-bbad-5e4c1de7c31e"), "Lose 10 or more units at once to the Van Hague as the Yin Brotherhood", "OSHA Violation" },
                    { new Guid("de70f3cb-055b-4e00-adad-a13a3fd389d3"), "Score at least 5 secret objectives", "Not-Very-Secret Objective" },
                    { new Guid("f695d3ad-c45f-4ca1-a6b7-24eca4fc3f2c"), "Win a game without researching technology", "Mano-a-Mano" },
                    { new Guid("fa69694d-1f7f-4e56-8a72-6dc6c1c37039"), "Control 3 other players' home system at the same time", "This Hurts You" },
                    { new Guid("ff07a297-5138-4833-bf5f-0d05c5b03714"), "Build all of your plastic units", "Materiel World" }
                });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "Identifier", "Name" },
                values: new object[,]
                {
                    { new Guid("4082a883-4c5f-44c7-abf6-0d4823698cb0"), "Standard" },
                    { new Guid("5b8c8301-b5e9-4c72-b6fa-b07cb30005be"), "Pax Magnifica" },
                    { new Guid("b6125086-d6ae-4f4a-b981-5f4e63b15cc0"), "Alliance" },
                    { new Guid("c0db28a6-29e1-4463-a187-dd49d5416c0a"), "Milty" },
                    { new Guid("f018f38e-85fd-4c5b-9036-d9c071aae506"), "Competitive" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerAchievements");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Identifier",
                keyValue: new Guid("4082a883-4c5f-44c7-abf6-0d4823698cb0"));

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Identifier",
                keyValue: new Guid("5b8c8301-b5e9-4c72-b6fa-b07cb30005be"));

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Identifier",
                keyValue: new Guid("b6125086-d6ae-4f4a-b981-5f4e63b15cc0"));

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Identifier",
                keyValue: new Guid("c0db28a6-29e1-4463-a187-dd49d5416c0a"));

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Identifier",
                keyValue: new Guid("f018f38e-85fd-4c5b-9036-d9c071aae506"));
        }
    }
}
