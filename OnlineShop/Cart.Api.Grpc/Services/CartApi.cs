using Cart.Core.Abstractions.Inbound;
using Grpc.Core;

namespace Cart.Api.Services;

public class CartApi(ICartService cartService) : Cart.CartBase
{
    public override Task<SimpleResponse> SayHello(SimpleRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SimpleResponse
        {
            Message = "Hello " + request.Name
        });
    }

    public override async Task<ItemListResponse> GetList(ItemListRequest request,
        ServerCallContext context)
    {
        var cartId = Guid.Parse(request.CartId);
        var cart = await cartService.Get(cartId);
        return cart.ToResponse();
    }

    public override async Task GetListStream(ItemListRequest request, IServerStreamWriter<ItemResponse> responseStream,
        ServerCallContext context)
    {
        var cartId = Guid.Parse(request.CartId);
        var cart = await cartService.Get(cartId);
        foreach (var cartItem in cart.Items)
        {
            await responseStream.WriteAsync(cartItem.ToResponse(), context.CancellationToken);
        }
    }

    public override async Task<ItemListResponse> AddItem(AddItemRequest request, ServerCallContext context)
    {
        var cartId = Guid.Parse(request.CartId);
        var itemDto = request.Data.ToItemEntity();
        var cartEntity = await cartService.AddItem(cartId, itemDto);
        return cartEntity.ToResponse();
    }

    public override async Task<ItemListResponse> AddItemClientStream(IAsyncStreamReader<AddItemRequest> requestStream,
        ServerCallContext context)
    {
        ItemListResponse? response = null;
        await foreach (var request in requestStream.ReadAllAsync(context.CancellationToken))
        {
            await AddItem(request, context);
        }

        return response!;
    }

    public override async Task AddItemBidirectional(IAsyncStreamReader<AddItemRequest> requestStream,
        IServerStreamWriter<ItemResponse> responseStream,
        ServerCallContext context)
    {
        await foreach (var request in requestStream.ReadAllAsync(context.CancellationToken))
        {
            var cartId = Guid.Parse(request.CartId);
            var itemDto = request.Data.ToItemEntity();
            await cartService.AddItem(cartId, itemDto);
            await responseStream.WriteAsync(itemDto.ToResponse(), context.CancellationToken);
        }
    }

    public override async Task<ItemListResponse> RemoveItem(RemoveItemRequest request, ServerCallContext context)
    {
        var cartId = Guid.Parse(request.CartId);
        int itemId = request.ItemId;
        var cartEntity = await cartService.RemoveItem(cartId, itemId);
        return cartEntity.ToResponse();
    }
}
