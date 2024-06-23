using Coravel;
using NLog.Web;
using PriceFlex_Backend.Services;
using PriceFlex_Backend.Data;
using Microsoft.EntityFrameworkCore;
using PriceFlex_Backend.Middlewares;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using PriceFlex_Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
builder.Services.AddDbContext<ScrapperDbContext>();
builder.Services.AddControllers();
builder.Services.AddScoped<WebScrapperService>();
builder.Services.AddScoped<ScrapperDbContext, ScrapperDbContext>();
builder.Services.AddScoped<EmailSenderService>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScheduler();
builder.Services.AddScoped<ErrorHandlingMiddleware>();


builder.Services.AddControllers()
          .AddJsonOptions(options =>
          {
              options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
          });


var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();

app.Services.UseScheduler(scheduler =>
{

    scheduler.ScheduleAsync(async () =>
    {

        await Task.Delay(20);
        Console.WriteLine("EXAMPLE");
    }).EveryFiveSeconds();

});
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();





app.Run();
