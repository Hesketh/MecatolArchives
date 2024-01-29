using AutoMapper;

namespace Hesketh.MecatolArchives.API.Mapping;

public sealed class Full : Profile
{
    public Full()
    {
        CreateMap<DBM.Colour, DTM.Colour>().ReverseMap();
        CreateMap<DBM.Expansion, DTM.Expansion>().ReverseMap();
        CreateMap<DBM.Faction, DTM.Faction>().ReverseMap();
        CreateMap<DBM.Variant, DTM.Variant>().ReverseMap();
        CreateMap<DBM.Person, DTM.Person>().ReverseMap();
    }
}