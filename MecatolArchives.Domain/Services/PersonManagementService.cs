using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public sealed class PersonManagementService(MecatolArchivesDbContext dbContext)
    : CRUDManagementServiceBase<DataAccess.Models.Person, Person, PersonCreateRequest, PersonUpdateRequest>(dbContext), IPersonManagementService
{
    protected override Task<Person> MapToDto(DataAccess.Models.Person dbModel)
    {
        return Task.FromResult(new Person
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name
        });
    }

    protected override Task<DataAccess.Models.Person> MapToDb(PersonCreateRequest create)
    {
        return Task.FromResult(new DataAccess.Models.Person
        {
            Identifier = Guid.NewGuid(),
            Name = create.Name
        });
    }

    protected override Task<DataAccess.Models.Person> MapToDb(DataAccess.Models.Person dbModel, PersonUpdateRequest update)
    {
        if (update.Name != null)
        {
            dbModel.Name = update.Name;
        }

        return Task.FromResult(dbModel);
    }
}
