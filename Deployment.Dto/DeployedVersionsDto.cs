namespace Deployment.Dto;
public class DeployedVersionDto
{
    public string Environment {get;set;} = default!;
    public string Version {get;set;} = default!;
    public string Status{get;set;} = default!;
}