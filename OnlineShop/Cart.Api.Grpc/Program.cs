using Cart.Api.Services;
using Cart.Core;
using Cart.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddCore(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CartApi>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

var env = app.Environment;
if (env.IsDevelopment())
{
    app.MapGrpcReflectionService().AllowAnonymous();;
}

await app.RunAsync();
