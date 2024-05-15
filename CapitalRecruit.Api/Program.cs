using System.Configuration;
using CapitalRecruit.Api.Extensions;
using CapitalRecruit.Infrastructure.Data;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ResolveDepencyInjections(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

using CosmosClient client = new(
    accountEndpoint: builder.Configuration.GetSection("CosmosDb:Account").Value,
    authKeyOrResourceToken: builder.Configuration.GetSection("CosmosDb:Key").Value
);

Database database = await client.CreateDatabaseIfNotExistsAsync(
    id: builder.Configuration.GetSection("CosmosDb:DatabaseName").Value,
    throughput: 400
);

Container container = await database.CreateContainerIfNotExistsAsync(
    id: builder.Configuration.GetSection("CosmosDb:ContainerName").Value,
    partitionKeyPath: "/id"
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
