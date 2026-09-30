using Server.Services.AzureBlobService;
using Server.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173", "https://brianhsweet.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services
builder.Services.AddSingleton<IAzureBlobStorageService, AzureBlobStorageService>();

// Add Controllers
builder.Services.AddControllers();

// Custom configuration and registration
builder.Services.ConfigureApplicationSettings(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("Frontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
