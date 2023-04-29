namespace Api.Presentation.Example;
public static class ExampleRequest
{
    public static IEndpointRouteBuilder AddRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("example", () => new { Data = "Here is one example" });
        return app;
    }
}
