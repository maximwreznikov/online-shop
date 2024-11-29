using Microsoft.AspNetCore.Authentication;

namespace Cart.Api;

public class LogRolesMiddleware
{
    private readonly ILogger<LogRolesMiddleware> _logger;
    private readonly RequestDelegate _next;

    public LogRolesMiddleware(RequestDelegate next, ILogger<LogRolesMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string[] roles = context.User.Claims
            .Where(c => c.Type == System.Security.Claims.ClaimTypes.Role)
            .Select(c => c.Value)
            .ToArray();

        _logger.LogInformation("Made request with role {Roles}", roles.ToString());
        await _next(context);
    }
}

public static class LogRolesMiddlewareExtensions
{
    public static IApplicationBuilder UseLogRoles(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogRolesMiddleware>();
    }
}
