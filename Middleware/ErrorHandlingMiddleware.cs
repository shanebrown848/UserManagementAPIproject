using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Text.Json;

namespace UserManagementAPI.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Unhandled exception: {ex.Message}");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var errorResponse = JsonSerializer.Serialize(new { error = "Internal server error." });
                await context.Response.WriteAsync(errorResponse);
            }
        }
    }
}
