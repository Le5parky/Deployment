using System.Globalization;

namespace Deployment.DAL.Entities;

public class Environment : BaseEntity
{
    public int EnvironmentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string GroupName { get; set; }
    public string Configuration { get; set; }
    public string SecurityRole { get; set; }
    public Application Application { get; set; }
    public EnvironmentHost EnvironmentHost { get; set; }
    public DeployAction DeployAction { get; set; }
    public ICollection<EnvironmentParameters> EnvironmentParameters { get; set; }
}