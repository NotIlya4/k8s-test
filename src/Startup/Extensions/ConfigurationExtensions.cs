namespace Startup.Extensions;

public static class ConfigurationExtensions
{
    public static T GetRequiredValue<T>(this IConfiguration config, string? key = null)
    {
        if (key is not null)
        {
            config = config.GetSection(key);
        }

        T? value = config.Get<T>();

        return value ?? throw new InvalidOperationException("There are no such parameter in configuration");
    }

    public static string GetRequiredValue(this IConfiguration config, string? key = null)
    {
        return config.GetRequiredValue<string>(key);
    }
}