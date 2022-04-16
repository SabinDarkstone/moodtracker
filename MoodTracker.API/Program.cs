using Microsoft.EntityFrameworkCore;
using MoodTracker.Model.Data;
using MoodTracker.Model.Data.Seed;
using MoodTracker.Utils.Logger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(builder =>
        builder.ClearProviders()
            .AddSabinLogger(config => {
                config.LogLevels.Add(LogLevel.Debug, ConsoleColor.Cyan);
            }));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<MoodContext>(options => {
    options.UseInMemoryDatabase("Mood");
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

if (app.Environment.IsDevelopment()) {
    logger.LogDebug("Starting in development mode...");
    app.UseSwagger();
    app.UseSwaggerUI();
}

logger.LogInformation("Seeding in-memory database with intitial test data...");
using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    DataCreation.Initialize(services);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();