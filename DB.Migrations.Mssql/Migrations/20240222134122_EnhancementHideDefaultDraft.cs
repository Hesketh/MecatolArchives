using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hesketh.MecatolArchives.DB.Migrations.Mssql.Migrations
{
    /// <inheritdoc />
    public partial class EnhancementHideDefaultDraft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DraftOrder",
                table: "Players",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "DefaultColourIdentifier",
                table: "People",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HideFromStatistics",
                table: "People",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HideFromStatistics",
                table: "Factions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Factions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("0747201a-f0ae-4c88-840f-00a3d6c618a0"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("0cc14756-19f7-42ef-acd0-156fab6bcd2b"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("11ee6931-58d5-4808-b2c5-e3d4b7bf4343"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("1a5777dc-4106-46ec-8168-596c7c9edd36"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("2002e0b3-603f-4b66-8268-2ca8ab2bfce4"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("26251032-94c9-4331-8ccf-697755213fad"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("279eefc5-4bd3-41be-93d0-b49bd6e9b7d6"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("2c637584-cdbb-485e-8c3f-bc713eebaa03"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("2e017142-848a-4203-a109-1fa905a5db04"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("2fffa08d-40ab-4e29-8e4a-0cda97b664be"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("4210c2bb-f773-4721-907b-1c3e1cd11357"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("4df36a67-6b3d-4966-ae0c-6ebdb6d0a97d"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("5265b1f2-4422-4d0b-8711-582330d9afe4"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("609382d1-c969-4144-916a-ad4c13df1352"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { true, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("79c4217c-dc20-46fe-9e0b-44e852dfc64b"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("91da5e70-a3db-4168-b18d-61ae7b899b48"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("9b8cf62c-9c94-49aa-b55b-11a8f4f9a7c9"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("a386b3e8-683b-4e7e-9fba-3361bdbbeef1"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("b01aaa66-1888-4926-803e-95a864057219"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("be81d0fd-0ba8-4d55-ac65-4eb66d49028a"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("c4e77f65-5a61-404f-8793-b672ccdb29a4"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("c765da52-404b-4073-8c0c-003537169b4c"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("c9a5311a-4798-44c5-8b97-3a5bc4eaa01a"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("d819ecf0-3ccd-45d1-9f19-ba045d39fd65"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("e4d8ad5c-cf62-4001-9b81-f2a31bd87b0d"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("f39815c4-b651-4ed4-86e0-5b4f5f6128ef"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("fcae96dd-793a-4393-9f5f-f378ff167b12"),
                columns: new[] { "HideFromStatistics", "Link" },
                values: new object[] { false, null });

            migrationBuilder.CreateIndex(
                name: "IX_People_DefaultColourIdentifier",
                table: "People",
                column: "DefaultColourIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Colours_DefaultColourIdentifier",
                table: "People",
                column: "DefaultColourIdentifier",
                principalTable: "Colours",
                principalColumn: "Identifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Colours_DefaultColourIdentifier",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DefaultColourIdentifier",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DraftOrder",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DefaultColourIdentifier",
                table: "People");

            migrationBuilder.DropColumn(
                name: "HideFromStatistics",
                table: "People");

            migrationBuilder.DropColumn(
                name: "HideFromStatistics",
                table: "Factions");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Factions");
        }
    }
}
