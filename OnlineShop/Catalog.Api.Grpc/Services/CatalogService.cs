using Grpc.Core;

namespace Catalog.Api.Grpc.Services;

public class CatalogService : Catalog.CatalogBase
{
    private readonly ILogger<CatalogService> _logger;

    public CatalogService(ILogger<CatalogService> logger)
    {
        _logger = logger;
    }

    public override Task<SimpleResponse> SayHello(SimpleRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SimpleResponse
        {
            Message = "Hello " + request.Name
        });
    }
}
