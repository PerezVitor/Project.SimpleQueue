using Api.Extensions;

namespace Api.Presentation.Auth;
public class ApiKeyAuth : IMiddleware
{
    private static string ApiKeyHeaderName => "X-Api-Key";
    private readonly IConfiguration _configuration;
    public ApiKeyAuth(IConfiguration configuration) => _configuration = configuration;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.IsNotHealthCheckOrSwagger() && !IsValidApiKey(context))
        {
            await context.SetUnauthorized();
            return;
        }

        await next(context);
    }

    private bool IsValidApiKey(HttpContext context)
    {
        string? apikey = context.GetApiKeyFromHeader(ApiKeyHeaderName);
        return apikey is not null && apikey == _configuration.GetApiKey();
    }
}
