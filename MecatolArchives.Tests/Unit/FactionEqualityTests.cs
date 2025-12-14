namespace MecatolArchives.Tests.Unit;

public sealed class FactionEqualityTests
{
    [Fact]
    public void SameValue_WithSameVariants_ExpectedEquals()
    {
        var factionA = new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres",
            Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres",
            Variants = new FactionVariants(
            [
                new FactionVariant
                {
                    Identifier = Guid.Parse("3852bc1c-57d8-44fc-932f-9216c8eebdba"),
                    Name = "The Mentak Coalition"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("9c01e321-475d-447e-9d5a-e8d6b11ea828"),
                    Name = "The Xxcha Kingdom"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("f487ab41-107f-4a08-8a3c-5f8eade06e2c"),
                    Name = "The Argent Flight"
                }
            ])
        };

        var factionB = new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres",
            Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres",
            Variants = new FactionVariants(
            [
                new FactionVariant
                {
                    Identifier = Guid.Parse("3852bc1c-57d8-44fc-932f-9216c8eebdba"),
                    Name = "The Mentak Coalition"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("9c01e321-475d-447e-9d5a-e8d6b11ea828"),
                    Name = "The Xxcha Kingdom"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("f487ab41-107f-4a08-8a3c-5f8eade06e2c"),
                    Name = "The Argent Flight"
                }
            ])
        };

        Assert.Equal(factionA, factionB);
    }

    [Fact]
    public void SameValue_WithLessVariants_ExpectedNotEquals()
    {
        var factionA = new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres",
            Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres",
            Variants = new FactionVariants(
            [
                new FactionVariant
                {
                    Identifier = Guid.Parse("3852bc1c-57d8-44fc-932f-9216c8eebdba"),
                    Name = "The Mentak Coalition"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("9c01e321-475d-447e-9d5a-e8d6b11ea828"),
                    Name = "The Xxcha Kingdom"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("f487ab41-107f-4a08-8a3c-5f8eade06e2c"),
                    Name = "The Argent Flight"
                }
            ])
        };

        var factionB = new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres",
            Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres",
            Variants = new FactionVariants(
            [
                new FactionVariant
                {
                    Identifier = Guid.Parse("3852bc1c-57d8-44fc-932f-9216c8eebdba"),
                    Name = "The Mentak Coalition"
                }
            ])
        };

        Assert.NotEqual(factionA, factionB);
    }

    [Fact]
    public void SameValue_WithExtraVariants_ExpectedNotEquals()
    {
        var factionA = new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres",
            Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres",
            Variants = new FactionVariants(
            [
                new FactionVariant
                {
                    Identifier = Guid.Parse("3852bc1c-57d8-44fc-932f-9216c8eebdba"),
                    Name = "The Mentak Coalition"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("9c01e321-475d-447e-9d5a-e8d6b11ea828"),
                    Name = "The Xxcha Kingdom"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("f487ab41-107f-4a08-8a3c-5f8eade06e2c"),
                    Name = "The Argent Flight"
                }
            ])
        };

        var factionB = new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres",
            Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres",
            Variants = new FactionVariants(
            [
                new FactionVariant
                {
                    Identifier = Guid.Parse("3852bc1c-57d8-44fc-932f-9216c8eebdba"),
                    Name = "The Mentak Coalition"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("f487ab41-107f-4a08-8a3c-5f8eade06e2c"),
                    Name = "The Argent Flight"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("9c01e321-475d-447e-9d5a-e8d6b11ea828"),
                    Name = "The Xxcha Kingdom"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("a387ab41-107f-4a08-8a3c-5f8eade06e2c"),
                    Name = "The Fake Force"
                }
            ])
        };

        Assert.NotEqual(factionA, factionB);
    }


    [Fact]
    public void SameValue_WithDifferentVariants_ExpectedNotEquals()
    {
        var factionA = new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres",
            Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres",
            Variants = new FactionVariants(
            [
                new FactionVariant
                {
                    Identifier = Guid.Parse("3852bc1c-57d8-44fc-932f-9216c8eebdba"),
                    Name = "The Mentak Coalition"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("9c01e321-475d-447e-9d5a-e8d6b11ea828"),
                    Name = "The Xxcha Kingdom"
                },
                new FactionVariant
                {
                    Identifier = Guid.Parse("f487ab41-107f-4a08-8a3c-5f8eade06e2c"),
                    Name = "The Argent Flight"
                }
            ])
        };

        var factionB = new Faction
        {
            Identifier = Guid.Parse("51ee1c82-279b-444c-a6aa-a8cd475612fd"),
            Name = "The Council Keleres",
            Url = "https://twilight-imperium.fandom.com/wiki/The_Council_Keleres",
            Variants = new FactionVariants(
            [
                new FactionVariant
                {
                    Identifier = Guid.NewGuid(),
                    Name = "The Mentak"
                },
                new FactionVariant
                {
                    Identifier = Guid.NewGuid(),
                    Name = "The Xxcha"
                },
                new FactionVariant
                {
                    Identifier = Guid.NewGuid(),
                    Name = "The Argent"
                }
            ])
        };

        Assert.NotEqual(factionA, factionB);
    }

}