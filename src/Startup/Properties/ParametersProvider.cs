using Startup.Extensions;

namespace Startup.Properties;

public class ParametersProvider
{
    private readonly IConfiguration _config;

    public ParametersProvider(IConfiguration config)
    {
        _config = config;
    }

    public string Seq => _config.GetRequiredValue<string>("SeqUrl");
    public string SqlServer => _config.GetSqlServerConnectionString("SqlServer");
}