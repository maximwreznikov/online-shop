namespace Catalog.App.Exceptions;

public class NotFoundEntity : Exception
{
    public NotFoundEntity(string entityName)
    {
        EntityName = entityName;
    }
    
    public string EntityName { get; private set; }
        
}