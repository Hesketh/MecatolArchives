using AutoMapper;
using Hesketh.MecatolArchives.API.Data.Post;

namespace Hesketh.MecatolArchives.API.Mapping;

public class Post : Profile
{
    public Post()
    {
        CreateMap<Colour, DB.Models.Colour>();
        CreateMap<Expansion, DB.Models.Expansion>();
        CreateMap<Faction, DB.Models.Faction>();
        CreateMap<Variant, DB.Models.Variant>();
        CreateMap<Person, DB.Models.Person>();
        CreateMap<Play, DB.Models.Play>();
        CreateMap<Player, DB.Models.Player>();
    }
}