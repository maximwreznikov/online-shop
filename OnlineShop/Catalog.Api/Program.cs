using Catalog.App;
using Catalog.DAL;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApp();
builder.Services.AddPersistence(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context,cfg) =>
    {
        cfg.Host("localhost", "/", h => {
            h.Username("test");
            h.Password("test");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// app.Services.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

