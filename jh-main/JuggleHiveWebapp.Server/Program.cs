using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        var domain = Environment.GetEnvironmentVariable("DOMAIN");
        builder.WithOrigins("https://localhost:4200", "http://localhost:4200", $"https://{domain}", $"http://{domain}");

        // List of allowed subdomains
        var allowedSubdomains = new[] {"ragnar", "projectsketch"};

        foreach (var subdomain in allowedSubdomains)
        {
            builder.WithOrigins($"https://{subdomain}.localhost:4200", $"http://{subdomain}.localhost:4200");
        }

        // If the DOMAIN environment variable is present, add it with the allowed subdomains
        if (!string.IsNullOrEmpty(domain))
        {
            foreach (var subdomain in allowedSubdomains)
            {
                builder.WithOrigins($"https://{subdomain}.{domain}", $"http://{subdomain}.{domain}");
            }
        }

        builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // Allows using cookies or credentials for CORS
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAzureFileService, AzureFileService>();
builder.Services.AddScoped<IAllowedItemService, AllowedItemService>();
builder.Services.AddScoped<IBaseStatService, BaseStatService>();
builder.Services.AddScoped<ICharaService, CharaService>();
builder.Services.AddScoped<ICharacterClassService, CharacterClassService>();
builder.Services.AddScoped<ICharacterInfoService, CharacterInfoService>();
builder.Services.AddScoped<ICharacterSkillService, CharacterSkillService>();
builder.Services.AddScoped<ICharactersTreePointService, CharacterTreePointsService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IRaceService, RaceService>();
builder.Services.AddScoped<IRaceSkillService, RaceSkillService>();
builder.Services.AddScoped<IRegionService, RegionService>();
builder.Services.AddScoped<ISkillFamilyService, SkillFamilyService>();
builder.Services.AddScoped<ISkillModifierService, SkillModifierService>();
builder.Services.AddScoped<ISkillModifierDixService, SkillModifierDixService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ITreeEntityService, TreeEntityService>();
builder.Services.AddScoped<ITreeSkillService, TreeSkillService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
