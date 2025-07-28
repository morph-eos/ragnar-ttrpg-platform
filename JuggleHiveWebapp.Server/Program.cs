/*
 * Ragnar TTRPG Platform - Main Application Server
 * 
 * This is the main entry point for the .NET Core API server that powers the Ragnar TTRPG Platform.
 * It configures all necessary services, middleware, and dependency injection for the application.
 * 
 * Key Features:
 * - RESTful API endpoints for TTRPG game mechanics
 * - PostgreSQL database integration with Entity Framework Core
 * - Azure cloud storage integration for file management
 * - CORS configuration for Angular frontend communication
 * - Comprehensive service layer with dependency injection
 * 
 * Architecture:
 * - Clean Architecture with separated concerns (Controllers, Services, Models)
 * - Repository pattern implementation through Entity Framework
 * - Environment-based configuration management
 * - Swagger API documentation in development mode
 */

using JuggleHiveWebapp.Server.Models;
using JuggleHiveWebapp.Server.Services;
using JuggleHiveWebapp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

// Create the web application builder with default configuration
var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file for development configuration
// This allows secure management of secrets and environment-specific settings
Env.Load();

// =====================================================
// SERVICE CONFIGURATION
// =====================================================

// Add MVC controllers to handle HTTP requests and responses
builder.Services.AddControllers();

// Configure Cross-Origin Resource Sharing (CORS) to allow Angular frontend communication
// This is essential for security while enabling the SPA to communicate with the API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        // Get the domain from environment variables for flexible deployment
        var domain = Environment.GetEnvironmentVariable("DOMAIN");
        
        // Allow local development URLs (Angular dev server typically runs on port 4200)
        builder.WithOrigins("https://localhost:4200", "http://localhost:4200", $"https://{domain}", $"http://{domain}");

        // List of allowed subdomains for multi-tenant or feature-specific deployments
        // This enables subdomain-based routing for different platform features
        var allowedSubdomains = new[] {"ragnar", "projectsketch"};

        // Add local development subdomain support
        foreach (var subdomain in allowedSubdomains)
        {
            builder.WithOrigins($"https://{subdomain}.localhost:4200", $"http://{subdomain}.localhost:4200");
        }

        // If production domain is configured, add subdomain support for production
        if (!string.IsNullOrEmpty(domain))
        {
            foreach (var subdomain in allowedSubdomains)
            {
                builder.WithOrigins($"https://{subdomain}.{domain}", $"http://{subdomain}.{domain}");
            }
        }

        builder
            .AllowAnyMethod()      // Allow all HTTP methods (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader()      // Allow all request headers
            .AllowCredentials();   // Enable credentials for authentication cookies/tokens
    });
});
// Configure Swagger/OpenAPI for API documentation and testing
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =====================================================
// DATABASE CONFIGURATION
// =====================================================

// Configure PostgreSQL database context with Entity Framework Core
// Uses connection string from appsettings.json or environment variables
builder.Services.AddDbContext<PostgresContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// =====================================================
// DEPENDENCY INJECTION - SERVICE LAYER
// =====================================================

// Register all business logic services using the Scoped lifetime
// Scoped services are created once per HTTP request, ensuring consistent state
// Each service handles specific domain logic for TTRPG game mechanics

// Azure cloud integration services
builder.Services.AddScoped<IAzureFileService, AzureFileService>();

// Game mechanics services - Core TTRPG functionality
builder.Services.AddScoped<IAllowedItemService, AllowedItemService>();           // Class-item restrictions
builder.Services.AddScoped<IBaseStatService, BaseStatService>();                 // Character base statistics
builder.Services.AddScoped<ICharaService, CharaService>();                       // Main character management
builder.Services.AddScoped<ICharacterClassService, CharacterClassService>();     // Character-class relationships
builder.Services.AddScoped<ICharacterInfoService, CharacterInfoService>();       // Character metadata and progression
builder.Services.AddScoped<ICharacterSkillService, CharacterSkillService>();     // Character skill acquisition
builder.Services.AddScoped<ICharactersTreePointService, CharacterTreePointsService>(); // Skill tree progression points
builder.Services.AddScoped<IClassService, ClassService>();                       // Character classes and archetypes
builder.Services.AddScoped<IInventoryService, InventoryService>();               // Item inventory management
builder.Services.AddScoped<IItemService, ItemService>();                         // Game items and equipment
builder.Services.AddScoped<INewsService, NewsService>();                         // Platform news and updates
builder.Services.AddScoped<IRaceService, RaceService>();                         // Character races and ethnicities
builder.Services.AddScoped<IRaceSkillService, RaceSkillService>();               // Race-specific abilities
builder.Services.AddScoped<IRegionService, RegionService>();                     // Game world regions
builder.Services.AddScoped<ISkillFamilyService, SkillFamilyService>();           // Skill categorization
builder.Services.AddScoped<ISkillModifierService, SkillModifierService>();       // Skill effect modifiers
builder.Services.AddScoped<ISkillModifierDixService, SkillModifierDixService>(); // Dice-based skill effects
builder.Services.AddScoped<ISkillService, SkillService>();                       // Core skill system
builder.Services.AddScoped<ITreeEntityService, TreeEntityService>();             // Skill trees and progression paths
builder.Services.AddScoped<ITreeSkillService, TreeSkillService>();               // Tree-skill relationships
builder.Services.AddScoped<IUserService, UserService>();                         // User authentication and management

// =====================================================
// APPLICATION BUILD AND MIDDLEWARE PIPELINE
// =====================================================

// Build the web application with all configured services
var app = builder.Build();

// Enable serving static files (CSS, JS, images) from wwwroot
// This is essential for serving the Angular application build output
app.UseDefaultFiles();
app.UseStaticFiles();

// =====================================================
// DEVELOPMENT ENVIRONMENT CONFIGURATION
// =====================================================

// Configure the HTTP request pipeline for development environment
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI for API documentation and testing
    // Only available in development for security reasons
    app.UseSwagger();
    app.UseSwaggerUI();
}

// =====================================================
// SECURITY AND ROUTING MIDDLEWARE
// =====================================================

// Force HTTPS redirection for all requests (security best practice)
app.UseHttpsRedirection();

// Apply the CORS policy configured earlier
// Must be placed before authorization and controller mapping
app.UseCors("AllowAngularApp");

// Enable authorization middleware (placeholder for future authentication)
app.UseAuthorization();

// Map API controllers to handle HTTP requests
// Controllers will handle routes like /api/characters, /api/skills, etc.
app.MapControllers();

// =====================================================
// SPA FALLBACK ROUTING
// =====================================================

// Fallback to index.html for Angular SPA routing
// This ensures that Angular's client-side routing works correctly
// When users navigate to routes like /characters or /skills, 
// the server returns index.html and Angular handles the routing
app.MapFallbackToFile("/index.html");

// Start the application and listen for incoming requests
app.Run();
