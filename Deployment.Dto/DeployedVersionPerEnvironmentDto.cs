namespace Deployment.Dto;

public class DeployedVersionPerEnvironmentDto{
    public string Environment{get;set;} = default!;
    public string Version {get;set;} = default!;
    public DateOnly DeploDate{get;set;}
    public string Status {get;set;} = default!;
}