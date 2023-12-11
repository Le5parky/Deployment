using Microsoft.Extensions.Configuration;

namespace Deployment.Common.Configuration;

public class Configuration: IGitConfiguration, IConnectionStringConfiguration
{
    private readonly IConfiguration _configuration;
    public Configuration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GitPath => _configuration.GetSection("Git").Value;

    public string ConnectionString => _configuration.GetConnectionString("ConnectionString");
}

public interface IGitConfiguration
{
    string GitPath { get; }
}

public interface IConnectionStringConfiguration
{
    string ConnectionString { get; }
}