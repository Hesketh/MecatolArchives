using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hesketh.MecatolArchives.DB.Migrations.Mssql.Migrations
{
    /// <inheritdoc />
    public partial class RenameContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpansionPlay");

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

            migrationBuilder.CreateIndex(
                name: "IX_ContentPlay_PlaysIdentifier",
                table: "ContentPlay",
                column: "PlaysIdentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentPlay");

            migrationBuilder.CreateTable(
                name: "ExpansionPlay",
                columns: table => new
                {
                    ExpansionsIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaysIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_ExpansionPlay_PlaysIdentifier",
                table: "ExpansionPlay",
                column: "PlaysIdentifier");
        }
    }
}
