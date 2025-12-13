namespace MecatolArchives.Tests.Api;

[Collection(nameof(AppHostFixtureCollection))]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public sealed class FactionsControllerTest(AppHostFixture appHostFixture)
{
    [Fact, Priority(-10)]
    public async Task ReadFactions_ReturnsExpectedSeededData()
    {
        List<Faction> expected =
        [
            new()
            {
                Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
                Name = "The Council Keleres",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres"
            },
            new()
            {
                Identifier = Guid.Parse("609382d1-c969-4144-916a-ad4c13df1352"),
                Name = "_Unknown_",
                Url = string.Empty
            },
            new()
            {
                Identifier = Guid.Parse("11ee6931-58d5-4808-b2c5-e3d4b7bf4343"),
                Name = "The Arborec",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Arborec"
            },
            new()
            {
                Identifier = Guid.Parse("e4d8ad5c-cf62-4001-9b81-f2a31bd87b0d"),
                Name = "The Barony of Letnev",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Barony_of_Letnev",
            },
            new()
            {
                Identifier = Guid.Parse("b01aaa66-1888-4926-803e-95a864057219"),
                Name = "The Clan of Saar",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Clan_of_Saar",
            },
            new()
            {
                Identifier = Guid.Parse("fcae96dd-793a-4393-9f5f-f378ff167b12"),
                Name = "The Embers of Muaat",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Embers_of_Muaat",
            },
            new()
            {
                Identifier = Guid.Parse("c9a5311a-4798-44c5-8b97-3a5bc4eaa01a"),
                Name = "The Emirates of Hacan",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Emirates_of_Hacan"
            },
            new()
            {
                Identifier = Guid.Parse("a386b3e8-683b-4e7e-9fba-3361bdbbeef1"),
                Name = "The Federation of Sol",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Federation_of_Sol"
            },
            new()
            {
                Identifier = Guid.Parse("2e017142-848a-4203-a109-1fa905a5db04"),
                Name = "The Ghosts of Creuss",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Ghosts_of_Creuss"
            },
            new()
            {
                Identifier = Guid.Parse("4df36a67-6b3d-4966-ae0c-6ebdb6d0a97d"),
                Name = "The L1Z1X Mindnet",
                Url = "https://twilight-imperium.fandom.com/wiki/The_L1Z1X_Mindnet"
            },
            new()
            {
                Identifier = Guid.Parse("c765da52-404b-4073-8c0c-003537169b4c"),
                Name = "The Mentak Coalition",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Mentak_Coalition"
            },
            new()
            {
                Identifier = Guid.Parse("2002e0b3-603f-4b66-8268-2ca8ab2bfce4"),
                Name = "The Naalu Collective",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Naalu_Collective"
            },
            new()
            {
                Identifier = Guid.Parse("79c4217c-dc20-46fe-9e0b-44e852dfc64b"),
                Name = "The Nekro Virus",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Nekro_Virus"
            },
            new()
            {
                Identifier = Guid.Parse("1a5777dc-4106-46ec-8168-596c7c9edd36"),
                Name = "Sardakk N'orr",
                Url = "https://twilight-imperium.fandom.com/wiki/Sardakk_N%27orr"
            },
            new()
            {
                Identifier = Guid.Parse("0cc14756-19f7-42ef-acd0-156fab6bcd2b"),
                Name = "The Universities of Jol-Nar",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Universities_of_Jol-Nar"
            },
            new()
            {
                Identifier = Guid.Parse("9b8cf62c-9c94-49aa-b55b-11a8f4f9a7c9"),
                Name = "The Winnu",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Winnu"
            },
            new()
            {
                Identifier = Guid.Parse("279eefc5-4bd3-41be-93d0-b49bd6e9b7d6"),
                Name = "The Xxcha Kingdom",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Xxcha_Kingdom"
            },
            new()
            {
                Identifier = Guid.Parse("2c637584-cdbb-485e-8c3f-bc713eebaa03"),
                Name = "The Yin Brotherhood",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Yin_Brotherhood"
            },
            new()
            {
                Identifier = Guid.Parse("5265b1f2-4422-4d0b-8711-582330d9afe4"),
                Name = "The Yssaril Tribes",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Yssaril_Tribes"
            },
            new() // Additional Factions from Prophecy of Kings
            {
                Identifier = Guid.Parse("be81d0fd-0ba8-4d55-ac65-4eb66d49028a"),
                Name = "The Argent Flight",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Argent_Flight"
            },
            new()
            {
                Identifier = Guid.Parse("f39815c4-b651-4ed4-86e0-5b4f5f6128ef"),
                Name = "The Empyrean",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Empyrean"
            },
            new()
            {
                Identifier = Guid.Parse("2fffa08d-40ab-4e29-8e4a-0cda97b664be"),
                Name = "The Mahact Gene-Sorcerers",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Mahact_Gene-Sorcerers"
            },
            new()
            {
                Identifier = Guid.Parse("26251032-94c9-4331-8ccf-697755213fad"),
                Name = "The Naaz-Rokha Alliance",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Naaz-Rokha_Alliance"
            },
            new()
            {
                Identifier = Guid.Parse("4210c2bb-f773-4721-907b-1c3e1cd11357"),
                Name = "The Nomad",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Nomad"
            },
            new()
            {
                Identifier = Guid.Parse("c4e77f65-5a61-404f-8793-b672ccdb29a4"),
                Name = "The Titans of UL",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Titans_of_Ul"
            },
            new()
            {
                Identifier = Guid.Parse("91da5e70-a3db-4168-b18d-61ae7b899b48"),
                Name = "The Vuil'Raith Cabal",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Vuil%27Raith_Cabal"
            },
            new() // Additional Factions from Thunder's Edge
            {
                Identifier = Guid.Parse("fcbf11ee-afe1-44aa-abd0-497d0baa1ee8"),
                Name = "The Crimson Rebellion",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Crimson_Rebellion"
            },
            new()
            {
                Identifier = Guid.Parse("981e095a-55e0-4f35-8105-614eaa9cda43"),
                Name = "The Deepwrought Scholarate",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Deepwrought_Scholarate"
            },
            new()
            {
                Identifier = Guid.Parse("8d975e74-efc4-4297-a7c0-85c2bbe5d55d"),
                Name = "The Firmament / The Obsidian",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Firmament_/_The_Obsidian"
            },
            new()
            {
                Identifier = Guid.Parse("91bd2e7f-80ab-4e2f-df30-5c6d7e8f9011"),
                Name = "Last Bastion",
                Url = "https://twilight-imperium.fandom.com/wiki/Last_Bastion"
            },
            new()
            {
                Identifier = Guid.Parse("a2ce3f80-91bc-4f30-ef41-6d7e8f901122"),
                Name = "The Ral Nel Consortium",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Ral_Nel_Consortium"
            },
            new() // Additional Factions from Discordant Stars
            {
                Identifier = Guid.Parse("b3df4091-a2cd-4031-f052-7e8f90112233"),
                Name = "The Shipwrights of Axis",
                Url = "https://twilight-imperium.fandom.com/wiki/Shipwrights_of_Axis_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("c4e050a2-b3de-4132-0063-8f9011223344"),
                Name = "The Celdauri Trade Confederation",
                Url = "https://twilight-imperium.fandom.com/wiki/Celdauri_Trade_Confederation_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("d5f161b3-c4e0-4233-1164-901122334455"),
                Name = "The Savages of Cymiae",
                Url = "https://twilight-imperium.fandom.com/wiki/Savages_of_Cymiae_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("e60272c4-d5f1-4334-2265-011223344556"),
                Name = "The Dih-Mohn Flotilla",
                Url = "https://twilight-imperium.fandom.com/wiki/Dih-Mohn_Flotilla_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("f71383d5-e602-4435-3366-122334455667"),
                Name = "The Florzen Profiteers",
                Url = "https://twilight-imperium.fandom.com/wiki/Florzen_Profiteers_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("081a94e6-f713-4536-4467-233445566778"),
                Name = "The Free Systems of Compacts",
                Url = "https://twilight-imperium.fandom.com/wiki/Free_Systems_Compact_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("192ba5f7-081a-4637-5568-344556667889"),
                Name = "The Ghemina Raiders",
                Url = "https://twilight-imperium.fandom.com/wiki/Ghemina_Raiders_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("2a3cb608-192b-4738-6669-45566778899a"),
                Name = "The Augurs of Ilyxum",
                Url = "https://twilight-imperium.fandom.com/wiki/Augurs_of_Ilyxum_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("3b4dc719-2a3c-4839-777a-566778899a0b"),
                Name = "The Kollecc Society",
                Url = "https://twilight-imperium.fandom.com/wiki/Kollecc_Society_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("4c5ed82a-3b4d-493a-888b-6778899a0b1c"),
                Name = "The Kortali Tribunal",
                Url = "https://twilight-imperium.fandom.com/wiki/Kortali_Tribunal_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("5d6fe93b-4c5e-4a3b-999c-78899a0b1c2d"),
                Name = "The Li-Zho Dynasty",
                Url = "https://twilight-imperium.fandom.com/wiki/Li-Zho_Dynasty_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("6e70fa4c-5d6f-4b4c-a0ad-899a0b1c2d3e"),
                Name = "The L'tokk Khrask",
                Url = "https://twilight-imperium.fandom.com/wiki/L%27tokk_Khrask_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("7f81ab5d-6e70-4c5d-b1be-9a0b1c2d3e4f"),
                Name = "The Mirveda Protectorate",
                Url = "https://twilight-imperium.fandom.com/wiki/Mirveda_Protectorate_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("8092bc6e-7f81-4d6e-c2cf-0b1c2d3e4f50"),
                Name = "The Glimmer of Mortheus",
                Url = "https://twilight-imperium.fandom.com/wiki/Glimmer_of_Mortheus_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("91a3cd7f-8092-4e7f-d3d0-1c2d3e4f5061"),
                Name = "The Myko-Mentori",
                Url = "https://twilight-imperium.fandom.com/wiki/Myko-Mentori_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("a2b4de80-91a3-4f80-e4e1-2d3e4f506172"),
                Name = "The Nivyn Star Kings",
                Url = "https://twilight-imperium.fandom.com/wiki/Nivyn_Star_Kings_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("b3c5ef91-a2b4-4091-f5f2-3e4f50617283"),
                Name = "The Olradin League",
                Url = "https://twilight-imperium.fandom.com/wiki/Olradin_League_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("c4d60102-b3c5-4102-0603-4f5061728394"),
                Name = "The Zealots of Rhodun",
                Url = "https://twilight-imperium.fandom.com/wiki/Zealots_of_Rhodun_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("d5e71213-c4d6-4203-1714-506172839405"),
                Name = "Roh'Dhna Mechatronics",
                Url = "https://twilight-imperium.fandom.com/wiki/Roh%27Dhna_Mechatronics_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("e6f82324-d5e7-4304-2825-617283940516"),
                Name = "The Tnelis Syndicate",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Tnelis_Syndicate_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("f7093425-e6f8-4405-3936-728394051627"),
                Name = "The Vaden Banking Clans",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Vaden_Banking_Clans_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("0a1a4536-f709-4506-4a47-839405162738"),
                Name = "The Vaylerian Scourge",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Vaylerian_Scourge_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("1b2b5647-0a1a-4607-5b58-940516273849"),
                Name = "The Veldyr Sovereignty",
                Url = "https://twilight-imperium.fandom.com/wiki/The_Veldyr_Sovereignty_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("2c3c6758-1b2b-4708-6c69-a4051627384a"),
                Name = "The Zelian Purifier",
                Url = "https://twilight-imperium.fandom.com/wiki/Zelian_Purifier_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("3d4d7869-2c3c-4809-7d7a-b5162738495b"),
                Name = "The Bentor Conglomerate",
                Url = "https://twilight-imperium.fandom.com/wiki/Bentor_Conglomerate_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("4e5e897a-3d4d-490a-8e8b-c62738495c6c"),
                Name = "The Cheiran Hordes",
                Url = "https://twilight-imperium.fandom.com/wiki/Cheiran_Hordes_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("5f6f9a8b-4e5e-4a0b-9f9c-d738495c6d7d"),
                Name = "The Edyn Mandate",
                Url = "https://twilight-imperium.fandom.com/wiki/Edyn_Mandate_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("6070ab9c-5f6f-4b1c-a0ad-e8495c6d7e8e"),
                Name = "The Ghoti Wayfarers",
                Url = "https://twilight-imperium.fandom.com/wiki/Ghoti_Wayfarers_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("7181bcad-6070-4c2d-b1be-f95c6d7e8f9f"),
                Name = "The GLEdge Union",
                Url = "https://twilight-imperium.fandom.com/wiki/Gledge_Union_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("8292cdbe-7181-4d3e-c2cf-0a6d7e8f9010"),
                Name = "The Berserkers of Kjalengard",
                Url = "https://twilight-imperium.fandom.com/wiki/Berserkers_of_Kjalengard_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("93a3decf-8292-4e4f-d3e0-1b7e8f901121"),
                Name = "The Monks of Kolume",
                Url = "https://twilight-imperium.fandom.com/wiki/Monks_of_Kolume_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("a4b4ef00-93a3-4f50-e4f1-2c8f90112132"),
                Name = "The Kyro Sodality",
                Url = "https://twilight-imperium.fandom.com/wiki/Kyro_Sodality_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("b5c50111-a4b4-5051-f502-3d9011213243"),
                Name = "The Lanefir Remnants",
                Url = "https://twilight-imperium.fandom.com/wiki/Lanefir_Remnants_(UNOFFICIAL)"
            },
            new()
            {
                Identifier = Guid.Parse("c6d61222-b5c5-5162-0603-4e1121324354"),
                Name = "The Nokar Sellships",
                Url = "https://twilight-imperium.fandom.com/wiki/Nokar_Sellships_(UNOFFICIAL)"
            }
        ];

        var factions = await appHostFixture.ApiClient.Factions.ReadAsync(new QueryParameters { PageSize = expected.Count }, appHostFixture.CancellationToken);

        // Assert
        factions.Items.Should().Contain(expected);
    }

    [Fact]
    public async Task CreateFaction_ValidFaction_CreatesExpected()
    {
        var faction = await appHostFixture.ApiClient.Factions.CreateAsync(new()
        {
            Name = nameof(CreateFaction_ValidFaction_CreatesExpected),
        }, appHostFixture.CancellationToken);

        // Assert
        Assert.Equal(nameof(CreateFaction_ValidFaction_CreatesExpected), faction.Name);
    }

    [Fact]
    public async Task CreateFaction_InvalidFaction_Throws400()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            var faction = await appHostFixture.ApiClient.Factions.CreateAsync(new()
            {
                Name = null!,
            }, appHostFixture.CancellationToken);
        });
    }

    [Fact]
    public async Task DeleteFaction_ValidFaction_DeletesExpected()
    {
        var faction = await appHostFixture.ApiClient.Factions.CreateAsync(new()
        {
            Name = nameof(DeleteFaction_ValidFaction_DeletesExpected),
        }, appHostFixture.CancellationToken);

        await appHostFixture.ApiClient.Factions.DeleteAsync(faction.Identifier, appHostFixture.CancellationToken);

        var exception = await Assert.ThrowsAsync<HttpRequestException>((Func<Task>)(async () =>
        {
            var res = await appHostFixture.ApiClient.Factions.ReadAsync(faction.Identifier, appHostFixture.CancellationToken);
        }));
    }

    [Fact]
    public async Task DeleteFaction_InvalidFaction_DeletesExpected()
    {
        var guid = Guid.NewGuid();

        // Should not throw
        await appHostFixture.ApiClient.Factions.DeleteAsync(guid, appHostFixture.CancellationToken);
    }
}
