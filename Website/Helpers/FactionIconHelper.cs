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
                // DS
                case "The Bentor Conglomerate":
                    return "factions/ds/Bentor_icon.webp";
                case "The Cheiran Hordes":
                    return "factions/ds/Cheiran_icon.webp";
                case "The Edyn Mandate":
                    return "factions/ds/Edyn_icon.webp";
                case "The Ghoti Wayfarers":
                    return "factions/ds/Ghoti_icon.webp";
                case "The GLEdge Union":
                    return "factions/ds/Gledge_icon.webp";
                case "The Berserkers of Kjalengard":
                    return "factions/ds/Kjalengard_icon.webp";
                case "The Monks of Kolume":
                    return "factions/ds/Kolume_icon.webp";
                case "The Kyro Sodality":
                    return "factions/ds/Kyro_icon.webp";
                case "The Lanefir Remnants":
                    return "factions/ds/Lanefir_icon.png";
                case "The Nokar Sellships":
                    return "factions/ds/Nokar_icon.webp";
                case "The Shipwrights of Axis":
                    return "factions/ds/Axis_icon.webp";
                case "The Celdauri Trade Confederation":
                    return "factions/ds/Celdauri_icon.webp";
                case "The Savages of Cymiae":
                    return "factions/ds/Cymiae_icon.webp";
                case "The Dih-Mohn Flotilla":
                    return "factions/ds/Dih-mohn_icon.webp";
                case "The Florzen Profiteers":
                    return "factions/ds/Florzen_icon.webp";
                case "The Free Systems Compact":
                    return "factions/ds/Free_Systems_Compact_icon.webp";
                case "The Ghemina Raiders":
                    return "factions/ds/Ghemina_icon.webp";
                case "The Augurs of Ilyxum":
                    return "factions/ds/Ilyxum_icon.webp";
                case "The Kollecc Society":
                    return "factions/ds/Kollecc_icon.webp";
                case "The Kortali Tribunal":
                    return "factions/ds/Kortali_icon.webp";
                case "The Li-Zho Dynasty":
                    return "factions/ds/Li-Zho_icon.webp";
                case "The L'tokk Khrask":
                    return "factions/ds/Khrask_icon.webp";
                case "The Mirveda Protectorate":
                    return "factions/ds/Mirveda_icon.webp";
                case "The Glimmer of Mortheus":
                    return "factions/ds/Mortheus_icon.webp";
                case "The Myko-Mentori":
                    return "factions/ds/Myko-Mentori_icon.webp";
                case "The Nivyn Star Kings":
                    return "factions/ds/Nivyn_icon.webp";
                case "The Olradin League":
                    return "factions/ds/Olradin_icon.webp";
                case "The Zealots of Rhodun":
                    return "factions/ds/Rhodun_icon.png";
                case "Roh'Dhna Mechatronics":
                    return "factions/ds/RohDhna_icon.png";
                case "The Tnelis Syndicate":
                    return "factions/ds/Tnelis_icon.webp";
                case "The Vaden Banking Clans":
                    return "factions/ds/Vaden_icon.png";
                case "The Vaylerian Scourge":
                    return "factions/ds/Vaylerian_icon.webp";
                case "The Veldyr Sovereignty":
                    return "factions/ds/Veldyr_icon.webp";
                case "The Zelian Purifier":
                    return "factions/ds/Zelian_icon.webp";
                default:
                    return "factions/Unknown.png";
            }
        }
    }
}
