namespace Deployment.DAL.Entities;

public class DeployHistory:BaseEntity
{
    public int DeployHistoryId { get; set;}
    public string DeployStatus { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Environment Environment { get; set; }
    public TargetVersion TargetVersion { get; set; }
}