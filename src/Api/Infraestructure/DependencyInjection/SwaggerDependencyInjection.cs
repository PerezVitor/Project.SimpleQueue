using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Infraestructure.DependencyInjection
{
    public static class SwaggerDependencyInjection
    {
        public static IServiceCollection ConfigureSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                SetSwaggerDoc(options);
                SetSecurityDefinition(options);
                SetSecurityRequirement(options);
            });

            return services;
        }

        private static void SetSecurityRequirement(SwaggerGenOptions options)
        {
            options.AddSecurityRequirement(GetOpenApiSecurityRequirement());
        }

        private static OpenApiSecurityRequirement GetOpenApiSecurityRequirement()
        {
            return new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        }
                    },
                    Array.Empty<string>()
                }
            };
        }
        private static void SetSecurityDefinition(SwaggerGenOptions options)
        {
            // Add the API key as a security scheme
            options.AddSecurityDefinition("ApiKey", GetOpenApiSecurityScheme());
        }

        private static OpenApiSecurityScheme GetOpenApiSecurityScheme()
        {
            return new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = "X-Api-Key",
                Description = "API key needed to access the endpoints."
            };
        }

        private static void SetSwaggerDoc(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My example API", Version = "v1" });
        }
    }
}
