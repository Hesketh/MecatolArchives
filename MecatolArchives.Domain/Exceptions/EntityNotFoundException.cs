namespace MecatolArchives.Domain.Exceptions;

public sealed class EntityNotFoundException(Type type, Guid id) : Exception($"No {type.Name} could be found with identifier {id}")
{
}
