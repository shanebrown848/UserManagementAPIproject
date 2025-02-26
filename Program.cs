using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();

// Global error-handling middleware should be first
app.UseMiddleware<ErrorHandlingMiddleware>();

// Authentication middleware next
app.UseMiddleware<AuthenticationMiddleware>();

// Logging middleware to capture request details
app.UseMiddleware<LoggingMiddleware>();

// Configure Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map controllers (CRUD endpoints)
app.MapControllers();

app.Run();
