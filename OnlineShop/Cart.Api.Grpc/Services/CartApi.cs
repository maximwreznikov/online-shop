using Grpc.Core;

namespace Cart.Api.Services;

public class CartApi : Cart.CartBase
{
    public override Task<SimpleResponse> SayHello(SimpleRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SimpleResponse
        {
            Message = "Hello " + request.Name
        });
    }
}