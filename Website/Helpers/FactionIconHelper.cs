namespace Hesketh.MecatolArchives.Website.Helpers
{
    public static class FactionIconHelper
    {
        public static string GetFactionIcon(string factionName)
        {
            switch (factionName)
            {
                case "The Arborec":
                    return "factions/Arborec.png";
                case "The Argent Flight":
                    return "factions/Argent.png";
                case "The Ghosts of Creuss":
                    return "factions/Creuss.png";
                case "The Empyrean":
                    return "factions/Empyrean.png";
                case "The Emirates of Hacan":
                    return "factions/Hacan.png";
                case "The Universities of Jol-Nar":
                    return "factions/Jol Nar.png";
                case "The Council Keleres (The Argent Flight)":
                case "The Council Keleres (The Mentak Coalition)":
                case "The Council Keleres (The Xxcha Kingdoms)":
                    return "factions/Keleres.png";
                case "The L1Z1X Mindnet":
                    return "factions/L1Z1X.png";
                case "The Barony of Letnev":
                    return "factions/Letnev.png";
                case "The Mahact Gene-Sorcerers":
                    return "factions/Mahact.png";
                case "The Mentak Coalition":
                    return "factions/Mentak.png";
                case "The Embers of Muaat":
                    return "factions/Muaat.png";
                case "The Naalu Collective":
                    return "factions/Naalu.png";
                case "The Naaz-Rokha Alliance":
                    return "factions/Naaz-Rokha.png";
                case "The Nekro Virus":
                    return "factions/Nekro.png";
                case "The Nomad":
                    return "factions/Nomad.png";
                case "The Clan of Saar":
                    return "factions/Saar.png";
                case "Sardakk N'orr":
                    return "factions/Sardakk.png";
                case "The Federation of Sol":
                    return "factions/Sol.png";
                case "The Titans of UL":
                    return "factions/Titans.png";
                case "The Vuil'Raith Cabal":
                    return "factions/Vuil'Raith.png";
                case "The Winnu":
                    return "factions/Winnu.png";
                case "The Yin Brotherhood":
                    return "factions/Yin.png";
                case "The Yssaril Tribes":
                    return "factions/Yssaril.png";
                case "The Xxcha Kingdom":
                    return "factions/Xxcha.png";
                default:
                    return "factions/Unknown.png";
            }
        }
    }
}
