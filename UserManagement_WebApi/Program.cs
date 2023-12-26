using Get_Post_Microservice.Models;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using UserManagement_Infustracture.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configrationb = new ConfigurationBuilder().AddJsonFile("appsettings.json");
builder.Services.AddPresistence(builder.Configuration);
#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddGraphQL(u => SchemaBuilder.New().AddServices(u)
            .AddType<UserType>()
            .AddQueryType<UserQuery>()
            .Create()
        );
#pragma warning restore CS0618 // Type or member is obsolete

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UsePlayground(new PlaygroundOptions
    {

        QueryPath = "/api",
        Path = "/playground"

    });

}

app.MapGraphQL("/api");

app.UseAuthorization();

app.MapControllers();

app.Run();
