using System.Security.Cryptography.X509Certificates;

namespace Deployment.DAL.Entities;

public class DeployAction:BaseEntity
{
    public int DeployActionId { get; set; }
    public bool Client { get; set; }
    public bool WebServer { get; set; }
    public bool ApiService { get; set; }
    public bool WebSite { get; set; }
    public bool PowerShell { get; set; }
    public bool WindowsService { get; set; }
    public bool TaskScheduler { get; set; }
    public bool DbScripts { get; set; }
    public int EnvironmentId { get; set; }
    public Environment Environment { get; set; }
}