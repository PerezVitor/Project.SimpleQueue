namespace Api.Extensions;
public static class ConfigurationExtensions
{
    public static string? GetApiKey(this IConfiguration configuration)
    {
        string? apikey = configuration.GetValue<string?>("ApiKey");
        ArgumentNullException.ThrowIfNull(apikey);
        return apikey;
    }
}
