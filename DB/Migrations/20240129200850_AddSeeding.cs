using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hesketh.MecatolArchives.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("0e886b80-9ef3-48c0-bfc5-8107ee183c1b"));

            migrationBuilder.DeleteData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("1eb732ba-74ac-4993-943e-cd6f3650d310"));

            migrationBuilder.DeleteData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("21fbcaf7-ae17-4db7-851a-dc65eb3ba60f"));

            migrationBuilder.DeleteData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("2b7c9cd6-a7d8-40f1-843d-8f10c7c45fb3"));

            migrationBuilder.DeleteData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("9420502f-4ef0-4887-add4-3d8a4941016a"));

            migrationBuilder.DeleteData(
                table: "Expansions",
                keyColumn: "Identifier",
                keyValue: new Guid("fb08d4e6-5ac1-4cbf-8eb9-166f6c5e41f0"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("0747201a-f0ae-4c88-840f-00a3d6c618a0"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("0cc14756-19f7-42ef-acd0-156fab6bcd2b"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("11ee6931-58d5-4808-b2c5-e3d4b7bf4343"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("1a5777dc-4106-46ec-8168-596c7c9edd36"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("2002e0b3-603f-4b66-8268-2ca8ab2bfce4"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("26251032-94c9-4331-8ccf-697755213fad"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("279eefc5-4bd3-41be-93d0-b49bd6e9b7d6"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("2c637584-cdbb-485e-8c3f-bc713eebaa03"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("2e017142-848a-4203-a109-1fa905a5db04"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("2fffa08d-40ab-4e29-8e4a-0cda97b664be"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("4210c2bb-f773-4721-907b-1c3e1cd11357"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("4df36a67-6b3d-4966-ae0c-6ebdb6d0a97d"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("51ee1c82-279b-444c-a6aa-a8cd475612fd"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("5265b1f2-4422-4d0b-8711-582330d9afe4"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("609382d1-c969-4144-916a-ad4c13df1352"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("79c4217c-dc20-46fe-9e0b-44e852dfc64b"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("91da5e70-a3db-4168-b18d-61ae7b899b48"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("9b8cf62c-9c94-49aa-b55b-11a8f4f9a7c9"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("a386b3e8-683b-4e7e-9fba-3361bdbbeef1"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("b01aaa66-1888-4926-803e-95a864057219"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("be81d0fd-0ba8-4d55-ac65-4eb66d49028a"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("c4e77f65-5a61-404f-8793-b672ccdb29a4"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("c765da52-404b-4073-8c0c-003537169b4c"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("c9a5311a-4798-44c5-8b97-3a5bc4eaa01a"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("d819ecf0-3ccd-45d1-9f19-ba045d39fd65"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("e4d8ad5c-cf62-4001-9b81-f2a31bd87b0d"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("f39815c4-b651-4ed4-86e0-5b4f5f6128ef"));

            migrationBuilder.DeleteData(
                table: "Factions",
                keyColumn: "Identifier",
                keyValue: new Guid("fcae96dd-793a-4393-9f5f-f378ff167b12"));
        }
    }
}
