using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            // Simulated token-based authentication
            if (!context.Request.Headers.ContainsKey("Authorization") ||
                context.Request.Headers["Authorization"] != "Bearer valid-token")
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized: Invalid or missing token.");
                return;
            }
            
            await _next(context);
        }
    }
}
