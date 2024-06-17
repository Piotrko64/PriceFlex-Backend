using Coravel;
using NLog.Web;
using PriceFlex_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddControllers();
builder.Services.AddScoped<WebScrapperService>();
builder.Services.AddScoped<EmailSenderService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScheduler();



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.UseScheduler(scheduler =>
{

    scheduler.ScheduleAsync(async () =>
    {

        await Task.Delay(20);
        Console.WriteLine("EXAMPLE");
    }).EveryFiveSeconds();

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();





app.Run();
