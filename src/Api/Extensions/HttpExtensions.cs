using System.IO;

namespace Api.Extensions;
public static class HttpExtensions
{
    static readonly PathString[] PathToIgnore = new PathString[] { "/health", "/swagger" };

    public static string? GetApiKeyFromHeader(this HttpContext context, string apiKeyHeaderName) 
        => context.Request.Headers[apiKeyHeaderName];

    public static bool IsNotHealthCheckOrSwagger(this HttpContext context) 
        => !PathToIgnore.Any(row => context.Request.Path.StartsWithSegments(row));

    public static async Task<HttpContext> SetUnauthorized(this HttpContext context)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized");
        return context;
    }
}
