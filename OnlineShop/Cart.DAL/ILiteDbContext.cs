using LiteDB;

namespace Cart.DAL;

public interface ILiteDbContext
{
    LiteDatabase Database { get; }
}