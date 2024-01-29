using AutoMapper;

namespace Hesketh.MecatolArchives.API.Mapping;

public class Post : Profile
{
    public Post()
    {
        CreateMap<DTP.Colour, DBM.Colour>();
        CreateMap<DTP.Expansion, DBM.Expansion>();
        CreateMap<DTP.Faction, DBM.Faction>();
        CreateMap<DTP.Variant, DBM.Variant>();
        CreateMap<DTP.Person, DBM.Person>();
    }
}