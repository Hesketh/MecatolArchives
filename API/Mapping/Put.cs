using AutoMapper;
using Hesketh.MecatolArchives.API.Data.Put;

namespace Hesketh.MecatolArchives.API.Mapping;

public class Put : Profile
{
    public Put()
    {
        CreateMap<Play, DB.Models.Play>();
        CreateMap<Person, DB.Models.Person>();
    }
}