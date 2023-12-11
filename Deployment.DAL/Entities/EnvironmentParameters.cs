namespace Deployment.DAL.Entities;

public class EnvironmentParameters : BaseEntity
{
    public int EnvironmentParametersId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}