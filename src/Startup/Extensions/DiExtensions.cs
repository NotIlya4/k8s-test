using ExceptionCatcherMiddleware.Extensions;
using Serilog;
using Serilog.Events;

namespace Startup.Extensions;

public static class DiExtensions
{
    public static void AddConfiguredExceptionCatcherMiddleware(this IServiceCollection services)
    {
        services.AddExceptionCatcherMiddlewareServices(builder =>
        {
            
        });
    }
    
    public static void AddConfiguredSerilog(this IServiceCollection services, IConfiguration config, string seqUrl)
    {
        services.AddSerilog((serilogServices, loggerConfigurator) =>
        {
            loggerConfigurator
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ServiceName", "TestService")
                .WriteTo.Console()
                .WriteTo.Seq(seqUrl)
                .ReadFrom.Configuration(config);
        });
    }
}