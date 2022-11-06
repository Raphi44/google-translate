using google_translate.Models;
using google_translate.RequestHandler;
using google_translate.services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<dbSettings>(
    builder.Configuration.GetSection("google-translateDB"));
builder.Services.AddSingleton<IdbSettings>(sp =>
    sp.GetRequiredService<IOptions<dbSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("google-translateDB:ConnectionString")));

builder.Services.AddSingleton<IPhraseService, PhraseService>();

builder.Services.AddHttpClient();

builder.Services.AddSingleton<TranslateRequestHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
