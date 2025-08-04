using english_master.DAL;
using english_master.DAL.Configuration;
using english_master.DTOs.Words.Requests;
using english_master.Graph;
using english_master.Models;
using HotChocolate.Execution;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddDal(builder.Configuration);
builder.Services.AddGraphQl();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGraphQL();
await app.RunAsync();
