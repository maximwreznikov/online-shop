using LiteDB;
using Microsoft.Extensions.Options;

namespace Cart.DAL;

internal class LiteDbContext(IOptions<LiteDbOptions> options) : ILiteDbContext
{
    public LiteDatabase Database { get; } = new LiteDatabase(options.Value.DatabaseLocation);
}
