using Server.Services.AzureBlobService;
using Server.Settings;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

CorsSettings corsSettings = builder.Configuration
    .GetSection(nameof(ApplicationSettings))
    .GetSection(CorsSettings.SectionName)
    .Get<CorsSettings>()
    ?? throw new InvalidOperationException("CORS settings are not configured.");

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins(corsSettings.AllowedOrigins)
            .WithMethods(HttpMethods.Get)
            .AllowAnyHeader();
    });
});

// Add services
builder.Services.AddSingleton<IAzureBlobStorageService, AzureBlobStorageService>();

// Add Controllers
builder.Services.AddControllers();

// Custom configuration and registration
builder.Services.ConfigureApplicationSettings(builder.Configuration);

WebApplication app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("Frontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
