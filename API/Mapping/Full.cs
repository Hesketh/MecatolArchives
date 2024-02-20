using AutoMapper;
using Hesketh.MecatolArchives.DB.Models;

namespace Hesketh.MecatolArchives.API.Mapping;

public sealed class Full : Profile
{
    public Full()
    {
        CreateMap<Colour, Data.Colour>().ReverseMap();
        CreateMap<Expansion, Data.Expansion>().ReverseMap();
        CreateMap<Faction, Data.Faction>().ReverseMap();
        CreateMap<Variant, Data.Variant>().ReverseMap();
        CreateMap<Person, Data.Person>().ReverseMap();
        CreateMap<Play, Data.Play>().AfterMap((dbo, dto) =>
        {
            dto.Players = new List<DTM.Player>(dto.Players.OrderBy(x => x.Eliminated).ThenByDescending(x => x.Points));
        });
        CreateMap<Data.Play, Play>();
        CreateMap<Player, Data.Player>().ReverseMap();
    }
}