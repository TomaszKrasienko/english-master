using english_master.DAL;
using english_master.DAL.Configuration;
using english_master.DTOs.Words.Requests;
using english_master.Graph;
using english_master.Models;

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
app.MapPost(
    "/api/words", 
    async (
        CreateWordRequestDto request,
        EnglishMasterDbContext context
    ) =>
{
    var word = Word.Create(Guid.NewGuid(), request.Term, request.Translation, request.TopicId);
    context.Add(word);
    await context.SaveChangesAsync();
});

app.MapGraphQL();
await app.RunAsync();
