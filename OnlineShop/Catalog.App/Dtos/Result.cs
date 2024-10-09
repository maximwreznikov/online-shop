namespace Catalog.App.Dtos;

public class Result<T> where T: struct
{
    public T Value { get; set; }
}