using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace UserManagementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            // Log the incoming request
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            
            await _next(context);
            
            // Log the outgoing response
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}
