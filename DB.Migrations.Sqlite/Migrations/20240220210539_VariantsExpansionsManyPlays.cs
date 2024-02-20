using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hesketh.MecatolArchives.DB.Migrations.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class VariantsExpansionsManyPlays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expansions_Plays_PlayIdentifier",
                table: "Expansions");

            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Plays_PlayIdentifier",
                table: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_Variants_PlayIdentifier",
                table: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_Expansions_PlayIdentifier",
                table: "Expansions");

            migrationBuilder.DropColumn(
                name: "PlayIdentifier",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "PlayIdentifier",
                table: "Expansions");

            migrationBuilder.CreateTable(
                name: "ExpansionPlay",
                columns: table => new
                {
                    ExpansionsIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    PlaysIdentifier = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpansionPlay", x => new { x.ExpansionsIdentifier, x.PlaysIdentifier });
                    table.ForeignKey(
                        name: "FK_ExpansionPlay_Expansions_ExpansionsIdentifier",
                        column: x => x.ExpansionsIdentifier,
                        principalTable: "Expansions",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpansionPlay_Plays_PlaysIdentifier",
                        column: x => x.PlaysIdentifier,
                        principalTable: "Plays",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayVariant",
                columns: table => new
                {
                    PlaysIdentifier = table.Column<Guid>(type: "TEXT", nullable: false),
                    VariantsIdentifier = table.Column<Guid>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ExpansionPlay_PlaysIdentifier",
                table: "ExpansionPlay",
                column: "PlaysIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PlayVariant_VariantsIdentifier",
                table: "PlayVariant",
                column: "VariantsIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpansionPlay");

            migrationBuilder.DropTable(
                name: "PlayVariant");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayIdentifier",
                table: "Variants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlayIdentifier",
                table: "Expansions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("0e886b80-9ef3-48c0-bfc5-8107ee183c1b"),
                column: "PlayIdentifier",
                value: null);

            migrationBuilder.UpdateData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("1eb732ba-74ac-4993-943e-cd6f3650d310"),
                column: "PlayIdentifier",
                value: null);

            migrationBuilder.UpdateData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("21fbcaf7-ae17-4db7-851a-dc65eb3ba60f"),
                column: "PlayIdentifier",
                value: null);

            migrationBuilder.UpdateData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("2b7c9cd6-a7d8-40f1-843d-8f10c7c45fb3"),
                column: "PlayIdentifier",
                value: null);

            migrationBuilder.UpdateData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("9420502f-4ef0-4887-add4-3d8a4941016a"),
                column: "PlayIdentifier",
                value: null);

            migrationBuilder.UpdateData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("fb08d4e6-5ac1-4cbf-8eb9-166f6c5e41f0"),
                column: "PlayIdentifier",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Variants_PlayIdentifier",
                table: "Variants",
                column: "PlayIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Expansions_PlayIdentifier",
                table: "Expansions",
                column: "PlayIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Expansions_Plays_PlayIdentifier",
                table: "Expansions",
                column: "PlayIdentifier",
                principalTable: "Plays",
                principalColumn: "Identifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Plays_PlayIdentifier",
                table: "Variants",
                column: "PlayIdentifier",
                principalTable: "Plays",
                principalColumn: "Identifier");
        }
    }
}
