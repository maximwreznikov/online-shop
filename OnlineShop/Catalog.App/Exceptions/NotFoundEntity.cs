namespace Catalog.App.Exceptions;

public class NotFoundEntity(string entityName) : Exception
{
    public string EntityName { get; private set; } = entityName;
}
