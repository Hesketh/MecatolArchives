using MecatolArchives.DataAccess;
using MecatolArchives.Domain.Dto;

namespace MecatolArchives.Domain.Services;

public sealed class ContentManagementService(MecatolArchivesDbContext dbContext)
    : CRUDManagementServiceBase<DataAccess.Models.Content, Content, ContentCreateRequest, ContentUpdateRequest>(dbContext), IContentManagementService
{
    protected override Task<Content> MapToDto(DataAccess.Models.Content dbModel)
    {
        return Task.FromResult(new Content
        {
            Identifier = dbModel.Identifier,
            Name = dbModel.Name,
        });
    }

    protected override Task<DataAccess.Models.Content> MapToDb(ContentCreateRequest create)
    {
        return Task.FromResult(new DataAccess.Models.Content
        {
            Identifier = Guid.NewGuid(),
            Name = create.Name,
        });
    }

    protected override Task<DataAccess.Models.Content> MapToDb(DataAccess.Models.Content dbModel, ContentUpdateRequest update)
    {
        if (update.Name != null)
        {
            dbModel.Name = update.Name;
        }

        return Task.FromResult(dbModel);
    }
}