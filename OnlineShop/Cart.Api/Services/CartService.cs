using Grpc.Core;
using Cart.Api;

namespace Cart.Api.Services;

public class CartService : Cart.CartBase
{
    public override Task<SimpleResponse> SayHello(SimpleRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SimpleResponse
        {
            Message = "Hello " + request.Name
        });
    }
}