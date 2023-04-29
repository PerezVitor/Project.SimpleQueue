using Api.Presentation.Auth;

namespace Api.Infraestructure.DependencyInjection;
public static class ApiDependences
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.ConfigureSwaggerServices();
        services.AddHealthChecks();
        services.AddSingleton<ApiKeyAuth>();
        return services;
    }   
    
    public static IApplicationBuilder ConfigureApi(this IApplicationBuilder app)
    {
        app.UseMiddleware<ApiKeyAuth>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHealthChecks("/health");
        return app;
    }
}
