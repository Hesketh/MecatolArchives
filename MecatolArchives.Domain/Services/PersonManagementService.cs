using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public sealed class PersonManagementService(MecatolArchivesDbContext dbContext)
    : CRUDManagementServiceBase<DataAccess.Models.Person, Person, PersonCreateRequest, PersonUpdateRequest>(dbContext), IPersonManagementService
{
    protected override Person MapToDto(DataAccess.Models.Person dbModel)
    {
        return new Person()
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name
        };
    }

    protected override DataAccess.Models.Person MapToDb(PersonCreateRequest create)
    {
        return new DataAccess.Models.Person
        {
            Identifier = Guid.NewGuid(),
            Name = create.Name
        };
    }

    protected override DataAccess.Models.Person MapToDb(DataAccess.Models.Person dbModel, PersonUpdateRequest update)
    {
        dbModel.Name = update.Name;
        return dbModel;
    }
}
